namespace WindowsFormsApplication1
{
    partial class MainForm_LoadXMLProgressBar
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
            this.ProgressBarXMLLoad = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProgressBarXMLLoad
            // 
            this.ProgressBarXMLLoad.Location = new System.Drawing.Point(39, 23);
            this.ProgressBarXMLLoad.Name = "ProgressBarXMLLoad";
            this.ProgressBarXMLLoad.Size = new System.Drawing.Size(436, 23);
            this.ProgressBarXMLLoad.TabIndex = 0;
            // 
            // MainForm_LoadXMLProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 67);
            this.Controls.Add(this.ProgressBarXMLLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm_LoadXMLProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm_LoadXMLProgressBar";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBarXMLLoad;
    }
}