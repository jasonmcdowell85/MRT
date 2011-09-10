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
    public partial class MainForm_RetryMessages_Confirm : Form
    {
        string MoveFrom;
        string MoveTo;
        public MainForm_RetryMessages_Confirm(string MoveFromtemp, string MoveTotemp)
        {
            InitializeComponent();
            MoveFrom = MoveFromtemp;
            MoveTo = MoveTotemp;
            MoveMessagesFromlabel.Text = MoveFrom;
            MoveMessagesTotxtbx.Text = MoveTo;
        }
        public string GetMoveTo()
        {
            return MoveTo;
        }
        private void RetryMessagesbtn_Click(object sender, EventArgs e)
        {
            MoveTo = MoveMessagesTotxtbx.Text;
        }

        private void ChangeDirectorybtn_Click(object sender, EventArgs e)
        {

        }

    }
}
