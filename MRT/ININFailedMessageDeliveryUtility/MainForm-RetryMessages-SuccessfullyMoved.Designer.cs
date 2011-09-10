namespace WindowsFormsApplication1
{
    partial class MainForm_RetryMessages_SuccessfullyMoved
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
            this.SuccessfullyMovedMessagestxtbx = new System.Windows.Forms.TextBox();
            this.MessagesMovedStatuslabel = new System.Windows.Forms.Label();
            this.outoflabel = new System.Windows.Forms.Label();
            this.TotalMessagesToMovelabel = new System.Windows.Forms.Label();
            this.messagesmovedlabel = new System.Windows.Forms.Label();
            this.CancelRetrybtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SuccessfullyMovedMessagestxtbx
            // 
            this.SuccessfullyMovedMessagestxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SuccessfullyMovedMessagestxtbx.Location = new System.Drawing.Point(33, 29);
            this.SuccessfullyMovedMessagestxtbx.Multiline = true;
            this.SuccessfullyMovedMessagestxtbx.Name = "SuccessfullyMovedMessagestxtbx";
            this.SuccessfullyMovedMessagestxtbx.ReadOnly = true;
            this.SuccessfullyMovedMessagestxtbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SuccessfullyMovedMessagestxtbx.Size = new System.Drawing.Size(483, 406);
            this.SuccessfullyMovedMessagestxtbx.TabIndex = 0;
            this.SuccessfullyMovedMessagestxtbx.TextChanged += new System.EventHandler(this.SuccessfullyMovedMessagestxtbx_TextChanged);
            // 
            // MessagesMovedStatuslabel
            // 
            this.MessagesMovedStatuslabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MessagesMovedStatuslabel.AutoSize = true;
            this.MessagesMovedStatuslabel.Location = new System.Drawing.Point(179, 439);
            this.MessagesMovedStatuslabel.Name = "MessagesMovedStatuslabel";
            this.MessagesMovedStatuslabel.Size = new System.Drawing.Size(19, 13);
            this.MessagesMovedStatuslabel.TabIndex = 1;
            this.MessagesMovedStatuslabel.Text = "[0]";
            this.MessagesMovedStatuslabel.Visible = false;
            // 
            // outoflabel
            // 
            this.outoflabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.outoflabel.AutoSize = true;
            this.outoflabel.Location = new System.Drawing.Point(220, 439);
            this.outoflabel.Name = "outoflabel";
            this.outoflabel.Size = new System.Drawing.Size(34, 13);
            this.outoflabel.TabIndex = 2;
            this.outoflabel.Text = "out of";
            this.outoflabel.Visible = false;
            // 
            // TotalMessagesToMovelabel
            // 
            this.TotalMessagesToMovelabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TotalMessagesToMovelabel.AutoSize = true;
            this.TotalMessagesToMovelabel.Location = new System.Drawing.Point(260, 439);
            this.TotalMessagesToMovelabel.Name = "TotalMessagesToMovelabel";
            this.TotalMessagesToMovelabel.Size = new System.Drawing.Size(39, 13);
            this.TotalMessagesToMovelabel.TabIndex = 3;
            this.TotalMessagesToMovelabel.Text = "[ total ]";
            this.TotalMessagesToMovelabel.Visible = false;
            // 
            // messagesmovedlabel
            // 
            this.messagesmovedlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.messagesmovedlabel.AutoSize = true;
            this.messagesmovedlabel.Location = new System.Drawing.Point(316, 439);
            this.messagesmovedlabel.Name = "messagesmovedlabel";
            this.messagesmovedlabel.Size = new System.Drawing.Size(89, 13);
            this.messagesmovedlabel.TabIndex = 4;
            this.messagesmovedlabel.Text = "messages moved";
            this.messagesmovedlabel.Visible = false;
            // 
            // CancelRetrybtn
            // 
            this.CancelRetrybtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelRetrybtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelRetrybtn.Location = new System.Drawing.Point(431, 436);
            this.CancelRetrybtn.Name = "CancelRetrybtn";
            this.CancelRetrybtn.Size = new System.Drawing.Size(85, 23);
            this.CancelRetrybtn.TabIndex = 5;
            this.CancelRetrybtn.Text = "Cancel retry";
            this.CancelRetrybtn.UseVisualStyleBackColor = true;
            this.CancelRetrybtn.Visible = false;
            // 
            // MainForm_RetryMessages_SuccessfullyMoved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 461);
            this.Controls.Add(this.CancelRetrybtn);
            this.Controls.Add(this.messagesmovedlabel);
            this.Controls.Add(this.TotalMessagesToMovelabel);
            this.Controls.Add(this.outoflabel);
            this.Controls.Add(this.MessagesMovedStatuslabel);
            this.Controls.Add(this.SuccessfullyMovedMessagestxtbx);
            this.Name = "MainForm_RetryMessages_SuccessfullyMoved";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Successfully moved messages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SuccessfullyMovedMessagestxtbx;
        private System.Windows.Forms.Label MessagesMovedStatuslabel;
        private System.Windows.Forms.Label outoflabel;
        private System.Windows.Forms.Label TotalMessagesToMovelabel;
        private System.Windows.Forms.Label messagesmovedlabel;
        private System.Windows.Forms.Button CancelRetrybtn;
    }
}