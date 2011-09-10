namespace WindowsFormsApplication1
{
    partial class MainForm_MessageBody
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
            this.MessageBodytxtbx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PopOutBody = new System.Windows.Forms.CheckBox();
            this.HTMLBodyckbx = new System.Windows.Forms.CheckBox();
            this.PlainTextBodyckbx = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageBodytxtbx
            // 
            this.MessageBodytxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageBodytxtbx.Location = new System.Drawing.Point(12, 12);
            this.MessageBodytxtbx.Multiline = true;
            this.MessageBodytxtbx.Name = "MessageBodytxtbx";
            this.MessageBodytxtbx.ReadOnly = true;
            this.MessageBodytxtbx.Size = new System.Drawing.Size(1075, 397);
            this.MessageBodytxtbx.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PopOutBody);
            this.panel1.Controls.Add(this.HTMLBodyckbx);
            this.panel1.Controls.Add(this.PlainTextBodyckbx);
            this.panel1.Location = new System.Drawing.Point(1093, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 111);
            this.panel1.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Message body options";
            // 
            // PopOutBody
            // 
            this.PopOutBody.AutoSize = true;
            this.PopOutBody.Location = new System.Drawing.Point(16, 89);
            this.PopOutBody.Name = "PopOutBody";
            this.PopOutBody.Size = new System.Drawing.Size(89, 17);
            this.PopOutBody.TabIndex = 17;
            this.PopOutBody.Text = "Pop out body";
            this.PopOutBody.UseVisualStyleBackColor = true;
            // 
            // HTMLBodyckbx
            // 
            this.HTMLBodyckbx.AutoSize = true;
            this.HTMLBodyckbx.Location = new System.Drawing.Point(16, 55);
            this.HTMLBodyckbx.Name = "HTMLBodyckbx";
            this.HTMLBodyckbx.Size = new System.Drawing.Size(82, 17);
            this.HTMLBodyckbx.TabIndex = 16;
            this.HTMLBodyckbx.Text = "HTML body";
            this.HTMLBodyckbx.UseVisualStyleBackColor = true;
            // 
            // PlainTextBodyckbx
            // 
            this.PlainTextBodyckbx.AutoSize = true;
            this.PlainTextBodyckbx.Checked = true;
            this.PlainTextBodyckbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlainTextBodyckbx.Location = new System.Drawing.Point(16, 32);
            this.PlainTextBodyckbx.Name = "PlainTextBodyckbx";
            this.PlainTextBodyckbx.Size = new System.Drawing.Size(95, 17);
            this.PlainTextBodyckbx.TabIndex = 15;
            this.PlainTextBodyckbx.Text = "Plain text body";
            this.PlainTextBodyckbx.UseVisualStyleBackColor = true;
            // 
            // MainForm_MessageBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 421);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MessageBodytxtbx);
            this.Name = "MainForm_MessageBody";
            this.Text = "Message body";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_MessageBody_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBodytxtbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox PopOutBody;
        private System.Windows.Forms.CheckBox HTMLBodyckbx;
        private System.Windows.Forms.CheckBox PlainTextBodyckbx;
    }
}