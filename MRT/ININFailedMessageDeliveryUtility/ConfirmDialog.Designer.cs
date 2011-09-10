namespace WindowsFormsApplication1
{
    partial class ConfirmDialog
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
            this.Yesbtn = new System.Windows.Forms.Button();
            this.Nobtn = new System.Windows.Forms.Button();
            this.Messagelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Yesbtn
            // 
            this.Yesbtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Yesbtn.Location = new System.Drawing.Point(42, 79);
            this.Yesbtn.Name = "Yesbtn";
            this.Yesbtn.Size = new System.Drawing.Size(72, 38);
            this.Yesbtn.TabIndex = 1;
            this.Yesbtn.Text = "Yes";
            this.Yesbtn.UseVisualStyleBackColor = true;
            // 
            // Nobtn
            // 
            this.Nobtn.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Nobtn.Location = new System.Drawing.Point(134, 79);
            this.Nobtn.Name = "Nobtn";
            this.Nobtn.Size = new System.Drawing.Size(72, 38);
            this.Nobtn.TabIndex = 0;
            this.Nobtn.Text = "No";
            this.Nobtn.UseVisualStyleBackColor = true;
            // 
            // Messagelabel
            // 
            this.Messagelabel.AutoSize = true;
            this.Messagelabel.Location = new System.Drawing.Point(12, 34);
            this.Messagelabel.Name = "Messagelabel";
            this.Messagelabel.Size = new System.Drawing.Size(235, 13);
            this.Messagelabel.TabIndex = 2;
            this.Messagelabel.Text = "Are you sure you\'d like to perform this operation?";
            // 
            // ConfirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 140);
            this.Controls.Add(this.Messagelabel);
            this.Controls.Add(this.Nobtn);
            this.Controls.Add(this.Yesbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfirmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Yesbtn;
        private System.Windows.Forms.Button Nobtn;
        private System.Windows.Forms.Label Messagelabel;
    }
}