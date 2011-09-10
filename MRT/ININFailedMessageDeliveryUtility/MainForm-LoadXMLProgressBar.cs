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
    public partial class MainForm_LoadXMLProgressBar : Form
    {
        int TotalCount = 0;  // Total XML count to load into the data set
        public MainForm_LoadXMLProgressBar()
        {
            InitializeComponent();
        }
        public void ProgressBarXMLLoadUpdate(int ProgressValue)
        {
            ProgressBarXMLLoad.Value = ProgressValue;
        }
    }
}
