namespace WindowsFormsApplication1
{
    partial class MainForm_RetryMessages_Confirm
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
            this.RetryMessagesbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MoveMessagesTotxtbx = new System.Windows.Forms.TextBox();
            this.MoveMessagesFromlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RetryMessagesbtn
            // 
            this.RetryMessagesbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RetryMessagesbtn.Location = new System.Drawing.Point(156, 99);
            this.RetryMessagesbtn.Name = "RetryMessagesbtn";
            this.RetryMessagesbtn.Size = new System.Drawing.Size(104, 23);
            this.RetryMessagesbtn.TabIndex = 0;
            this.RetryMessagesbtn.Text = "Retry Messages";
            this.RetryMessagesbtn.UseVisualStyleBackColor = true;
            this.RetryMessagesbtn.Click += new System.EventHandler(this.RetryMessagesbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbtn.Location = new System.Drawing.Point(262, 99);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(101, 23);
            this.Cancelbtn.TabIndex = 1;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Moving messages from:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Moving messages to:";
            // 
            // MoveMessagesTotxtbx
            // 
            this.MoveMessagesTotxtbx.Location = new System.Drawing.Point(259, 49);
            this.MoveMessagesTotxtbx.Name = "MoveMessagesTotxtbx";
            this.MoveMessagesTotxtbx.Size = new System.Drawing.Size(249, 20);
            this.MoveMessagesTotxtbx.TabIndex = 6;
            // 
            // MoveMessagesFromlabel
            // 
            this.MoveMessagesFromlabel.AutoSize = true;
            this.MoveMessagesFromlabel.Location = new System.Drawing.Point(17, 53);
            this.MoveMessagesFromlabel.Name = "MoveMessagesFromlabel";
            this.MoveMessagesFromlabel.Size = new System.Drawing.Size(28, 13);
            this.MoveMessagesFromlabel.TabIndex = 8;
            this.MoveMessagesFromlabel.Text = "path";
            // 
            // MainForm_RetryMessages_Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 134);
            this.Controls.Add(this.MoveMessagesFromlabel);
            this.Controls.Add(this.MoveMessagesTotxtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.RetryMessagesbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm_RetryMessages_Confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm Retry Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RetryMessagesbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MoveMessagesTotxtbx;
        private System.Windows.Forms.Label MoveMessagesFromlabel;
    }
}