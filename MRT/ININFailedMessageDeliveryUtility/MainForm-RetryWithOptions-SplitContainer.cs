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
    public partial class MainForm_RetryWithOptions : Form
    {
        public MainForm_RetryWithOptions()
        {
            InitializeComponent();
            //ChangeToBasicOptions();
        }
        private void BasicAdvancedOptionbtn_Click(object sender, EventArgs e)
        {
            // When clicked, grow the length to expose the advanced section (move retry confirmation down)
            // Size of the form will be  537, 451
            if (BasicAdvancedOptionbtn.Text == "Advanced")
            {
                ChangeToAdvancedOptions();
                BasicAdvancedOptionbtn.Text = "Basic";
            }
            else if (BasicAdvancedOptionbtn.Text == "Basic")
            {
                ChangeToBasicOptions();
                BasicAdvancedOptionbtn.Text = "Advanced";
            }
        }
        private void ChangeToAdvancedOptions()
        {
            // Grow the length to expose the advanced section (move retry confirmation down); Size of the form will be 537, 451
            //this.Width = 537;
            //this.Height = 451;
            //this.Size = new System.Drawing.Size(537, 451);
            //this.Size = new Size(537, 451);
            splitContainer1.Panel1Collapsed = false;
        }
        private void ChangeToBasicOptions()
        {
            // Shrink the form to only show the 'basic' options to retry; Size of the form will be 537, 226
            //this.Width = 537;
            //this.Height = 226;
            //this.Size = new Size(537, 226);
            splitContainer1.Panel1Collapsed = true;
        }
    }
}



