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
    public partial class MainForm_ContextMenu_View_ColumnVisibility : Form
    {
        private MainForm MainFormPassedIn;  // Instantiate the MainForm object to be used throughout this form only.
        public MainForm_ContextMenu_View_ColumnVisibility(MainForm MainForm)
        {
            InitializeComponent();
            MainFormPassedIn = MainForm;  // Copy MainForm to MainFormPassedIn
            InitializeCheckboxes();  // Check the boxes in this form that need to be enabled as per the main form column visibility
        }
        public void InitializeCheckboxes() 
        {
            // Initialize check box selection (find which should be pre-checked)
            if(MainFormPassedIn.IsNumberChecked() == true) { Number.Checked = true; }
            if(MainFormPassedIn.IsXMLFileChecked() == true) { XMLFile.Checked = true; }
            if(MainFormPassedIn.IsFromDisplayChecked() == true) { FromDisplay.Checked = true; } 
            if(MainFormPassedIn.IsFromAddressChecked() == true){  FromAddress.Checked = true; } 
            if(MainFormPassedIn.IsToDisplayChecked() == true){  ToDisplay.Checked = true; } 
            if(MainFormPassedIn.IsToAddressChecked() == true){  ToAddress.Checked = true; } 
            if(MainFormPassedIn.IsCCDisplayChecked() == true){  CCDisplay.Checked = true; } 
            if(MainFormPassedIn.IsCCAddressChecked() == true){  CCAddress.Checked = true; } 
            if(MainFormPassedIn.IsBccDisplayChecked() == true){  BccDisplay.Checked = true; } 
            if(MainFormPassedIn.IsBccAddressChecked() == true){  BccAddress.Checked = true; } 
            if(MainFormPassedIn.IsSubjectChecked() == true){  Subject.Checked = true; } 
            if(MainFormPassedIn.IsBodyPlainTextChecked() == true){ BodyPlainText.Checked = true; } 
            if(MainFormPassedIn.IsBodyHTMLChecked() == true){  BodyHTML.Checked = true;}
            if (MainFormPassedIn.IsTransmitCountChecked() == true) { TransmitCount.Checked = true; }
        }
        private void FromDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (FromDisplay.Checked == true)  // FromDisplay was checked
            {
                MainFormPassedIn.ShowFromDisplay();  // Show the FromDisplay column
            }
            else if (FromDisplay.Checked == false)  // FromDisplay was unchecked
            {
                MainFormPassedIn.HideFromDisplay(); // Hide the FromDisplay column
            }
        }
        private void FromAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (FromAddress.Checked == true)  // FromAddress was checked
            {
                MainFormPassedIn.ShowFromAddress();  // Show the FromAddress column
            }
            else if (FromAddress.Checked == false)  // FromAddress was unchecked
            {
                MainFormPassedIn.HideFromAddress(); // Hide the FromAddress column
            }
        }
        private void ToDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (ToDisplay.Checked == true)  // ToDisplay was checked
            {
                MainFormPassedIn.ShowToDisplay();  // Show the ToDisplay column
            }
            else if (ToDisplay.Checked == false)  // ToDisplay was unchecked
            {
                MainFormPassedIn.HideToDisplay(); // Hide the ToDisplay column
            }
        }
        private void ToAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (ToAddress.Checked == true)  // ToAddress was checked
            {
                MainFormPassedIn.ShowToAddress();  // Show the ToAddress column
            }
            else if (ToAddress.Checked == false)  // ToAddress was unchecked
            {
                MainFormPassedIn.HideToAddress(); // Hide the ToAddress column
            }
        }
        private void CCDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (CCDisplay.Checked == true)  // CCDisplay was checked
            {
                MainFormPassedIn.ShowCCDisplay();  // Show the CCDisplay column
            }
            else if (CCDisplay.Checked == false)  // CCDisplay was unchecked
            {
                MainFormPassedIn.HideCCDisplay(); // Hide the CCDisplay column
            }
        }
        private void CCAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (CCAddress.Checked == true)  // CCAddress was checked
            {
                MainFormPassedIn.ShowCCAddress();  // Show the CCAddress column
            }
            else if (CCAddress.Checked == false)  // CCAddress was unchecked
            {
                MainFormPassedIn.HideCCAddress(); // Hide the CCAddress column
            }
        }
        private void BccDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (BccDisplay.Checked == true)  // BccDisplay was checked
            {
                MainFormPassedIn.ShowBccDisplay();  // Show the BccDisplay column
            }
            else if (BccDisplay.Checked == false)  // BccDisplay was unchecked
            {
                MainFormPassedIn.HideBccDisplay(); // Hide the BccDisplay column
            }
        }
        private void BccAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (BccAddress.Checked == true)  // BccAddress was checked
            {
                MainFormPassedIn.ShowBccAddress();  // Show the BccAddress column
            }
            else if (BccAddress.Checked == false)  // BccAddress was unchecked
            {
                MainFormPassedIn.HideBccAddress(); // Hide the BccAddress column
            }
        }
        private void Subject_CheckedChanged(object sender, EventArgs e)
        {
            if (Subject.Checked == true)  // Subject was checked
            {
                MainFormPassedIn.ShowSubject();  // Show the Subject column
            }
            else if (Subject.Checked == false)  // Subject was unchecked
            {
                MainFormPassedIn.HideSubject(); // Hide the Subject column
            }
        }
        private void BodyPlainText_CheckedChanged(object sender, EventArgs e)
        {
            if (BodyPlainText.Checked == true)  // BodyPlainText was checked
            {
                MainFormPassedIn.ShowBodyPlainText();  // Show the BodyPlainText column
            }
            else if (BodyPlainText.Checked == false)  // BodyPlainText was unchecked
            {
                MainFormPassedIn.HideBodyPlainText(); // Hide the BodyPlainText column
            }
        }
        private void BodyHTML_CheckedChanged(object sender, EventArgs e)
        {
            if (BodyHTML.Checked == true)  // BodyHTML was checked
            {
                MainFormPassedIn.ShowBodyHTML();  // Show the BodyHTML column
            }
            else if (BodyHTML.Checked == false)  // BodyHTML was unchecked
            {
                MainFormPassedIn.HideBodyHTML(); // Hide the BodyHTML column
            }
        }
        private void Number_CheckedChanged(object sender, EventArgs e)
        {
            if (Number.Checked == true)  // Number was checked
            {
                MainFormPassedIn.ShowNumber();  // Show the XMLFile column
            }
            else if (Number.Checked == false)   // Number was unchecked
            {
                MainFormPassedIn.HideNumber();  // Hide the XMLFile column
            }
        }
        private void XMLFile_CheckedChanged(object sender, EventArgs e)
        {
            if (XMLFile.Checked == true)  // Number was checked
            {
                MainFormPassedIn.ShowXMLFile();  // Show the XMLFile column
            }
            else if (XMLFile.Checked == false)   // Number was unchecked
            {
                MainFormPassedIn.HideXMLFile();  // Hide the XMLFile column
            }
        }

        private void TransmitCount_CheckedChanged(object sender, EventArgs e)
        {
            if (TransmitCount.Checked == true)  // Number was checked
            {
                MainFormPassedIn.ShowTransmitCount();  // Show the TransmitCount column
            }
            else if (TransmitCount.Checked == false)   // Number was unchecked
            {
                MainFormPassedIn.HideTransmitCount();  // Hide the TransmitCount column
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();  // Close the form
            this.Dispose();  // Dispose the form (clean up resources using it)
        }
    }
}
