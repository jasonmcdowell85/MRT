namespace WindowsFormsApplication1
{
    partial class MainForm_RetryWithOptions
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
            this.MoveMessagesFromlabel = new System.Windows.Forms.Label();
            this.MoveMessagesTotxtbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.RetryMessagesbtn = new System.Windows.Forms.Button();
            this.MessageTypeToRetrycmbbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalMessagesInTheGridlabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SelectedMessagesInTheGridlabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BasicAdvancedOptionbtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Throttletxtbx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.UseAdvancedOptionsckbx = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn = new System.Windows.Forms.RadioButton();
            this.IgnoreMessagesThatWereSelectedIntheMainFridView = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalNumberOfMessagesToRetrytxtbx = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.RetryOverIntervalsradiobtn = new System.Windows.Forms.RadioButton();
            this.RetryConsecutivelyradiobtn = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.NumberOfMessagestoRetryPerIntervaltxtbx = new System.Windows.Forms.TextBox();
            this.RetryIntervalSecondstxbx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MoveMessagesFromlabel
            // 
            this.MoveMessagesFromlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveMessagesFromlabel.AutoSize = true;
            this.MoveMessagesFromlabel.Location = new System.Drawing.Point(14, 84);
            this.MoveMessagesFromlabel.Name = "MoveMessagesFromlabel";
            this.MoveMessagesFromlabel.Size = new System.Drawing.Size(28, 13);
            this.MoveMessagesFromlabel.TabIndex = 14;
            this.MoveMessagesFromlabel.Text = "path";
            // 
            // MoveMessagesTotxtbx
            // 
            this.MoveMessagesTotxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveMessagesTotxtbx.Location = new System.Drawing.Point(256, 80);
            this.MoveMessagesTotxtbx.Name = "MoveMessagesTotxtbx";
            this.MoveMessagesTotxtbx.Size = new System.Drawing.Size(249, 20);
            this.MoveMessagesTotxtbx.TabIndex = 13;
            this.MoveMessagesTotxtbx.TextChanged += new System.EventHandler(this.MoveMessagesTotxtbx_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Moving messages to:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Moving messages from:";
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbtn.Location = new System.Drawing.Point(291, 9);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(97, 23);
            this.Cancelbtn.TabIndex = 10;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            // 
            // RetryMessagesbtn
            // 
            this.RetryMessagesbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RetryMessagesbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RetryMessagesbtn.Enabled = false;
            this.RetryMessagesbtn.Location = new System.Drawing.Point(184, 9);
            this.RetryMessagesbtn.Name = "RetryMessagesbtn";
            this.RetryMessagesbtn.Size = new System.Drawing.Size(100, 23);
            this.RetryMessagesbtn.TabIndex = 9;
            this.RetryMessagesbtn.Text = "Retry Messages";
            this.RetryMessagesbtn.UseVisualStyleBackColor = true;
            this.RetryMessagesbtn.Click += new System.EventHandler(this.RetryMessagesbtn_Click_1);
            // 
            // MessageTypeToRetrycmbbx
            // 
            this.MessageTypeToRetrycmbbx.BackColor = System.Drawing.SystemColors.Window;
            this.MessageTypeToRetrycmbbx.Enabled = false;
            this.MessageTypeToRetrycmbbx.FormattingEnabled = true;
            this.MessageTypeToRetrycmbbx.Items.AddRange(new object[] {
            "All",
            "Voicemails",
            "Faxes",
            "Recordings",
            "Notifications",
            "Other"});
            this.MessageTypeToRetrycmbbx.Location = new System.Drawing.Point(34, 101);
            this.MessageTypeToRetrycmbbx.Name = "MessageTypeToRetrycmbbx";
            this.MessageTypeToRetrycmbbx.Size = new System.Drawing.Size(106, 21);
            this.MessageTypeToRetrycmbbx.TabIndex = 15;
            this.MessageTypeToRetrycmbbx.Text = "default (All)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Message type to retry";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(2, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 10);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.TotalMessagesInTheGridlabel);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.SelectedMessagesInTheGridlabel);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.MoveMessagesFromlabel);
            this.panel2.Controls.Add(this.MoveMessagesTotxtbx);
            this.panel2.Location = new System.Drawing.Point(2, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 197);
            this.panel2.TabIndex = 19;
            // 
            // TotalMessagesInTheGridlabel
            // 
            this.TotalMessagesInTheGridlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalMessagesInTheGridlabel.AutoSize = true;
            this.TotalMessagesInTheGridlabel.Location = new System.Drawing.Point(431, 118);
            this.TotalMessagesInTheGridlabel.Name = "TotalMessagesInTheGridlabel";
            this.TotalMessagesInTheGridlabel.Size = new System.Drawing.Size(46, 13);
            this.TotalMessagesInTheGridlabel.TabIndex = 35;
            this.TotalMessagesInTheGridlabel.Text = "[ count ]";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Total messages in the grid:";
            // 
            // SelectedMessagesInTheGridlabel
            // 
            this.SelectedMessagesInTheGridlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedMessagesInTheGridlabel.AutoSize = true;
            this.SelectedMessagesInTheGridlabel.Location = new System.Drawing.Point(207, 118);
            this.SelectedMessagesInTheGridlabel.Name = "SelectedMessagesInTheGridlabel";
            this.SelectedMessagesInTheGridlabel.Size = new System.Drawing.Size(46, 13);
            this.SelectedMessagesInTheGridlabel.TabIndex = 33;
            this.SelectedMessagesInTheGridlabel.Text = "[ count ]";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Selected messages in the grid:";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.BasicAdvancedOptionbtn);
            this.panel9.Controls.Add(this.RetryMessagesbtn);
            this.panel9.Controls.Add(this.Cancelbtn);
            this.panel9.Location = new System.Drawing.Point(40, 144);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(443, 44);
            this.panel9.TabIndex = 31;
            // 
            // BasicAdvancedOptionbtn
            // 
            this.BasicAdvancedOptionbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BasicAdvancedOptionbtn.Location = new System.Drawing.Point(41, 9);
            this.BasicAdvancedOptionbtn.Name = "BasicAdvancedOptionbtn";
            this.BasicAdvancedOptionbtn.Size = new System.Drawing.Size(100, 23);
            this.BasicAdvancedOptionbtn.TabIndex = 11;
            this.BasicAdvancedOptionbtn.Text = "Advanced";
            this.BasicAdvancedOptionbtn.UseVisualStyleBackColor = true;
            this.BasicAdvancedOptionbtn.Click += new System.EventHandler(this.BasicAdvancedOptionbtn_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(32, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(459, 21);
            this.panel6.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Confirm Retry Settings";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.Throttletxtbx);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.UseAdvancedOptionsckbx);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(2, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 220);
            this.panel3.TabIndex = 20;
            // 
            // Throttletxtbx
            // 
            this.Throttletxtbx.Location = new System.Drawing.Point(434, 48);
            this.Throttletxtbx.Name = "Throttletxtbx";
            this.Throttletxtbx.Size = new System.Drawing.Size(69, 20);
            this.Throttletxtbx.TabIndex = 34;
            this.Throttletxtbx.Text = "200";
            this.Throttletxtbx.TextChanged += new System.EventHandler(this.Throttletxtbx_TextChanged);
            this.Throttletxtbx.Leave += new System.EventHandler(this.Throttletxtbx_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Throttle (ms.)";
            this.toolTip1.SetToolTip(this.label9, "The number of milliseconds to wait between \r\neach successive retry.");
            // 
            // UseAdvancedOptionsckbx
            // 
            this.UseAdvancedOptionsckbx.AutoSize = true;
            this.UseAdvancedOptionsckbx.Checked = true;
            this.UseAdvancedOptionsckbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAdvancedOptionsckbx.Location = new System.Drawing.Point(15, 38);
            this.UseAdvancedOptionsckbx.Name = "UseAdvancedOptionsckbx";
            this.UseAdvancedOptionsckbx.Size = new System.Drawing.Size(100, 30);
            this.UseAdvancedOptionsckbx.TabIndex = 33;
            this.UseAdvancedOptionsckbx.Text = "Use Advanced \r\nOptions";
            this.toolTip1.SetToolTip(this.UseAdvancedOptionsckbx, "If enabled, the Advanced Retry Options will be used.\r\n\r\nIf not enabled, then all " +
                    "messages (if any) that were \r\nselected in the grid will be retried consecutively" +
                    ".");
            this.UseAdvancedOptionsckbx.UseVisualStyleBackColor = true;
            this.UseAdvancedOptionsckbx.CheckedChanged += new System.EventHandler(this.UseAdvancedOptionsckbx_CheckedChanged);
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn);
            this.panel10.Controls.Add(this.IgnoreMessagesThatWereSelectedIntheMainFridView);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.TotalNumberOfMessagesToRetrytxtbx);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.MessageTypeToRetrycmbbx);
            this.panel10.Location = new System.Drawing.Point(11, 75);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(259, 125);
            this.panel10.TabIndex = 32;
            // 
            // OnlyRetryMessagesSelectedInTheMainGridViewradiobtn
            // 
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.AutoSize = true;
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Checked = true;
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Location = new System.Drawing.Point(8, 3);
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Name = "OnlyRetryMessagesSelectedInTheMainGridViewradiobtn";
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Size = new System.Drawing.Size(165, 30);
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.TabIndex = 30;
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.TabStop = true;
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Text = " Only retry messages selected\r\n in the main grid view";
            this.OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.UseVisualStyleBackColor = true;
            // 
            // IgnoreMessagesThatWereSelectedIntheMainFridView
            // 
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.AutoSize = true;
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.Location = new System.Drawing.Point(8, 35);
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.Name = "IgnoreMessagesThatWereSelectedIntheMainFridView";
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.Size = new System.Drawing.Size(198, 30);
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.TabIndex = 31;
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.Text = " Ignore messages that were selected\r\n in the main grid view for retry";
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.UseVisualStyleBackColor = true;
            this.IgnoreMessagesThatWereSelectedIntheMainFridView.CheckedChanged += new System.EventHandler(this.IgnoreMessagesThatWereSelectedIntheMainFridView_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total number of messages \r\n  to retry";
            // 
            // TotalNumberOfMessagesToRetrytxtbx
            // 
            this.TotalNumberOfMessagesToRetrytxtbx.Enabled = false;
            this.TotalNumberOfMessagesToRetrytxtbx.Location = new System.Drawing.Point(34, 73);
            this.TotalNumberOfMessagesToRetrytxtbx.Name = "TotalNumberOfMessagesToRetrytxtbx";
            this.TotalNumberOfMessagesToRetrytxtbx.ReadOnly = true;
            this.TotalNumberOfMessagesToRetrytxtbx.Size = new System.Drawing.Size(56, 20);
            this.TotalNumberOfMessagesToRetrytxtbx.TabIndex = 19;
            this.TotalNumberOfMessagesToRetrytxtbx.TextChanged += new System.EventHandler(this.TotalNumberOfMessagesToRetrytxtbx_TextChanged);
            this.TotalNumberOfMessagesToRetrytxtbx.Leave += new System.EventHandler(this.TotalNumberOfMessagesToRetrytxtbx_Leave);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(35, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(459, 21);
            this.panel7.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Advanced Retry Options";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.RetryOverIntervalsradiobtn);
            this.panel5.Controls.Add(this.RetryConsecutivelyradiobtn);
            this.panel5.Location = new System.Drawing.Point(126, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(292, 35);
            this.panel5.TabIndex = 28;
            // 
            // RetryOverIntervalsradiobtn
            // 
            this.RetryOverIntervalsradiobtn.AutoSize = true;
            this.RetryOverIntervalsradiobtn.Location = new System.Drawing.Point(155, 8);
            this.RetryOverIntervalsradiobtn.Name = "RetryOverIntervalsradiobtn";
            this.RetryOverIntervalsradiobtn.Size = new System.Drawing.Size(116, 17);
            this.RetryOverIntervalsradiobtn.TabIndex = 23;
            this.RetryOverIntervalsradiobtn.Text = "Retry over intervals";
            this.RetryOverIntervalsradiobtn.UseVisualStyleBackColor = true;
            this.RetryOverIntervalsradiobtn.CheckedChanged += new System.EventHandler(this.RetryOverIntervalsradiobtn_CheckedChanged);
            // 
            // RetryConsecutivelyradiobtn
            // 
            this.RetryConsecutivelyradiobtn.AutoSize = true;
            this.RetryConsecutivelyradiobtn.Checked = true;
            this.RetryConsecutivelyradiobtn.Location = new System.Drawing.Point(12, 8);
            this.RetryConsecutivelyradiobtn.Name = "RetryConsecutivelyradiobtn";
            this.RetryConsecutivelyradiobtn.Size = new System.Drawing.Size(118, 17);
            this.RetryConsecutivelyradiobtn.TabIndex = 22;
            this.RetryConsecutivelyradiobtn.TabStop = true;
            this.RetryConsecutivelyradiobtn.Text = "Retry consecutively";
            this.toolTip1.SetToolTip(this.RetryConsecutivelyradiobtn, "Retry messages one after another, with a throttle");
            this.RetryConsecutivelyradiobtn.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.NumberOfMessagestoRetryPerIntervaltxtbx);
            this.panel4.Controls.Add(this.RetryIntervalSecondstxbx);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(277, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 124);
            this.panel4.TabIndex = 27;
            // 
            // NumberOfMessagestoRetryPerIntervaltxtbx
            // 
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = false;
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Location = new System.Drawing.Point(49, 94);
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Name = "NumberOfMessagestoRetryPerIntervaltxtbx";
            this.NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = true;
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Size = new System.Drawing.Size(66, 20);
            this.NumberOfMessagestoRetryPerIntervaltxtbx.TabIndex = 27;
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Text = "100";
            this.NumberOfMessagestoRetryPerIntervaltxtbx.TextChanged += new System.EventHandler(this.NumberOfMessagestoRetryPerIntervaltxtbx_TextChanged);
            this.NumberOfMessagestoRetryPerIntervaltxtbx.Leave += new System.EventHandler(this.NumberOfMessagestoRetryPerIntervaltxtbx_Leave);
            // 
            // RetryIntervalSecondstxbx
            // 
            this.RetryIntervalSecondstxbx.Enabled = false;
            this.RetryIntervalSecondstxbx.Location = new System.Drawing.Point(49, 33);
            this.RetryIntervalSecondstxbx.Name = "RetryIntervalSecondstxbx";
            this.RetryIntervalSecondstxbx.ReadOnly = true;
            this.RetryIntervalSecondstxbx.Size = new System.Drawing.Size(80, 20);
            this.RetryIntervalSecondstxbx.TabIndex = 25;
            this.RetryIntervalSecondstxbx.Text = "30";
            this.RetryIntervalSecondstxbx.TextChanged += new System.EventHandler(this.RetryIntervalSecondstxbx_TextChanged);
            this.RetryIntervalSecondstxbx.Leave += new System.EventHandler(this.RetryIntervalSecondstxbx_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Number of messages to retry (per interval):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Retry interval (every x seconds):";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Location = new System.Drawing.Point(2, 211);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(527, 10);
            this.panel8.TabIndex = 21;
            // 
            // MainForm_RetryWithOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 419);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(547, 453);
            this.MinimumSize = new System.Drawing.Size(547, 226);
            this.Name = "MainForm_RetryWithOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Retry with options";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MoveMessagesFromlabel;
        private System.Windows.Forms.TextBox MoveMessagesTotxtbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button RetryMessagesbtn;
        private System.Windows.Forms.ComboBox MessageTypeToRetrycmbbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton RetryOverIntervalsradiobtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox NumberOfMessagestoRetryPerIntervaltxtbx;
        private System.Windows.Forms.TextBox RetryIntervalSecondstxbx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RetryConsecutivelyradiobtn;
        private System.Windows.Forms.TextBox TotalNumberOfMessagesToRetrytxtbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton IgnoreMessagesThatWereSelectedIntheMainFridView;
        private System.Windows.Forms.RadioButton OnlyRetryMessagesSelectedInTheMainGridViewradiobtn;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BasicAdvancedOptionbtn;
        private System.Windows.Forms.CheckBox UseAdvancedOptionsckbx;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox Throttletxtbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label TotalMessagesInTheGridlabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label SelectedMessagesInTheGridlabel;
        private System.Windows.Forms.Label label10;
    }
}