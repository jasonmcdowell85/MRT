namespace WindowsFormsApplication1
{
    partial class MailDirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailDirForm));
            this.Okbtn = new System.Windows.Forms.Button();
            this.MailDirtxtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Help = new System.Windows.Forms.Button();
            this.Browsebtn = new System.Windows.Forms.Button();
            this.OtherDirectory = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Okbtn
            // 
            this.Okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Okbtn.Enabled = false;
            this.Okbtn.Location = new System.Drawing.Point(134, 99);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(97, 26);
            this.Okbtn.TabIndex = 3;
            this.Okbtn.Text = "Ok";
            this.toolTip1.SetToolTip(this.Okbtn, "Submit the directory path to start with.");
            this.Okbtn.UseVisualStyleBackColor = true;
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            // 
            // MailDirtxtbx
            // 
            this.MailDirtxtbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MailDirtxtbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.MailDirtxtbx.Location = new System.Drawing.Point(25, 58);
            this.MailDirtxtbx.Name = "MailDirtxtbx";
            this.MailDirtxtbx.Size = new System.Drawing.Size(237, 20);
            this.MailDirtxtbx.TabIndex = 0;
            this.MailDirtxtbx.Text = "e.g., D:\\I3\\IC\\Mail or \\\\servername\\Mail";
            this.MailDirtxtbx.TextChanged += new System.EventHandler(this.MailDirtxtbx_TextChanged);
            this.MailDirtxtbx.Enter += new System.EventHandler(this.Okbtn_Click);
            this.MailDirtxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MailDirtxtbx_KeyDown);
            this.MailDirtxtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MailDirtxtbx_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter the full path to the IC Mail directory:";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // Help
            // 
            this.Help.Cursor = System.Windows.Forms.Cursors.Help;
            this.Help.Location = new System.Drawing.Point(321, 16);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(37, 28);
            this.Help.TabIndex = 4;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Browsebtn
            // 
            this.Browsebtn.Location = new System.Drawing.Point(268, 54);
            this.Browsebtn.Name = "Browsebtn";
            this.Browsebtn.Size = new System.Drawing.Size(90, 26);
            this.Browsebtn.TabIndex = 1;
            this.Browsebtn.Text = "Browse...";
            this.toolTip1.SetToolTip(this.Browsebtn, "Select a directory path.");
            this.Browsebtn.UseVisualStyleBackColor = true;
            this.Browsebtn.Click += new System.EventHandler(this.Browsebtn_Click);
            // 
            // OtherDirectory
            // 
            this.OtherDirectory.AutoSize = true;
            this.OtherDirectory.Location = new System.Drawing.Point(25, 80);
            this.OtherDirectory.Name = "OtherDirectory";
            this.OtherDirectory.Size = new System.Drawing.Size(97, 17);
            this.OtherDirectory.TabIndex = 2;
            this.OtherDirectory.Text = "Other Directory";
            this.toolTip1.SetToolTip(this.OtherDirectory, resources.GetString("OtherDirectory.ToolTip"));
            this.OtherDirectory.UseVisualStyleBackColor = true;
            this.OtherDirectory.CheckedChanged += new System.EventHandler(this.OtherDirectory_CheckedChanged);
            this.OtherDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OtherDirectory_KeyPress);
            // 
            // MailDirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 147);
            this.Controls.Add(this.OtherDirectory);
            this.Controls.Add(this.Browsebtn);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MailDirtxtbx);
            this.Controls.Add(this.Okbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MailDirForm";
            this.Text = "Mail directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Okbtn;
        private System.Windows.Forms.TextBox MailDirtxtbx;  
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Browsebtn;
        private System.Windows.Forms.CheckBox OtherDirectory;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}