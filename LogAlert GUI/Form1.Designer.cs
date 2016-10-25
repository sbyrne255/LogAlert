namespace LogAlert_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_hours = new System.Windows.Forms.NumericUpDown();
            this.txt_days = new System.Windows.Forms.NumericUpDown();
            this.txt_ids = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.GroupBox();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_getAlias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_receiver = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sendAlias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.noSSL = new System.Windows.Forms.RadioButton();
            this.useSSL = new System.Windows.Forms.RadioButton();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_host = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_days)).BeginInit();
            this.EmailBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save and Start";
            this.toolTip1.SetToolTip(this.button1, "Save the configurations and exit. The service will instantly be used by the servi" +
                    "ce");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_hours);
            this.groupBox1.Controls.Add(this.txt_days);
            this.groupBox1.Controls.Add(this.txt_ids);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_log);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure LogAlert Settings";
            // 
            // txt_hours
            // 
            this.txt_hours.Location = new System.Drawing.Point(153, 74);
            this.txt_hours.Name = "txt_hours";
            this.txt_hours.Size = new System.Drawing.Size(198, 20);
            this.txt_hours.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txt_hours, "Specify the delay before re-checking event logs");
            // 
            // txt_days
            // 
            this.txt_days.Location = new System.Drawing.Point(153, 98);
            this.txt_days.Name = "txt_days";
            this.txt_days.Size = new System.Drawing.Size(198, 20);
            this.txt_days.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txt_days, "Specify how far back you want to search in the logs (default 30 days)");
            // 
            // txt_ids
            // 
            this.txt_ids.Location = new System.Drawing.Point(87, 19);
            this.txt_ids.Name = "txt_ids";
            this.txt_ids.Size = new System.Drawing.Size(264, 20);
            this.txt_ids.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txt_ids, "Add event keys to monitor in the system, seperate with a \";\"");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Check Frequency (hours)";
            this.toolTip1.SetToolTip(this.label9, "Specify the delay before re-checking event logs");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Event IDs";
            this.toolTip1.SetToolTip(this.label12, "Add event keys to monitor in the system, seperate with a \";\"");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Log Name";
            this.toolTip1.SetToolTip(this.label11, "Add logs to search in (Application, Security, System, ect) seperate with \";\"");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Back Logs To Check (Days)";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(87, 45);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(264, 20);
            this.txt_log.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txt_log, "Add logs to search in (Application, Security, System, ect) seperate with \";\"");
            // 
            // EmailBox
            // 
            this.EmailBox.Controls.Add(this.txt_subject);
            this.EmailBox.Controls.Add(this.label6);
            this.EmailBox.Controls.Add(this.txt_password);
            this.EmailBox.Controls.Add(this.label5);
            this.EmailBox.Controls.Add(this.txt_getAlias);
            this.EmailBox.Controls.Add(this.label4);
            this.EmailBox.Controls.Add(this.txt_receiver);
            this.EmailBox.Controls.Add(this.label3);
            this.EmailBox.Controls.Add(this.txt_sendAlias);
            this.EmailBox.Controls.Add(this.label2);
            this.EmailBox.Controls.Add(this.txt_sender);
            this.EmailBox.Controls.Add(this.label1);
            this.EmailBox.Location = new System.Drawing.Point(12, 169);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(357, 176);
            this.EmailBox.TabIndex = 2;
            this.EmailBox.TabStop = false;
            this.EmailBox.Text = "Configure Email Settings";
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(87, 149);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(264, 20);
            this.txt_subject.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txt_subject, "Subject of Email");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Subject";
            this.toolTip1.SetToolTip(this.label6, "Subject of Email");
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(87, 71);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(264, 20);
            this.txt_password.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txt_password, "Password for the SMTP\'s email account specified above (sender\'s password)");
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            this.txt_password.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_password_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            this.toolTip1.SetToolTip(this.label5, "Password for the SMTP\'s email account specified above (sender\'s password)");
            // 
            // txt_getAlias
            // 
            this.txt_getAlias.Location = new System.Drawing.Point(87, 123);
            this.txt_getAlias.Name = "txt_getAlias";
            this.txt_getAlias.Size = new System.Drawing.Size(264, 20);
            this.txt_getAlias.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txt_getAlias, "Alias for the receiver. Example Network Administrator");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Receiver Alias";
            this.toolTip1.SetToolTip(this.label4, "Alias for the receiver. Example Network Administrator");
            // 
            // txt_receiver
            // 
            this.txt_receiver.Location = new System.Drawing.Point(87, 97);
            this.txt_receiver.Name = "txt_receiver";
            this.txt_receiver.Size = new System.Drawing.Size(264, 20);
            this.txt_receiver.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txt_receiver, "Email address the email will send to");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Receiver";
            this.toolTip1.SetToolTip(this.label3, "Email address the email will send to");
            // 
            // txt_sendAlias
            // 
            this.txt_sendAlias.Location = new System.Drawing.Point(87, 45);
            this.txt_sendAlias.Name = "txt_sendAlias";
            this.txt_sendAlias.Size = new System.Drawing.Size(264, 20);
            this.txt_sendAlias.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txt_sendAlias, "What is the sender\'s Alias. Example AlertLog Automated");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alias";
            this.toolTip1.SetToolTip(this.label2, "What is the sender\'s Alias. Example AlertLog Automated");
            // 
            // txt_sender
            // 
            this.txt_sender.Location = new System.Drawing.Point(87, 19);
            this.txt_sender.Name = "txt_sender";
            this.txt_sender.Size = new System.Drawing.Size(264, 20);
            this.txt_sender.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txt_sender, "Specify who sends the email (this account is used for authentication in the SMTP " +
                    "settings)");
            this.txt_sender.TextChanged += new System.EventHandler(this.txt_sender_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sender";
            this.toolTip1.SetToolTip(this.label1, "Specify who sends the email (this account is used for authentication in the SMTP " +
                    "settings)");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noSSL);
            this.groupBox3.Controls.Add(this.useSSL);
            this.groupBox3.Controls.Add(this.txt_port);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_host);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configure SMTP Settings";
            // 
            // noSSL
            // 
            this.noSSL.AutoSize = true;
            this.noSSL.Location = new System.Drawing.Point(139, 71);
            this.noSSL.Name = "noSSL";
            this.noSSL.Size = new System.Drawing.Size(161, 17);
            this.noSSL.TabIndex = 14;
            this.noSSL.TabStop = true;
            this.noSSL.Text = "Do Not Use SSL Connection";
            this.toolTip1.SetToolTip(this.noSSL, "Do you want to use SSL connections");
            this.noSSL.UseVisualStyleBackColor = true;
            this.noSSL.CheckedChanged += new System.EventHandler(this.noSSL_CheckedChanged);
            // 
            // useSSL
            // 
            this.useSSL.AutoSize = true;
            this.useSSL.Location = new System.Drawing.Point(9, 71);
            this.useSSL.Name = "useSSL";
            this.useSSL.Size = new System.Drawing.Size(124, 17);
            this.useSSL.TabIndex = 13;
            this.useSSL.TabStop = true;
            this.useSSL.Text = "Use SSL Connection";
            this.toolTip1.SetToolTip(this.useSSL, "Do you want to use SSL connections");
            this.useSSL.UseVisualStyleBackColor = true;
            this.useSSL.CheckedChanged += new System.EventHandler(this.useSSL_CheckedChanged);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(62, 45);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(289, 20);
            this.txt_port.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txt_port, "What port will the email be sent on?");
            this.txt_port.TextChanged += new System.EventHandler(this.txt_port_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Port";
            this.toolTip1.SetToolTip(this.label8, "What port will the email be sent on?");
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(62, 19);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(289, 20);
            this.txt_host.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txt_host, "SMTP Host. Example SMTP.Gmail.com");
            this.txt_host.TextChanged += new System.EventHandler(this.txt_host_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Host";
            this.toolTip1.SetToolTip(this.label7, "SMTP Host. Example SMTP.Gmail.com");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "SMTP Test";
            this.toolTip1.SetToolTip(this.button3, "Test the SMTP settings by sending a test email (this does not run thorugh the ser" +
                    "vice, a full stack test is suggested).");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(381, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "About";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 486);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "LogAlert Configuration Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_days)).EndInit();
            this.EmailBox.ResumeLayout(false);
            this.EmailBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox EmailBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_sender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sendAlias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_receiver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_getAlias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton noSSL;
        private System.Windows.Forms.RadioButton useSSL;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ids;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.NumericUpDown txt_hours;
        private System.Windows.Forms.NumericUpDown txt_days;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

