using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm_MessageBody : Form
    {
        //MainForm MainFormcopy = new MainForm();
        public MainForm_MessageBody()
        {
            InitializeComponent();
        }
        public MainForm_MessageBody(MainForm MainFormPassedin)
        {
        //    MainFormcopy = MainFormPassedin;
            InitializeComponent();
        }
        public void SetMessageBody(string MessageBodytemp)
        {
            MessageBodytxtbx.Text = MessageBodytemp;
        }

        private void MainForm_MessageBody_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   MainFormcopy.UncheckPopOutBodychkbxAndHidePanel();  // As the popped out message body form is closing, uncheck the option on the mainform and uncheck the hide panel chkbx too.
            e.Cancel = true;  // Don't allow the form to actually close and be disposed, just make it invisible
            this.Visible = false;  // Hide this form.
        }
    }
}
