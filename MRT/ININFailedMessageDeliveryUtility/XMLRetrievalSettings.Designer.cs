namespace WindowsFormsApplication1
{
    partial class XMLRetrievalSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLRetrievalSettings));
            this.Ok = new System.Windows.Forms.Button();
            this.CurrentDirectorytxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentConfigurationtxt = new System.Windows.Forms.Label();
            this.AllMessagesradiobtn = new System.Windows.Forms.RadioButton();
            this.SpecifyQuantityradiobtn = new System.Windows.Forms.RadioButton();
            this.BrowseToXMLradiobutton = new System.Windows.Forms.RadioButton();
            this.BrowsebtnToXML = new System.Windows.Forms.Button();
            this.SpecifyXMLtxtbx = new System.Windows.Forms.TextBox();
            this.SpecifyMessageQuantitytxtbx = new System.Windows.Forms.TextBox();
            this.CurrentMailDirectorytextbox = new System.Windows.Forms.TextBox();
            this.BrowsebtnMailDir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerValuelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalMessageCountlabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpdateCountbtn = new System.Windows.Forms.Button();
            this.SpecifyXMLSyncchkbx = new System.Windows.Forms.CheckBox();
            this.OtherDirectory = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusFooter1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusFooter2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Enabled = false;
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok.Location = new System.Drawing.Point(145, 278);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(93, 24);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "Ok";
            this.toolTip1.SetToolTip(this.Ok, "Submit the message retrieval settings\r\nto load the selected (if any) XML files.");
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // CurrentDirectorytxt
            // 
            this.CurrentDirectorytxt.AutoSize = true;
            this.CurrentDirectorytxt.Location = new System.Drawing.Point(35, 140);
            this.CurrentDirectorytxt.Name = "CurrentDirectorytxt";
            this.CurrentDirectorytxt.Size = new System.Drawing.Size(108, 13);
            this.CurrentDirectorytxt.TabIndex = 34;
            this.CurrentDirectorytxt.Text = "Current mail directory:";
            this.toolTip1.SetToolTip(this.CurrentDirectorytxt, resources.GetString("CurrentDirectorytxt.ToolTip"));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Import messages";
            // 
            // CurrentConfigurationtxt
            // 
            this.CurrentConfigurationtxt.AutoSize = true;
            this.CurrentConfigurationtxt.Location = new System.Drawing.Point(31, 119);
            this.CurrentConfigurationtxt.Name = "CurrentConfigurationtxt";
            this.CurrentConfigurationtxt.Size = new System.Drawing.Size(106, 13);
            this.CurrentConfigurationtxt.TabIndex = 32;
            this.CurrentConfigurationtxt.Text = "Current Configuration";
            // 
            // AllMessagesradiobtn
            // 
            this.AllMessagesradiobtn.AutoSize = true;
            this.AllMessagesradiobtn.Location = new System.Drawing.Point(15, 34);
            this.AllMessagesradiobtn.Name = "AllMessagesradiobtn";
            this.AllMessagesradiobtn.Size = new System.Drawing.Size(121, 17);
            this.AllMessagesradiobtn.TabIndex = 1;
            this.AllMessagesradiobtn.TabStop = true;
            this.AllMessagesradiobtn.Text = "All (current directory)";
            this.toolTip1.SetToolTip(this.AllMessagesradiobtn, "Import all XML messages that reside\r\nunder the current directory below");
            this.AllMessagesradiobtn.UseVisualStyleBackColor = true;
            this.AllMessagesradiobtn.CheckedChanged += new System.EventHandler(this.AllMessagesradiobtn_CheckedChanged);
            // 
            // SpecifyQuantityradiobtn
            // 
            this.SpecifyQuantityradiobtn.AutoSize = true;
            this.SpecifyQuantityradiobtn.Location = new System.Drawing.Point(14, 62);
            this.SpecifyQuantityradiobtn.Name = "SpecifyQuantityradiobtn";
            this.SpecifyQuantityradiobtn.Size = new System.Drawing.Size(188, 17);
            this.SpecifyQuantityradiobtn.TabIndex = 2;
            this.SpecifyQuantityradiobtn.TabStop = true;
            this.SpecifyQuantityradiobtn.Text = "Specify quantity (current directory):";
            this.toolTip1.SetToolTip(this.SpecifyQuantityradiobtn, "Import a subset of XML messages that reside\r\nunder the current directory below (b" +
                    "y count \r\nfrom the lowest to the highest XML name/number).");
            this.SpecifyQuantityradiobtn.UseVisualStyleBackColor = true;
            this.SpecifyQuantityradiobtn.CheckedChanged += new System.EventHandler(this.SpecifyQuantityradiobtn_CheckedChanged);
            // 
            // BrowseToXMLradiobutton
            // 
            this.BrowseToXMLradiobutton.AutoSize = true;
            this.BrowseToXMLradiobutton.Location = new System.Drawing.Point(17, 210);
            this.BrowseToXMLradiobutton.Name = "BrowseToXMLradiobutton";
            this.BrowseToXMLradiobutton.Size = new System.Drawing.Size(100, 17);
            this.BrowseToXMLradiobutton.TabIndex = 7;
            this.BrowseToXMLradiobutton.TabStop = true;
            this.BrowseToXMLradiobutton.Text = "Browse to XML:";
            this.toolTip1.SetToolTip(this.BrowseToXMLradiobutton, "Specify an XML file path+name to open.");
            this.BrowseToXMLradiobutton.UseVisualStyleBackColor = true;
            // 
            // BrowsebtnToXML
            // 
            this.BrowsebtnToXML.Location = new System.Drawing.Point(269, 230);
            this.BrowsebtnToXML.Name = "BrowsebtnToXML";
            this.BrowsebtnToXML.Size = new System.Drawing.Size(87, 23);
            this.BrowsebtnToXML.TabIndex = 10;
            this.BrowsebtnToXML.Text = "Browse...";
            this.toolTip1.SetToolTip(this.BrowsebtnToXML, "Select a directory path.");
            this.BrowsebtnToXML.UseVisualStyleBackColor = true;
            this.BrowsebtnToXML.Click += new System.EventHandler(this.BrowsebtnToXML_Click);
            // 
            // SpecifyXMLtxtbx
            // 
            this.SpecifyXMLtxtbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SpecifyXMLtxtbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.SpecifyXMLtxtbx.Location = new System.Drawing.Point(38, 231);
            this.SpecifyXMLtxtbx.Name = "SpecifyXMLtxtbx";
            this.SpecifyXMLtxtbx.Size = new System.Drawing.Size(216, 20);
            this.SpecifyXMLtxtbx.TabIndex = 9;
            this.SpecifyXMLtxtbx.TextChanged += new System.EventHandler(this.SpecifyXMLtxtbx_TextChanged);
            this.SpecifyXMLtxtbx.Enter += new System.EventHandler(this.SpecifyXMLtxtbx_Enter);
            this.SpecifyXMLtxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpecifyXMLtxtbx_KeyDown);
            this.SpecifyXMLtxtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecifyXMLtxtbx_KeyPress);
            // 
            // SpecifyMessageQuantitytxtbx
            // 
            this.SpecifyMessageQuantitytxtbx.Location = new System.Drawing.Point(36, 84);
            this.SpecifyMessageQuantitytxtbx.Name = "SpecifyMessageQuantitytxtbx";
            this.SpecifyMessageQuantitytxtbx.Size = new System.Drawing.Size(76, 20);
            this.SpecifyMessageQuantitytxtbx.TabIndex = 3;
            this.SpecifyMessageQuantitytxtbx.TextChanged += new System.EventHandler(this.SpecifyMessageQuantitytxtbx_TextChanged);
            this.SpecifyMessageQuantitytxtbx.Enter += new System.EventHandler(this.SpecifyMessageQuantitytxtbx_Enter);
            this.SpecifyMessageQuantitytxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpecifyMessageQuantitytxtbx_KeyDown);
            this.SpecifyMessageQuantitytxtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecifyMessageQuantitytxtbx_KeyPress);
            this.SpecifyMessageQuantitytxtbx.Leave += new System.EventHandler(this.SpecifyMessageQuantitytxtbx_Leave);
            // 
            // CurrentMailDirectorytextbox
            // 
            this.CurrentMailDirectorytextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CurrentMailDirectorytextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.CurrentMailDirectorytextbox.Location = new System.Drawing.Point(38, 159);
            this.CurrentMailDirectorytextbox.Name = "CurrentMailDirectorytextbox";
            this.CurrentMailDirectorytextbox.Size = new System.Drawing.Size(216, 20);
            this.CurrentMailDirectorytextbox.TabIndex = 4;
            this.CurrentMailDirectorytextbox.TextChanged += new System.EventHandler(this.CurrentMailDirectorytextbox_TextChanged);
            this.CurrentMailDirectorytextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentMailDirectorytextbox_KeyDown);
            this.CurrentMailDirectorytextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CurrentMailDirectorytextbox_KeyPress);
            this.CurrentMailDirectorytextbox.Leave += new System.EventHandler(this.CurrentMailDirectorytextbox_Leave);
            // 
            // BrowsebtnMailDir
            // 
            this.BrowsebtnMailDir.Location = new System.Drawing.Point(269, 156);
            this.BrowsebtnMailDir.Name = "BrowsebtnMailDir";
            this.BrowsebtnMailDir.Size = new System.Drawing.Size(87, 23);
            this.BrowsebtnMailDir.TabIndex = 5;
            this.BrowsebtnMailDir.Text = "Browse...";
            this.toolTip1.SetToolTip(this.BrowsebtnMailDir, "Select a directory path.");
            this.BrowsebtnMailDir.UseVisualStyleBackColor = true;
            this.BrowsebtnMailDir.Click += new System.EventHandler(this.BrowsebtnMailDir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Server:";
            this.toolTip1.SetToolTip(this.label4, "The server the utility is pointed to for\r\nmessage handling.");
            // 
            // ServerValuelabel
            // 
            this.ServerValuelabel.AutoSize = true;
            this.ServerValuelabel.Location = new System.Drawing.Point(205, 119);
            this.ServerValuelabel.Name = "ServerValuelabel";
            this.ServerValuelabel.Size = new System.Drawing.Size(35, 13);
            this.ServerValuelabel.TabIndex = 36;
            this.ServerValuelabel.Text = "NULL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Total message count:";
            this.toolTip1.SetToolTip(this.label6, "Total number of XML files under\r\nthe current directory text box below.");
            // 
            // TotalMessageCountlabel
            // 
            this.TotalMessageCountlabel.AutoSize = true;
            this.TotalMessageCountlabel.Location = new System.Drawing.Point(250, 37);
            this.TotalMessageCountlabel.Name = "TotalMessageCountlabel";
            this.TotalMessageCountlabel.Size = new System.Drawing.Size(35, 13);
            this.TotalMessageCountlabel.TabIndex = 31;
            this.TotalMessageCountlabel.Text = "NULL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(9, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "|";
            // 
            // UpdateCountbtn
            // 
            this.UpdateCountbtn.Location = new System.Drawing.Point(302, 32);
            this.UpdateCountbtn.Name = "UpdateCountbtn";
            this.UpdateCountbtn.Size = new System.Drawing.Size(54, 23);
            this.UpdateCountbtn.TabIndex = 11;
            this.UpdateCountbtn.Text = "Update";
            this.toolTip1.SetToolTip(this.UpdateCountbtn, "Total message count updated against the current directory.  \r\nMail directory: NoR" +
                    "etry sub-folder.  \r\nOther directory: root folder.");
            this.UpdateCountbtn.UseVisualStyleBackColor = true;
            this.UpdateCountbtn.Click += new System.EventHandler(this.UpdateCountbtn_Click);
            // 
            // SpecifyXMLSyncchkbx
            // 
            this.SpecifyXMLSyncchkbx.AutoSize = true;
            this.SpecifyXMLSyncchkbx.Location = new System.Drawing.Point(122, 211);
            this.SpecifyXMLSyncchkbx.Name = "SpecifyXMLSyncchkbx";
            this.SpecifyXMLSyncchkbx.Size = new System.Drawing.Size(167, 17);
            this.SpecifyXMLSyncchkbx.TabIndex = 8;
            this.SpecifyXMLSyncchkbx.Text = "Sync to \'Current mail directory\'";
            this.toolTip1.SetToolTip(this.SpecifyXMLSyncchkbx, "Syncronize the above Current directory text box\r\nwith the below text box for the " +
                    "\"Browse to XML\"\r\noption.");
            this.SpecifyXMLSyncchkbx.UseVisualStyleBackColor = true;
            this.SpecifyXMLSyncchkbx.CheckedChanged += new System.EventHandler(this.SpecifyXMLSyncchkbx_CheckedChanged);
            this.SpecifyXMLSyncchkbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecifyXMLSyncchkbx_KeyPress);
            // 
            // OtherDirectory
            // 
            this.OtherDirectory.AutoSize = true;
            this.OtherDirectory.Location = new System.Drawing.Point(40, 182);
            this.OtherDirectory.Name = "OtherDirectory";
            this.OtherDirectory.Size = new System.Drawing.Size(97, 17);
            this.OtherDirectory.TabIndex = 6;
            this.OtherDirectory.Text = "Other Directory";
            this.toolTip1.SetToolTip(this.OtherDirectory, "Don\'t assume the XML files to be opened exist\r\nunder Mail\\NoRetry.  XML files wil" +
                    "l be loaded\r\nfrom the root of the Current other directory when this \r\noption is " +
                    "enabled.");
            this.OtherDirectory.UseVisualStyleBackColor = true;
            this.OtherDirectory.CheckedChanged += new System.EventHandler(this.OtherDirectory_CheckedChanged);
            this.OtherDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OtherDirectory_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = "";
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusFooter1,
            this.StatusFooter2});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.MinimumSize = new System.Drawing.Size(0, 35);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(380, 35);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.MouseHover += new System.EventHandler(this.statusStrip1_MouseHover);
            // 
            // StatusFooter1
            // 
            this.StatusFooter1.Name = "StatusFooter1";
            this.StatusFooter1.Size = new System.Drawing.Size(0, 0);
            // 
            // StatusFooter2
            // 
            this.StatusFooter2.Name = "StatusFooter2";
            this.StatusFooter2.Size = new System.Drawing.Size(10, 15);
            this.StatusFooter2.Text = " ";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.OtherDirectory);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.SpecifyXMLSyncchkbx);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.UpdateCountbtn);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label8);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TotalMessageCountlabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label6);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ServerValuelabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BrowsebtnMailDir);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CurrentMailDirectorytextbox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.SpecifyMessageQuantitytxtbx);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.SpecifyXMLtxtbx);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BrowsebtnToXML);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BrowseToXMLradiobutton);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.SpecifyQuantityradiobtn);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.AllMessagesradiobtn);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CurrentConfigurationtxt);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CurrentDirectorytxt);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Ok);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(380, 332);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(380, 332);
            this.toolStripContainer1.TabIndex = 38;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.AutoScroll = true;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStripContainer1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(380, 332);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(380, 367);
            this.toolStripContainer2.TabIndex = 39;
            this.toolStripContainer2.Text = "toolStripContainer2";
            this.toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // XMLRetrievalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 367);
            this.Controls.Add(this.toolStripContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "XMLRetrievalSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Retrieval Settings";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Label CurrentDirectorytxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CurrentConfigurationtxt;
        private System.Windows.Forms.RadioButton AllMessagesradiobtn;
        private System.Windows.Forms.RadioButton SpecifyQuantityradiobtn;
        private System.Windows.Forms.RadioButton BrowseToXMLradiobutton;
        private System.Windows.Forms.Button BrowsebtnToXML;
        private System.Windows.Forms.TextBox SpecifyXMLtxtbx;
        private System.Windows.Forms.TextBox SpecifyMessageQuantitytxtbx;
        private System.Windows.Forms.TextBox CurrentMailDirectorytextbox;
        private System.Windows.Forms.Button BrowsebtnMailDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ServerValuelabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TotalMessageCountlabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button UpdateCountbtn;
        private System.Windows.Forms.CheckBox SpecifyXMLSyncchkbx;
        private System.Windows.Forms.CheckBox OtherDirectory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusFooter1;
        private System.Windows.Forms.ToolStripStatusLabel StatusFooter2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}