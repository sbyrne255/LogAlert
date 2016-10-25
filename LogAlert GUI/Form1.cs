using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.ServiceProcess;
using System.Diagnostics;
using System.Data.SQLite;

//TODO...
//Problem: Service tries to email as soon as it starts, but it has an invalid password so it fails and crashes...
//Solution: Check if it has been configured from the config file, if it hasn't don't do shit. If it has, go ahead and do its thing...
namespace LogAlert_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Encryption security = new Encryption();
        public String log, id, sender, alias, receiver, receiverAlias, senderPassword, subject, SMPTHost;
        public bool SSL;
        public int days, hours, SMTPPort;
        
        
        
        private void Form1_Load(object ObjectSender, EventArgs e)
        {
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3"))
                {
                createDatabase();
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3;Version=3;");
                conn.Open();
                string sql = "CREATE TABLE IF NOT EXISTS config (sender VARCHAR(255), port INT(11), alias VARCHAR(255), receiver VARCHAR(255), receiver_alias VARCHAR(255), password VARCHAR(255), subject VARCHAR(255), host VARCHAR(255), ssl VARCHAR(255)," +
                             " event_ids TEXT, logs TEXT, frequency INT(11), days INT(11), email_sent BOOL)";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();


                string insertStatement = "INSERT INTO config (sender, alias, receiver,receiver_alias,password,subject,host,port,ssl,event_ids,logs,frequency,days) " +
                    "VALUES ('Sender@Domain.com','LogAlert System','NetAdmin@Domain.com','Systems Admin', 'DefaultPassword','Backup Failed Urgent Email Alert','SMTP.GMAIL.COM',587, 'true','15004;15005;15006;15007;517;65532','Application',4,30)";

                command = new SQLiteCommand(insertStatement, conn);
                command.ExecuteNonQuery();
                conn.Close();
                }
            }
            catch (Exception er) { MessageBox.Show(er.ToString()); }
            fillData();
        }
        private void button1_Click(object ObjSender, EventArgs e)
        {
            saveConfig();

            var logList = new List<string>(log.Split(';'));
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "LogAlert";
                eventLog.WriteEntry("Logging a fake error for application checking...", EventLogEntryType.Error, 65532, 1);
            }
            RestartService("LogAlert");
            this.Close();
        }
        private void button3_Click(object ObjSender, EventArgs e)
        {
            try{ saveConfig(); }catch (Exception er) { MessageBox.Show("Error saving config file... " + er.ToString()); }
            try { fillData(); } catch (Exception er) { MessageBox.Show("Error re-filling data... " + er.ToString());}
            if (sendEmail())
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat"))//Create file
                {using (StreamWriter w = File.AppendText("emailSent.dat")) { w.Write("A"); };}
                button1.Enabled = true;
                MessageBox.Show("SMTP Email sent. Please check your inbox before continuing");
            }
            else//Email failled
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat"))//If the file does exist, delete it.
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat");
                }
                button1.Enabled = false;
            }
            fillData();
        }




        public void fillData()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3;Version=3;");
                conn.Open();

                string sql = "SELECT * FROM config";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    log                     = reader["logs"].ToString();
                    id                      = reader["event_ids"].ToString();
                    sender                  = reader["sender"].ToString();
                    alias                   = reader["alias"].ToString();
                    receiver                = reader["receiver"].ToString();
                    receiverAlias           = reader["receiver_alias"].ToString();
                    senderPassword          = reader["password"].ToString();
                    subject                 = reader["subject"].ToString();
                    SMPTHost                = reader["host"].ToString();
                    SMTPPort                = Convert.ToInt32(reader["port"].ToString());
                    hours                   = Convert.ToInt32(reader["frequency"].ToString());
                    days                    = Convert.ToInt32(reader["days"].ToString());
                    SSL                     = Convert.ToBoolean(reader["ssl"].ToString());
                }
                conn.Close();

                txt_log.Text = log;
                txt_ids.Text = id;
                txt_sender.Text = sender;
                txt_sendAlias.Text = alias;
                txt_receiver.Text = receiver;
                txt_getAlias.Text = receiverAlias;
                txt_password.Text = senderPassword;
                txt_subject.Text = subject;
                txt_host.Text = SMPTHost;
                txt_port.Text = SMTPPort.ToString();
                txt_hours.Value = hours;
                txt_days.Value = days;
                if (SSL == true)
                {
                    useSSL.Checked = true;
                    noSSL.Checked = false;
                }
                else
                {
                    noSSL.Checked = true;
                    useSSL.Checked = false;
                }

            }
            catch (Exception er) { MessageBox.Show(er.ToString()); }
        }
        private bool allFieldsFilled()
        {
            if (txt_days.Value != 0 & txt_getAlias.Text != null & txt_host.Text != null & txt_hours.Value != 0 & txt_ids.Text != null & txt_log.Text != null & txt_password.Text != null & txt_port.Text != null & txt_receiver.Text != null & txt_sendAlias.Text != null & txt_sender.Text != null & txt_subject.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void RestartService(string serviceName)
        {
            var process = System.Diagnostics.Process.Start("net", "stop " + serviceName);
            process.WaitForExit();
            System.Diagnostics.Process.Start("net", "start " + serviceName);
        }
        public bool sendEmail()//THIS WHOLE SECTION SHOULD BE CONFIGURABLE...
        {
            try
            {
                //Database stuff to get other stuff...
                try
                {
                    //Send a test email here
                    var fromAddress = new MailAddress(sender, alias);
                    var toAddress = new MailAddress(receiver, receiverAlias);
                    string fromPassword = senderPassword;
                    string body = "<b>This message is a general example using your configured settings to ensure SMTP is working properly.</b> <br>";

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
                        Body = body
                    })
                    {
                        message.IsBodyHtml = true;
                        smtp.Send(message);
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Email failed to send. Error Logged at: " + er.ToString()); return false;
                }
                return true;
            }
            catch (Exception er) { MessageBox.Show("Email failed to send. This error has to do with the configuration file, not SMTP: " + er.ToString()); return false; }
        }
        public void saveConfig() {
            if (allFieldsFilled())
            {
                try
                {
                    if (!txt_log.Text.Contains("Application")) { txt_log.Text += ";Application"; }
                    if (!txt_ids.Text.Contains("65532")) { txt_ids.Text += ";65532"; }

                    SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3;Version=3;");
                    conn.Open();
                    bool usingSSL;
                    if (useSSL.Checked) { usingSSL = true; } else { usingSSL = false; }

                    string sql = String.Format("UPDATE config SET sender = '{0}', alias = '{1}', receiver = '{2}', receiver_alias = '{3}', password = '{4}', subject = '{5}', host = '{6}', port = '{7}', ssl = '{8}'," +
                        "event_ids = '{9}', logs = '{10}', frequency = {11}, days = {12}",
                        txt_sender.Text,
                        txt_sendAlias.Text,
                        txt_receiver.Text,
                        txt_getAlias.Text,
                        txt_password.Text,
                        txt_subject.Text,
                        txt_host.Text,
                        txt_port.Text,
                        usingSSL,
                        txt_ids.Text,
                        txt_log.Text,
                        txt_hours.Value,
                        txt_days.Value
                        );
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();

                }
                catch (Exception er) { MessageBox.Show("Error saving config... " + er.ToString()); }
            }
        }




        private void txt_sender_TextChanged(object Objsender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && txt_sender.Text == sender)//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            
        }
        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && txt_password.Text == senderPassword)//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void txt_host_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && txt_host.Text == SMPTHost )//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void txt_port_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && Convert.ToInt32(txt_port.Text) == SMTPPort)//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void useSSL_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && useSSL.Checked == SSL)//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void noSSL_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "emailSent.dat") && noSSL.Checked != SSL)//Create file
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void txt_password_Enter(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = false;
            txt_password.Focus();
            txt_password.Select();
        }
        private void txt_password_Leave(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }
        private void txt_password_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txt_receiver.Focus();
                e.IsInputKey = true;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 2.3.0" + Environment.NewLine + "For support or to report a bug please contact: StevenByrne255@Gmail.com");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }
        public void createDatabase()
        {
            try
            {
                SQLiteConnection.CreateFile("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3;Version=3;");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.db3;Version=3;");
            }
            catch(Exception er){}
        }
    }
}
