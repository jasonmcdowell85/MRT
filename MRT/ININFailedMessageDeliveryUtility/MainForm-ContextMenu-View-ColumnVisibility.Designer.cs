namespace WindowsFormsApplication1
{
    partial class MainForm_ContextMenu_View_ColumnVisibility
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
            this.label1 = new System.Windows.Forms.Label();
            this.Closebtn = new System.Windows.Forms.Button();
            this.FromDisplay = new System.Windows.Forms.CheckBox();
            this.FromAddress = new System.Windows.Forms.CheckBox();
            this.ToDisplay = new System.Windows.Forms.CheckBox();
            this.ToAddress = new System.Windows.Forms.CheckBox();
            this.CCDisplay = new System.Windows.Forms.CheckBox();
            this.CCAddress = new System.Windows.Forms.CheckBox();
            this.BccDisplay = new System.Windows.Forms.CheckBox();
            this.BccAddress = new System.Windows.Forms.CheckBox();
            this.Subject = new System.Windows.Forms.CheckBox();
            this.BodyHTML = new System.Windows.Forms.CheckBox();
            this.BodyPlainText = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.CheckBox();
            this.XMLFile = new System.Windows.Forms.CheckBox();
            this.TransmitCount = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select columns to display";
            // 
            // Closebtn
            // 
            this.Closebtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Closebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Closebtn.Location = new System.Drawing.Point(74, 242);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(75, 23);
            this.Closebtn.TabIndex = 0;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // FromDisplay
            // 
            this.FromDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FromDisplay.AutoSize = true;
            this.FromDisplay.Location = new System.Drawing.Point(23, 87);
            this.FromDisplay.Name = "FromDisplay";
            this.FromDisplay.Size = new System.Drawing.Size(86, 17);
            this.FromDisplay.TabIndex = 1;
            this.FromDisplay.Text = "From-Display";
            this.FromDisplay.UseVisualStyleBackColor = true;
            this.FromDisplay.CheckedChanged += new System.EventHandler(this.FromDisplay_CheckedChanged);
            // 
            // FromAddress
            // 
            this.FromAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FromAddress.AutoSize = true;
            this.FromAddress.Location = new System.Drawing.Point(123, 87);
            this.FromAddress.Name = "FromAddress";
            this.FromAddress.Size = new System.Drawing.Size(90, 17);
            this.FromAddress.TabIndex = 2;
            this.FromAddress.Text = "From-Address";
            this.FromAddress.UseVisualStyleBackColor = true;
            this.FromAddress.CheckedChanged += new System.EventHandler(this.FromAddress_CheckedChanged);
            // 
            // ToDisplay
            // 
            this.ToDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ToDisplay.AutoSize = true;
            this.ToDisplay.Location = new System.Drawing.Point(23, 110);
            this.ToDisplay.Name = "ToDisplay";
            this.ToDisplay.Size = new System.Drawing.Size(76, 17);
            this.ToDisplay.TabIndex = 3;
            this.ToDisplay.Text = "To-Display";
            this.ToDisplay.UseVisualStyleBackColor = true;
            this.ToDisplay.CheckedChanged += new System.EventHandler(this.ToDisplay_CheckedChanged);
            // 
            // ToAddress
            // 
            this.ToAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ToAddress.AutoSize = true;
            this.ToAddress.Location = new System.Drawing.Point(123, 110);
            this.ToAddress.Name = "ToAddress";
            this.ToAddress.Size = new System.Drawing.Size(80, 17);
            this.ToAddress.TabIndex = 4;
            this.ToAddress.Text = "To-Address";
            this.ToAddress.UseVisualStyleBackColor = true;
            this.ToAddress.CheckedChanged += new System.EventHandler(this.ToAddress_CheckedChanged);
            // 
            // CCDisplay
            // 
            this.CCDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CCDisplay.AutoSize = true;
            this.CCDisplay.Location = new System.Drawing.Point(23, 133);
            this.CCDisplay.Name = "CCDisplay";
            this.CCDisplay.Size = new System.Drawing.Size(77, 17);
            this.CCDisplay.TabIndex = 5;
            this.CCDisplay.Text = "CC-Display";
            this.CCDisplay.UseVisualStyleBackColor = true;
            this.CCDisplay.CheckedChanged += new System.EventHandler(this.CCDisplay_CheckedChanged);
            // 
            // CCAddress
            // 
            this.CCAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CCAddress.AutoSize = true;
            this.CCAddress.Location = new System.Drawing.Point(123, 133);
            this.CCAddress.Name = "CCAddress";
            this.CCAddress.Size = new System.Drawing.Size(81, 17);
            this.CCAddress.TabIndex = 6;
            this.CCAddress.Text = "CC-Address";
            this.CCAddress.UseVisualStyleBackColor = true;
            this.CCAddress.CheckedChanged += new System.EventHandler(this.CCAddress_CheckedChanged);
            // 
            // BccDisplay
            // 
            this.BccDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BccDisplay.AutoSize = true;
            this.BccDisplay.Location = new System.Drawing.Point(23, 156);
            this.BccDisplay.Name = "BccDisplay";
            this.BccDisplay.Size = new System.Drawing.Size(82, 17);
            this.BccDisplay.TabIndex = 7;
            this.BccDisplay.Text = "Bcc-Display";
            this.BccDisplay.UseVisualStyleBackColor = true;
            this.BccDisplay.CheckedChanged += new System.EventHandler(this.BccDisplay_CheckedChanged);
            // 
            // BccAddress
            // 
            this.BccAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BccAddress.AutoSize = true;
            this.BccAddress.Location = new System.Drawing.Point(123, 156);
            this.BccAddress.Name = "BccAddress";
            this.BccAddress.Size = new System.Drawing.Size(86, 17);
            this.BccAddress.TabIndex = 8;
            this.BccAddress.Text = "Bcc-Address";
            this.BccAddress.UseVisualStyleBackColor = true;
            this.BccAddress.CheckedChanged += new System.EventHandler(this.BccAddress_CheckedChanged);
            // 
            // Subject
            // 
            this.Subject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Subject.AutoSize = true;
            this.Subject.Location = new System.Drawing.Point(23, 179);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(62, 17);
            this.Subject.TabIndex = 9;
            this.Subject.Text = "Subject";
            this.Subject.UseVisualStyleBackColor = true;
            this.Subject.CheckedChanged += new System.EventHandler(this.Subject_CheckedChanged);
            // 
            // BodyHTML
            // 
            this.BodyHTML.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BodyHTML.AutoSize = true;
            this.BodyHTML.Location = new System.Drawing.Point(123, 203);
            this.BodyHTML.Name = "BodyHTML";
            this.BodyHTML.Size = new System.Drawing.Size(83, 17);
            this.BodyHTML.TabIndex = 11;
            this.BodyHTML.Text = "Body-HTML";
            this.BodyHTML.UseVisualStyleBackColor = true;
            this.BodyHTML.CheckedChanged += new System.EventHandler(this.BodyHTML_CheckedChanged);
            // 
            // BodyPlainText
            // 
            this.BodyPlainText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BodyPlainText.AutoSize = true;
            this.BodyPlainText.Location = new System.Drawing.Point(23, 203);
            this.BodyPlainText.Name = "BodyPlainText";
            this.BodyPlainText.Size = new System.Drawing.Size(97, 17);
            this.BodyPlainText.TabIndex = 10;
            this.BodyPlainText.Text = "Body-PlainText";
            this.BodyPlainText.UseVisualStyleBackColor = true;
            this.BodyPlainText.CheckedChanged += new System.EventHandler(this.BodyPlainText_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(real-time)";
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(23, 64);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(63, 17);
            this.Number.TabIndex = 13;
            this.Number.Text = "Number";
            this.Number.UseVisualStyleBackColor = true;
            this.Number.CheckedChanged += new System.EventHandler(this.Number_CheckedChanged);
            // 
            // XMLFile
            // 
            this.XMLFile.AutoSize = true;
            this.XMLFile.Location = new System.Drawing.Point(123, 64);
            this.XMLFile.Name = "XMLFile";
            this.XMLFile.Size = new System.Drawing.Size(64, 17);
            this.XMLFile.TabIndex = 14;
            this.XMLFile.Text = "XMLFile";
            this.XMLFile.UseVisualStyleBackColor = true;
            this.XMLFile.CheckedChanged += new System.EventHandler(this.XMLFile_CheckedChanged);
            // 
            // TransmitCount
            // 
            this.TransmitCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TransmitCount.AutoSize = true;
            this.TransmitCount.Location = new System.Drawing.Point(123, 179);
            this.TransmitCount.Name = "TransmitCount";
            this.TransmitCount.Size = new System.Drawing.Size(94, 17);
            this.TransmitCount.TabIndex = 15;
            this.TransmitCount.Text = "TransmitCount";
            this.TransmitCount.UseVisualStyleBackColor = true;
            this.TransmitCount.CheckedChanged += new System.EventHandler(this.TransmitCount_CheckedChanged);
            // 
            // MainForm_ContextMenu_View_ColumnVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 277);
            this.Controls.Add(this.TransmitCount);
            this.Controls.Add(this.XMLFile);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BodyPlainText);
            this.Controls.Add(this.BodyHTML);
            this.Controls.Add(this.Subject);
            this.Controls.Add(this.BccAddress);
            this.Controls.Add(this.BccDisplay);
            this.Controls.Add(this.CCAddress);
            this.Controls.Add(this.CCDisplay);
            this.Controls.Add(this.ToAddress);
            this.Controls.Add(this.ToDisplay);
            this.Controls.Add(this.FromAddress);
            this.Controls.Add(this.FromDisplay);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm_ContextMenu_View_ColumnVisibility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Column visibility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.CheckBox FromDisplay;
        private System.Windows.Forms.CheckBox FromAddress;
        private System.Windows.Forms.CheckBox ToDisplay;
        private System.Windows.Forms.CheckBox ToAddress;
        private System.Windows.Forms.CheckBox CCDisplay;
        private System.Windows.Forms.CheckBox CCAddress;
        private System.Windows.Forms.CheckBox BccDisplay;
        private System.Windows.Forms.CheckBox BccAddress;
        private System.Windows.Forms.CheckBox Subject;
        private System.Windows.Forms.CheckBox BodyHTML;
        private System.Windows.Forms.CheckBox BodyPlainText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Number;
        private System.Windows.Forms.CheckBox XMLFile;
        private System.Windows.Forms.CheckBox TransmitCount;
    }
}