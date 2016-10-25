using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Data.SQLite;
namespace LogAlert
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        private Thread _thread;
        public String log = "Application", id = "1000", sender, alias, receiver, receiverAlias, senderPassword, subject, SMPTHost;
        public int hours = 0, SMTPPort = 0, dd = 0;
        public bool SSL = true;

        protected override void OnStop()
        {
        }
        public void OnDebug() {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();

            try
            {
                _thread = new Thread(WorkerThreadFunc);
                _thread.Name = "PrimaryFunction";
                _thread.IsBackground = true;
                _thread.Start();
            }
            //cmd.updateSystem(null);
            catch (Exception er) { errorLog("Problem starting thread " + er.ToString()); }
        }
        private void errorLog(string msg)
        {
            DateTime thisDay = DateTime.Today;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"ErrorLog.txt", true))
            {
                file.WriteLine(msg);
            }
        }
        private void logger(string msg)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt", true))
            {
                file.WriteLine(msg);
            }
        }
        public void refreshData()
        {
            logger("Data is being refreshed");
            SQLiteConnection conn = new SQLiteConnection("Data Source="+AppDomain.CurrentDomain.BaseDirectory+"MyDatabase.db3;Version=3;");
            conn.Open();
            string sql = "SELECT * FROM config";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                log = reader["logs"].ToString();
                id = reader["event_ids"].ToString();
                sender = reader["sender"].ToString();
                alias = reader["alias"].ToString();
                receiver = reader["receiver"].ToString();
                receiverAlias = reader["receiver_alias"].ToString();
                senderPassword = reader["password"].ToString();
                subject = reader["subject"].ToString();
                SMPTHost = reader["host"].ToString();
                SMTPPort = Convert.ToInt32(reader["port"].ToString());
                hours = Convert.ToInt32(reader["frequency"].ToString());
                dd = Convert.ToInt32(reader["days"].ToString());
                SSL = Convert.ToBoolean(reader["ssl"].ToString());
            }
            conn.Close();
        }

        private void logCheck(object source, ElapsedEventArgs e)
        {
            try
            {
#pragma warning disable 0618//Depreciated code for EventID, new one is InstanceID but they are not always the same.
                logger("About to refresh data...");
                refreshData();

                var logList = new List<string>();
                if (log.Contains(';')){logList = new List<string>(log.Split(';'));}else{logList.Add(log);}
                logger("All System logs included are: " + log);

                var idList = new List<string>();
                if (id.Contains(';')) { idList = new List<string>(id.Split(';')); } else { idList.Add(id); }
                logger("IDs being checked are: " + id);

                DateTime fromDate = DateTime.Now.AddDays(-dd);//Get Days from config.

                string contents;
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "capturedEvents.txt")){contents = sr.ReadToEnd();}

                    try
                    {
                        for (int i = 0; i < logList.Count; i++)
                        {
                            var eventLog = new EventLog(logList[i].ToString());
                            var Events = eventLog.Entries.Cast<EventLogEntry>().Reverse();//Get newests...
                            foreach (EventLogEntry entry in Events)
                            {
                                //IF the entry is an error and it is NOT is our pre-reported list, and it matches one of our IDs....
                                if (entry.EntryType == EventLogEntryType.Error && idList.Contains(entry.EventID.ToString()) && !contents.Contains(entry.TimeGenerated.ToString()))
                                {
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "capturedEvents.txt", true)) { file.WriteLine(entry.TimeGenerated); }
                                    logger("An error was found, reporting it now! " + entry.EventID.ToString() + entry.TimeGenerated);
                                    sendEmail("Entery ID: <i>" + entry.EventID.ToString() + "</i> <br>" + "Entery Time Created: " + entry.TimeGenerated + "<br>" + "Entery Description: " + entry.Message.ToString());
                                }
                                if (entry.TimeGenerated < fromDate) { break; }
                            }
                        }
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        errorLog(ex.ToString());
                    }

            }
            catch (Exception er) { errorLog(er.ToString() + "START"); }
        }
        private void WorkerThreadFunc() {
            try
            {
                logger("Refreshing data in worker thread");
                refreshData();
                #region Timer initialization...
                try
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer = new System.Timers.Timer(((1000 * 1) * 60)* hours);//get time in hours from config
                    aTimer.Elapsed += logCheck;
                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
                }
                catch (Exception ex) { errorLog("Error in inititallizing timer. " + ex.ToString()); }
                #endregion

                logCheck(null, null);
            }
            catch (Exception er) { errorLog(er.ToString() + "START"); }
        
        
        }
        public void sendEmail(string msg)
        {
            try
            {

                var fromAddress = new MailAddress(sender, alias);
                var toAddress = new MailAddress(receiver, receiverAlias);
                string fromPassword = senderPassword;
                string body = "<b>This is an urgent message a backup has failed with the following information.</b> <br>";

                var smtp = new SmtpClient
                {
                    Host = SMPTHost,
                    Port = SMTPPort,
                    EnableSsl = SSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body + msg
                })
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
            catch (Exception er) { errorLog(er.ToString() + "START"); }
        }
    }
}
