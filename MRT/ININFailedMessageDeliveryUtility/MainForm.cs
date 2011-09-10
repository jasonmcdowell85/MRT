using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Xml.Xsl;


namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        #region DeclareMainVariables
        int[] CacheSelectedItemsIndexInGridView = new int[0];  // Cache the selected row index list, so that I don't need to grab live index numbers from the grid view 
        StringReader theReader = new StringReader("");  // To be used to store the XMLData[x] in
        // Stuff XML node variables above into this to be displayed in the data grid table
        string[] XMLData = new string[0];  // Default to array size of 0
        DataSet theDataSet = new DataSet();  // Instantiate the data set to read the XML data (XMLData[x]) into
        // Instantiate the main DataView which will have another dataview pcopied to it containing the table contained in the dataset.
        DataView MainDataView = new DataView();
        // Create a BindingSource which will have its DataSource property set to the DataView.
        BindingSource MainBindingSource = new BindingSource();
        string[] XMLArrayList;  // List of path+names of XML files of non-retries messages
        ArrayList RetriedXMLMessages = new ArrayList();  // List of path+names of XML files (from, to) that have been retried to confirm if they were delivered (not in NoRetry, Retry, Processing, Outbox)
        string XMLFilterOption;  // 1="All"; 2="Specify quantity"; 3="BrowseToXML"
        string OtherDirectoryOption;  // "True"; "False" - assume \NoRetry\
        string WorkingXMLRootDirectory;  // if other dir option, then entered value; if not other dir, then \NoRetry; if browsetoxml then dir of that xml
        string EnteredDirectory;  // The directory the user entered in the MailDirForm
        #endregion // DeclareMainVariables

        
        MainForm_MessageBody MessageBodyForm = new MainForm_MessageBody();  // Instantiate this form to be used to pop the message body to.  Upper-hand close button won't dispose (keep this object).
        
        // (XMLFileListArray, XMLRetrievalSettingXMLFilterOption, XMLRetrievalSettingOtherDirectory, WorkingXMLRootDirectory)
        public MainForm(string[] XMLArrayListtemp, string XMLFilterOptiontemp, string OtherDirectoryOptiontemp, string WorkingXMLRootDirectorytemp, string EnteredDirectorytemp) 
        {
            InitializeComponent();

            XMLArrayList = XMLArrayListtemp;
            XMLFilterOption = XMLFilterOptiontemp;
            OtherDirectoryOption = OtherDirectoryOptiontemp;
            WorkingXMLRootDirectory = WorkingXMLRootDirectorytemp;
            EnteredDirectory = EnteredDirectorytemp;
            
            XMLArrayListTODataGrid(XMLArrayList);  // Load the XML file(s) nodes into the data set and data grid  
            // Initialize column visibility (default).  By default, every column will be displayed.  Hide columns that should not default to viewable.
            HideXMLFile();
            HideNumber();
            HideFromAddress();           
            HideToAddress();
            HideCCAddress();
            HideBccAddress();
            HideBodyHTML();
            HideTransmitCount();
            
            HideBottomPanelchkbx.Enabled = false;  // Initially disallow the ability to hide the bottom panel since the message body won't be popped out to a new form by default.

        }
        public MainForm()  // Used to instantiate a form in other forms that don't need to pass input into this form.
        {
            InitializeComponent();  
        }
        // The input is the array list of XML file path+name(s).  This method parses the nodes for specific important data and loads it into a data set which loads the datagrid.
        public void XMLArrayListTODataGrid(string[] XMLArrayListtemp)
        {
            XMLArrayList = XMLArrayListtemp;
            string Subject = "NULL";
            string FromDisplay = "NULL";
            string FromAddress = "NULL";
            string[] ToDisplay = new string [10];  // hardcode 10 for now
            string[] ToAddress = new string [10];  // hardcode 10 for now
            //string ToDisplay2 = "NULL";
            //string ToAddress2 = "NULL";
            string[] CCDisplay = new string [10];  // hardcode 10 for now
            string[] CCAddress = new string [10];  // hardcode 10 for now
            //string CCDisplay2 = "NULL";
            //string CCAddress2 = "NULL";
            string[] BccDisplay = new string[10];  // hardcode 10 for now
            string[] BccAddress = new string[10];  // hardcode 10 for now
            //string BccDisplay2 = "NULL";
            //string BccAddress2 = "NULL";
            string TransmitCount = "NULL";
            string MessageFormat1temp = "NULL";  // If it equals "text/plain" save to PlainTextFormat
            string Base64Body1temp = "NULL";  // If MessageFormat1temp equals "text/plain" save to PlainTextBodyBase64 
            string MessageFormat2temp = "NULL";  // If it equals "text/html" save to HTMLFormat
            string Base64Body2temp = "NULL";  // If MessageFormat2temp equals "text/html"  save to HTMLBodyBase64

            bool PlainTextFormat = false; // "text/plain"
            string PlainTextBodyBase64 = "NULL";
            string PlainTextBodyASCII = "NULL";  // PlainTextBodyBase64 decoded
            bool HTMLFormat = false;  // "text/html"
            string HTMLBodyBase64 = "NULL";  
            string HTMLBodyASCII = "NULL";  // HTMLBodyBase64 decoded

            int XMLArrayListLength = XMLArrayList.Length;  // Determine the number of XML files passed into the form
            XMLData = new string [XMLArrayListLength];  // Stuff XML node variables above into this to be displayed in the data grid table
            TraceLogging.Info("Number of XML files to load: " + XMLArrayListLength);

            
            // Pop a new form to be used to display the status (ProgressBar) of reading in the messages
            MainForm_LoadXMLProgressBar LoadXMLProgressBar = new MainForm_LoadXMLProgressBar();  // Instantiate the object
            LoadXMLProgressBar.Show();
            
            for (int i = 0; i < XMLArrayListLength; i++)  // Loop for each XML file 
            {
                #region ParseNodes
                XmlDocument doc = new XmlDocument();
                try  // If there is a failure loading the file, continue with the next XML file
                {
                    doc.Load(XMLArrayList[i]);  // Load each XML file in the array
                }
                catch (Exception ex) 
                { 
                    TraceLogging.Error("Failed to load XML file: " + XMLArrayList[i] + ", due to: " + ex.Message); 
                }
                XmlNode node = doc.FirstChild;
                
                int XMLNumber = i + 1; // To be used in the trace below for numbering purposes
                TraceLogging.Info("Extracting nodes from XML file #" + XMLNumber + ": " + XMLArrayList[i] );

                //XML node definitions

                // ########## SUBJECT ##########
                try
                {
                    //Subject
                    Subject = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                    TraceLogging.Verbose("[" + XMLNumber + "] Subject: " + Subject);
                }
                catch (Exception ex)
                {
                    Subject = "Failure loading data";  // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    TraceLogging.Error("Failure obtaining message 'Subject': " + ex.Message);
                }

                // ########## FROM (Sender) ##########
                {
                    // From - Display
                    try
                    {
                        FromDisplay = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] From display name: " + FromDisplay);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        FromDisplay = "Failure loading data";
                        TraceLogging.Error("Failure loading the From display: " + ex.Message);
                    }  
                    //From - Adddress
                    try
                    {
                        FromAddress = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] From address: " + FromAddress);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        FromAddress = "Failure loading data";
                        TraceLogging.Error("Failure loading the From address: " + ex.Message);
                    }  
                }

                // ???????????????*******************  check out the main three regions below.  I commented out all catches after the index 0 because I was seeing
                // all of these error messages up to 10 times for each cell in the data grid view.  I don't know how to know if there SHOULD have been data there but failed, versus
                // failing because it isn't there (node).
                // ANOTHER CHANGE: I commented out everything I added, because I think it's a good assumption to exit the logic once there is a failure accessing a To, CC, or Bcc field
                // I think it will be quite rare for one to succeed, the next to fail (unless corrupted), the next to succeed, etc.  It's much more processing to not assume this.
                // POTENTIAL CHANGE: I think I can get what I want to confirm the <marker> <string> nodes exist and if so and then a failure occurs, assume it ends and catch ex.
                    // If an exception occurs and the marker and string exist, post a message stating the data failed to load (currently commented out), otherwise keep it empty "".

                // ########## TO (Recipient) ##########
                try
                {
                    #region ToHardcoded // Hardcoded to a max of 10
                    // Reset all values so as not to pick up the previous XML file's value if the first node fails
                    for (int reset = 0; ToDisplay.Length > reset; reset++) { ToDisplay[reset] = ""; }
                    for (int reset = 0; ToAddress.Length > reset; reset++) { ToAddress[reset] = ""; }
                    //To #1 - Display    - what about the <sequence /> right before this with no opening <sequence>?  not sure I've ever seen it there
                    // try
                    {
                        ToDisplay[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name: " + ToDisplay[0]);
                    }
                    /*   catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                       {
                           ToDisplay[0] = "Failure loading data: " + ex.Message;
                           TraceLogging.Error("Failure loading the To display name: " + ex.Message);
                       } */
                    //To #1 - Address
                    //   try
                    {
                        ToAddress[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address: " + ToAddress[0]);
                    }
                    /*   catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                       {
                           ToAddress[0] = "Failure loading data: " + ex.Message;
                           TraceLogging.Error("Failure loading the To address: " + ex.Message);
                       } */
                    //To #2 - Display ***
                    //   try
                    {
                        ToDisplay[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 2: " + ToDisplay[1]);
                    }
                    /*   catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                       {
                           //ToDisplay[1] = "Failure loading data: " + ex.Message;
                           //TraceLogging.Error("Failure loading the To display name 2: " + ex.Message);
                       } */
                    //To #2 - Address ***
                    //   try
                    {
                        ToAddress[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 2: " + ToAddress[1]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToAddress[1] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To address 2: " + ex.Message);
                        } */
                    //To #3 - Display ***
                    //    try
                    {
                        ToDisplay[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 3: " + ToDisplay[2]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToDisplay[2] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To display name 3: " + ex.Message);
                        } */
                    //To #3 - Address ***
                    //    try
                    {
                        ToAddress[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 3: " + ToAddress[2]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToAddress[2] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To address 3: " + ex.Message);
                        } */
                    //To #4 - Display ***
                    //     try
                    {
                        ToDisplay[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 4: " + ToDisplay[3]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToDisplay[3] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To display name 4: " + ex.Message);
                        } */
                    //To #4 - Address ***
                    //   try
                    {
                        ToAddress[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 4: " + ToAddress[3]);
                    }
                    /*   catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                       {
                           //ToAddress[3] = "Failure loading data: " + ex.Message;
                           //TraceLogging.Error("Failure loading the To address 4: " + ex.Message);
                       } */
                    //To #5 - Display ***
                    //    try
                    {
                        ToDisplay[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 5: " + ToDisplay[4]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //ToDisplay[4] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the To display name 5: " + ex.Message);
                         } */
                    //To #5 - Address ***
                    //   try
                    {
                        ToAddress[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 5: " + ToAddress[4]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //ToAddress[4] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the To address 5: " + ex.Message);
                          } */
                    //To #6 - Display ***
                    //   try
                    {
                        ToDisplay[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 6: " + ToDisplay[5]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //ToDisplay[5] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the To display name6: " + ex.Message);
                         } */
                    //To #6 - Address ***
                    //    try
                    {
                        ToAddress[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 6: " + ToAddress[5]);
                    }
                    /*   catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                       {
                           //ToAddress[5] = "Failure loading data: " + ex.Message;
                           //TraceLogging.Error("Failure loading the To address 6: " + ex.Message);
                       } */
                    //To #7 - Display ***
                    //    try
                    {
                        ToDisplay[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 7: " + ToDisplay[6]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToDisplay[6] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To display name 7: " + ex.Message);
                        } */
                    //To #7 - Address ***
                    //     try
                    {
                        ToAddress[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 7: " + ToAddress[6]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToAddress[6] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To address 7: " + ex.Message);
                        } */
                    //To #8 - Display ***
                    //    try
                    {
                        ToDisplay[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 8: " + ToDisplay[7]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToDisplay[7] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To display name 8: " + ex.Message);
                        } */
                    //To #8 - Address ***
                    //     try
                    {
                        ToAddress[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 8: " + ToAddress[7]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToAddress[7] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To address 8: " + ex.Message);
                        } */
                    //To #9 - Display ***
                    //     try
                    {
                        ToDisplay[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 9: " + ToDisplay[8]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //ToDisplay[8] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the To display name 9: " + ex.Message);
                        } */
                    //To #9 - Address ***
                    //     try
                    {
                        ToAddress[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 9: " + ToAddress[8]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //ToAddress[8] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the To address 9: " + ex.Message);
                         } */
                    //To #10 - Display ***
                    //      try
                    {
                        ToDisplay[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To display name 10: " + ToDisplay[9]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //ToDisplay[9] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the To display name 10: " + ex.Message);
                         } */
                    //To #10 - Address ***
                    //     try
                    {
                        ToAddress[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] To address 10: " + ToAddress[9]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            ToAddress[9] = "Failure loading data: " + ex.Message;
                            TraceLogging.Error("Failure loading the To address 10: " + ex.Message);
                        } */
                    #endregion ToHardcoded // Hardcoded to a max of 10
                }
                catch { } // Don't do anything because exceptions are expected at some point
                
                // ########## CC (Carbon Copy) ##########
                try
                {
                    #region CCHardcoded // Hardcoded to a max of 10
                    // Reset all values so as not to pick up the previous XML file's value if the first node fails
                    for (int reset = 0; CCDisplay.Length > reset; reset++) { CCDisplay[reset] = ""; }
                    for (int reset = 0; CCAddress.Length > reset; reset++) { CCAddress[reset] = ""; }
                    //CC #1 Display
                    //     try
                    {
                        CCDisplay[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name: " + CCDisplay[0]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             CCDisplay[0] = "Failure loading data: " + ex.Message;
                             TraceLogging.Error("Failure loading the CC display name: " + ex.Message);
                         } */
                    //CC #1 Address
                    //     try
                    {
                        CCAddress[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address: " + CCAddress[0]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             CCAddress[0] = "Failure loading data: " + ex.Message;
                             TraceLogging.Error("Failure loading the CC address: " + ex.Message);
                         } */
                    //CC #2 Display
                    //      try
                    {
                        CCDisplay[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 2: " + CCDisplay[1]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCDisplay[1] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 2: " + ex.Message);
                         } */
                    //CC #2 Address
                    //     try
                    {
                        CCAddress[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 2: " + CCAddress[1]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCAddress[1] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC address 2: " + ex.Message);
                         } */
                    //CC #3 Display
                    //     try
                    {
                        CCDisplay[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 3: " + CCDisplay[2]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCDisplay[2] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 3: " + ex.Message);
                         } */
                    //CC #3 Address
                    //    try
                    {
                        CCAddress[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 3: " + CCAddress[2]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                           // CCAddress[2] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the CC address 3: " + ex.Message);
                        } */
                    //CC #4 Display
                    //    try
                    {
                        CCDisplay[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 4: " + CCDisplay[3]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCDisplay[3] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 4: " + ex.Message);
                         } */
                    //CC #4 Address
                    //    try
                    {
                        CCAddress[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 4: " + CCAddress[3]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //CCAddress[3] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the CC address 4: " + ex.Message);
                          } */
                    //CC #5 Display
                    //    try
                    {
                        CCDisplay[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 5: " + CCDisplay[4]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //CCDisplay[4] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the CC display name 5: " + ex.Message);
                          } */
                    //CC #5 Address
                    //     try
                    {
                        CCAddress[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 5: " + CCAddress[4]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCAddress[4] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC address 5: " + ex.Message);
                         } */
                    //CC #6 Display
                    //     try
                    {
                        CCDisplay[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 6: " + CCDisplay[5]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //CCDisplay[5] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the CC display name 6: " + ex.Message);
                          } */
                    //CC #6 Address
                    //      try
                    {
                        CCAddress[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 6: " + CCAddress[5]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //CCAddress[5] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the CC address 6: " + ex.Message);
                        } */
                    //CC #7 Display
                    //     try
                    {
                        CCDisplay[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 7: " + CCDisplay[6]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                             // CCDisplay[6] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the CC display name 7: " + ex.Message);
                          } */
                    //CC #7 Address
                    //     try
                    {
                        CCAddress[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 7: " + CCAddress[6]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //CCAddress[6] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the CC address 7: " + ex.Message);
                          } */
                    //CC #8 Display
                    //     try
                    {
                        CCDisplay[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 8: " + CCDisplay[7]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCDisplay[7] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 8: " + ex.Message);
                         } */
                    //CC #8 Address
                    //     try
                    {
                        CCAddress[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 8: " + CCAddress[7]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCAddress[7] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC address 8: " + ex.Message);
                         } */
                    //CC #9 Display
                    //     try
                    {
                        CCDisplay[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 9: " + CCDisplay[8]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // CCDisplay[8] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 9: " + ex.Message);
                         } */
                    //CC #9 Address
                    //     try
                    {
                        CCAddress[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 9: " + CCAddress[8]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // CCAddress[8] = "Failure loading data: " + ex.Message;
                            // TraceLogging.Error("Failure loading the CC address 9: " + ex.Message);
                         } */
                    //CC #10 Display
                    //   try
                    {
                        CCDisplay[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC display name 10: " + CCDisplay[9]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //CCDisplay[9] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the CC display name 10: " + ex.Message);
                         } */
                    //CC #10 Address
                    //     try
                    {
                        CCAddress[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] CC address 10: " + CCAddress[9]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // CCAddress[9] = "Failure loading data: " + ex.Message;
                            // TraceLogging.Error("Failure loading the CC address 10: " + ex.Message);
                         } */
                    #endregion CCHardcoded // Hardcoded to a max of 10
                }
                catch { } // Don't do anything because exceptions are expected at some point
                
                // ########## Bcc (Blind carbon copy) ##########
                try
                {
                    #region BccHardcoded // Hardcoded to a max of 10
                    // Reset all values so as not to pick up the previous XML file's value if the first node fails
                    for (int reset = 0; BccDisplay.Length > reset; reset++) { BccDisplay[reset] = ""; }
                    for (int reset = 0; BccAddress.Length > reset; reset++) { BccAddress[reset] = ""; }
                    //Bcc #1 Display
                    //     try
                    {
                        BccDisplay[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name: " + BccDisplay[0]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            BccDisplay[0] = "Failure loading data: " + ex.Message;
                            TraceLogging.Error("Failure loading the Bcc display name: " + ex.Message);
                        } */
                    //Bcc #1 Address
                    //   try
                    {
                        BccAddress[0] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address: " + BccAddress[0]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            BccAddress[0] = "Failure loading data: " + ex.Message;
                            TraceLogging.Error("Failure loading the Bcc address: " + ex.Message);
                        } */
                    //Bcc #2 Display ***
                    //    try
                    {
                        BccDisplay[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 2: " + BccDisplay[1]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccDisplay[1] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc display name 2: " + ex.Message);
                        } */
                    //Bcc #2 Address ***
                    //     try
                    {
                        BccAddress[1] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 2: " + BccAddress[1]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccAddress[1] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc address 2: " + ex.Message);
                         } */
                    //Bcc #3 Display ***
                    //     try
                    {
                        BccDisplay[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 3: " + BccDisplay[2]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccDisplay[2] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc display name 3: " + ex.Message);
                         } */
                    //Bcc #3 Address ***
                    //    try
                    {
                        BccAddress[2] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 3: " + BccAddress[2]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccAddress[2] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc address 3: " + ex.Message);
                         } */
                    //Bcc #4 Display ***
                    //   try
                    {
                        BccDisplay[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 4: " + BccDisplay[3]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // BccDisplay[3] = "Failure loading data: " + ex.Message;
                            // TraceLogging.Error("Failure loading the Bcc display name 4: " + ex.Message);
                         } */
                    //Bcc #4 Address ***
                    //     try
                    {
                        BccAddress[3] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 4: " + BccAddress[3]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // BccAddress[3] = "Failure loading data: " + ex.Message;
                            // TraceLogging.Error("Failure loading the Bcc address 4: " + ex.Message);
                         } */
                    //Bcc #5 Display ***
                    //    try
                    {
                        BccDisplay[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 5: " + BccDisplay[4]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                            // BccDisplay[4] = "Failure loading data: " + ex.Message;
                            // TraceLogging.Error("Failure loading the Bcc display name 5: " + ex.Message);
                         } */
                    //Bcc #5 Address ***
                    //     try
                    {
                        BccAddress[4] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 5: " + BccAddress[4]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccAddress[4] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc address 5: " + ex.Message);
                         } */
                    //Bcc #6 Display ***
                    //    try
                    {
                        BccDisplay[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 6: " + BccDisplay[5]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccDisplay[5] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc display name 6: " + ex.Message);
                        } */
                    //Bcc #6 Address ***
                    //    try
                    {
                        BccAddress[5] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 6: " + BccAddress[5]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccAddress[5] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc address 6: " + ex.Message);
                         } */
                    //Bcc #7 Display ***
                    //    try
                    {
                        BccDisplay[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 7: " + BccDisplay[6]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccDisplay[6] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc display name 7: " + ex.Message);
                         } */
                    //Bcc #7 Address ***
                    //    try
                    {
                        BccAddress[6] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 7: " + BccAddress[6]);
                    }
                    /*     catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                         {
                             //BccAddress[6] = "Failure loading data: " + ex.Message;
                             //TraceLogging.Error("Failure loading the Bcc address 7: " + ex.Message);
                         } */
                    //Bcc #8 Display ***
                    //    try
                    {
                        BccDisplay[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 8: " + BccDisplay[7]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //BccDisplay[7] = "Failure loading data: " + ex.Message;
                             // TraceLogging.Error("Failure loading the Bcc display name 8: " + ex.Message);
                          } */
                    //Bcc #8 Address ***
                    //   try
                    {
                        BccAddress[7] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 8: " + BccAddress[7]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccAddress[7] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc address 8: " + ex.Message);
                        } */
                    //Bcc #9 Display ***
                    //   try
                    {
                        BccDisplay[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 9: " + BccDisplay[8]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccDisplay[8] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc display name 9: " + ex.Message);
                        } */
                    //Bcc #9 Address ***
                    //   try
                    {
                        BccAddress[8] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 9: " + BccAddress[8]);
                    }
                    /*      catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                          {
                              //BccAddress[8] = "Failure loading data: " + ex.Message;
                              //TraceLogging.Error("Failure loading the Bcc address 9: " + ex.Message);
                          } */
                    //Bcc #10 Display ***
                    //   try
                    {
                        BccDisplay[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc display name 10: " + BccDisplay[9]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccDisplay[9] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc display name 10: " + ex.Message);
                        } */
                    //Bcc #10 Address ***
                    //    try
                    {
                        BccAddress[9] = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Bcc address 10: " + BccAddress[9]);
                    }
                    /*    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                        {
                            //BccAddress[9] = "Failure loading data: " + ex.Message;
                            //TraceLogging.Error("Failure loading the Bcc address 10: " + ex.Message);
                        } */
                    #endregion BccHardcoded // Hardcoded to a max of 10
                }
                catch { }  // Don't do anything because exceptions are expected at some point
                
                // ########## Transmit counter (max of 10 by the IC system - default) ##########
                try
                {
                    //Transmit count (17 next siblings from start)
                    TransmitCount = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.NextSibling.InnerText;
                    TraceLogging.Verbose("[" + XMLNumber + "] Transmit count: " + TransmitCount);
                }
                catch (Exception ex)
                {
                    TransmitCount = "Failure loading data"; // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    TraceLogging.Error("Failure obtaining message transmit count: " + ex.Message);
                }
                // ########## Message Body (should be plain text unless malformed) ##########

                #region MessageBody // text/plain; text/html
                try
                {
                    //*Should* be text/plain, but check to confirm rather than assuming 
                    PlainTextFormat = true;  // Set the default here in case there is an exception later where this value is set
                    HTMLFormat = false; // Set the default here in case there is an exception later where this value is set
                    try
                    {
                        MessageFormat1temp = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Message format location 1: " + MessageFormat1temp);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        MessageFormat1temp = "Failure loading data";
                        TraceLogging.Error("Failure loading the Message format location 1: " + ex.Message);
                    } 
                    // Set the format based on the read in value 
                    if (MessageFormat1temp == "text/plain") { PlainTextFormat = true; }  // This is the expected value  
                    else if (MessageFormat1temp == "text/html") { HTMLFormat = true; }  // This is NOT expected (order was switched) 
                    //base64 body (should be for text/plain)
                    try
                    {
                        Base64Body1temp = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Message body in base64 for location 1: " + Base64Body1temp);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        Base64Body1temp = "Failure loading data";
                        TraceLogging.Error("Failure loading Message body in base64 for location 1: " + ex.Message);
                    } 
                    // Set the correct variable based on the format
                    if (PlainTextFormat) //  This is the expected format
                    {
                        try
                        {
                            PlainTextBodyBase64 = Base64Body1temp;
                            // Convert base64 to ASCII and set the variable
                            PlainTextBodyASCII = Program.DecodeFrom64(PlainTextBodyBase64);
                            TraceLogging.Verbose("Converted text/plain base64 encoded message to ASCII: " + PlainTextBodyASCII);
                        }
                        catch (Exception ex)
                        {
                            // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                            PlainTextBodyASCII = "Failure decoding text/plain base 64 encoded message to ASCII";  
                            TraceLogging.Error("Failure decoding text/plain base 64 encoded message to ASCII: " + ex.Message);
                        }
                    }
                    else if (HTMLFormat) // This is NOT the expected format (formats switched likely by handlers, at least in RUM)
                    {
                        try
                        {
                            HTMLBodyBase64 = Base64Body1temp;
                            //  Convert base64 to ASCII and set the variable
                            HTMLBodyASCII = Program.DecodeFrom64(HTMLBodyBase64);
                            TraceLogging.Verbose("Converted text/html base64 encoded message to ASCII: " + HTMLBodyASCII);
                        }
                        catch (Exception ex)
                        {
                            // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                            HTMLBodyASCII = "Failure decoding text/html base64 encoded message to ASCII";
                            TraceLogging.Error("Failure decoding text/html base64 encoded message to ASCII: " + ex.Message);
                        }
                    }
                    // Reset values for the below check for what should be html
                    PlainTextFormat = false;
                    HTMLFormat = false;
                }
                catch (Exception ex)
                {
                    TraceLogging.Warning("Failure obtaining message body (likely the plain text version): " + ex.Message);
                }
                // ########## Messsage Body (should be HTML unless malformed) ##########
                try
                {
                    PlainTextFormat = false;  // Set the default here in case there is an exception later where this value is set
                    HTMLFormat = true; // Set the default here in case there is an exception later where this value is set
                    //*Should* be text/html but check to confirm rather than assuming
                    try
                    {
                        MessageFormat2temp = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Message format location 2: " + MessageFormat2temp);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        MessageFormat2temp = "Failure loading data";
                        TraceLogging.Error("Failure loading the Message format location 2: " + ex.Message);
                    } 
                    // Set the format base on the read in value
                    if (MessageFormat2temp == "text/plain") { PlainTextFormat = true; }  // This is NOT expected (order was switched)
                    else if (MessageFormat2temp == "text/html") { HTMLFormat = true; }  // This is the expected value
                    //base 64 body (should be for text/html)
                    try
                    {
                        Base64Body2temp = node.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.FirstChild.NextSibling.InnerText;
                        TraceLogging.Verbose("[" + XMLNumber + "] Message body in base64 for location 2: " + Base64Body2temp);
                    }
                    catch (Exception ex) // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                    {
                        Base64Body2temp = "Failure loading data";
                        TraceLogging.Error("Failure loading the Message body in base64 location 2: " + ex.Message);
                    } 
                    // Set the correct variable based on format
                    if (PlainTextFormat)  // This is NOT the expected format
                    {
                        try
                        {
                            PlainTextBodyBase64 = Base64Body2temp;
                            // Convert base64 to ASCII and set the variable
                            PlainTextBodyASCII = Program.DecodeFrom64(PlainTextBodyBase64);
                            TraceLogging.Verbose("Converted text/plain base 64 encoded message to ASCII: " + PlainTextBodyASCII);
                        }
                        catch (Exception ex)
                        {
                            // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                            PlainTextBodyASCII = "Failure decoding text/plain base 64 encoded message to ASCII";
                            TraceLogging.Error("Failure decoding text/plain base 64 encoded message to ASCII: " + ex.Message);
                        }
                    }
                    else if (HTMLFormat) // This is NOT the expected format (formats switched likely by handlers, at least in RUM)
                    {
                        try
                        {
                            HTMLBodyBase64 = Base64Body2temp;
                            //  Convert base64 to ASCII and set the variable
                            HTMLBodyASCII = Program.DecodeFrom64(HTMLBodyBase64);
                            TraceLogging.Verbose("Converted text/html base64 encoded message to ASCII: " + HTMLBodyASCII);
                        }
                        catch (Exception ex)
                        {
                            // Populate the field with error feedback, plus if this isn't done, the previous XML data is displayed instead
                            HTMLBodyASCII = "Failure decoding text/plain base 64 encoded message to ASCII";
                            TraceLogging.Error("Failure decoding text/plain base 64 encoded message to ASCII: " + ex.Message);
                        }
                    }  
                }
                catch (Exception ex)
                {
                    TraceLogging.Warning("Failure obtaining message body (likely the HTML verson): " + ex.Message);
                }
                #endregion // end MessageBody

                #endregion //ParseNodes

                // These are used to store the hardcoded arrays into a single string to pass into the XMLData array further below (to be fed into the data set and then data grid view)
                string ToDisplayString = "";
                string ToAddressString = "";
                string CCDisplayString = "";
                string CCAddressString = "";
                string BccDisplayString = "";
                string BccAddressString = "";
                // Combine each multi-valued part together in one string (multiple To, CC, Bcc)
                for (int XMLDataCount = 0; XMLDataCount < ToDisplay.Length; XMLDataCount++)  // To reduce duplicity, assume To, CC, and Bcc will ALL have the same length of the ToDisplay array ***  Default=10
                {
                    // if the value is not empty or null, append the data + ";"
                    if (ToDisplay[XMLDataCount] != "" && ToDisplay[XMLDataCount] != null) { ToDisplayString += ToDisplay[XMLDataCount] + "; "; }
                    if (ToAddress[XMLDataCount] != "" && ToAddress[XMLDataCount] != null) { ToAddressString += ToAddress[XMLDataCount] + "; "; }
                    if (CCDisplay[XMLDataCount] != "" && CCDisplay[XMLDataCount] != null) { CCDisplayString += CCDisplay[XMLDataCount] + "; "; }
                    if (CCAddress[XMLDataCount] != "" && CCAddress[XMLDataCount] != null) { CCAddressString += CCAddress[XMLDataCount] + "; "; }
                    if (BccDisplay[XMLDataCount] != "" && BccDisplay[XMLDataCount] != null) { BccDisplayString += BccDisplay[XMLDataCount] + ";"; }
                    if (BccAddress[XMLDataCount] != "" && BccAddress[XMLDataCount] != null) { BccAddressString += BccAddress[XMLDataCount] + ";"; }

                }
                // Remove all "<" and ">" from the HTMLBody so that I can display the HTML.  The less than/greater than signs will break the DataGridView if left in the HTMLBody string.
                string HTMLBodyASCIIProcessed = HTMLBodyASCII.Replace("<", "[");
                HTMLBodyASCIIProcessed = HTMLBodyASCIIProcessed.Replace(">", "]");
                TraceLogging.Verbose("edits to html: " + HTMLBodyASCIIProcessed);
                //HTMLBodyASCIIProcessed = HTMLBodyASCII.Replace("", "*");  *** above html body fix

                // When a new column is added, also add set and get methods for show/hide below as well as the column visibility form and to hide by default, initialize a hide in the constructor at the top of this form code
                XMLData[i] += "<tables>";
                XMLData[i] += "  <row>";
                XMLData[i] += "     <Number>" + (i + 1) + "</Number>";
                XMLData[i] += "     <XMLFile>" + XMLArrayList[i] + "</XMLFile>";
                XMLData[i] += "     <From-Display>" + FromDisplay + "</From-Display>";
                XMLData[i] += "     <From-Address>" + FromAddress + "</From-Address>";
                XMLData[i] += "     <To-Display>" + ToDisplayString + "</To-Display>";
                XMLData[i] += "     <To-Address>" + ToAddressString + "</To-Address>";
                XMLData[i] += "     <CC-Display>" + CCDisplayString + "</CC-Display>";
                XMLData[i] += "     <CC-Address>" + CCAddressString + "</CC-Address>";
                XMLData[i] += "     <Bcc-Display>" + BccDisplayString + "</Bcc-Display>";
                XMLData[i] += "     <Bcc-Address>" + BccAddressString + "</Bcc-Address>";
                XMLData[i] += "     <Subject>" + Subject + "</Subject>";
                XMLData[i] += "     <Body-PlainText>" + PlainTextBodyASCII + "</Body-PlainText>";
                XMLData[i] += "     <Body-HTML>" + "test" + "</Body-HTML>";  // HTMLBodyASCII not working yet ***
                XMLData[i] += "     <TransmitCount>" + TransmitCount + "</TransmitCount>";
                XMLData[i] += "  </row>";
                XMLData[i] += "</tables>";
                TraceLogging.Verbose("[" + XMLNumber + "] Building separate (temp) XML to load key nodes from the original XML: " + XMLData[i]);

                int iPlusOne = i + 1;
                LoadXMLProgressBar.ProgressBarXMLLoadUpdate(ProgressBarUpdate(iPlusOne, XMLArrayListLength));  // Pass the updated counts to the progress bar
            }  // End for loop to read in, parse, and display XML files

            /*for (float fade = 100; fade > 0; fade--)  I'd use this if it would actually load 100%, but I don't fade it out since it only goes 85% or so even when I hard code the value to 100.
             *  If I do get this to work, I'll need to move this section along with the close and dispose to the below try block
            {
                LoadXMLProgressBar.Opacity = (fade / 100);
                System.Threading.Thread.Sleep(20);
            }*/
            LoadXMLProgressBar.Close();  // Close the ProgressBar form since the XMl load is complete.  
            LoadXMLProgressBar.Dispose();  // Dispose the ProgressBar form, it can't be accessed any longer.

            // Create and load the data set into the datagrid.
            try
            {
                string XMLTempString = "";  // To be used to trace out the complete XML string to load into the data set/ data grid.

                for (int x = 0; x < XMLArrayListLength; x++)  // Loop through each XMLData[x] table/row and load into the reader and data set
                {
                    TraceLogging.Verbose("[" + x + "] Reading temp XML file into the reader and data set.");
                    StringReader theReader = new StringReader(XMLData[x]);
                    theDataSet.ReadXml(theReader); // the data set to read the above XML data (XMLData[x]) into
                    
                    XMLTempString += XMLData[x];  //  To be used to trace out the complete XML string to load into the data set/ data grid.
                }

                TraceLogging.Verbose("Complete temp XML file read into the data set from the reader: " + XMLTempString);
                TraceLogging.Verbose("Loading the data set into the main data grid...");
                //MainDataGrid.DataSource = theDataSet.Tables[0].DefaultView;  // Load the data set into the data grid *** OLD code, use dataview and bindingsource now
                // ************************NEW SECTION WITH BINDING SOURCE*******************************************
                // Get a DataView of the table contained in the dataset.
                DataView DataViewtemp = new DataView(theDataSet.Tables[0]);  // Not sure why I have this temp dataview, but keep for now...***
                // Copy the temp dataview to the main dataview
                MainDataView = DataViewtemp;
                // Set the MainBindingSource's DataSource property to the DataView.
                MainBindingSource.DataSource = MainDataView;
                // Set the data source for the DataGridView.
                MainDataGrid.DataSource = MainBindingSource;
                MainBindingNavigator.BindingSource = MainBindingSource;
                // *******************************************************************
                TraceLogging.Verbose("Data grid load complete.");

            }
            catch (Exception ex)
            {
                TraceLogging.Error("Exception loading data set into the data grid view: " + ex.Message);
            }
        }

        #region SetColumnVisibility  // Methods to set the visibility of the columns  // fix object oriented issues when accessing outside this form
        public void ShowNumber() { MainDataGrid.Columns["Number"].Visible = true; }   // Default the column to be smaller ***
        public void HideNumber() { MainDataGrid.Columns["Number"].Visible = false; }
        public void ShowXMLFile() { MainDataGrid.Columns["XMLFile"].Visible = true; }
        public void HideXMLFile() { MainDataGrid.Columns["XMLFile"].Visible = false; }
        public void ShowFromDisplay() { MainDataGrid.Columns["From-Display"].Visible = true; }
        public void HideFromDisplay() { MainDataGrid.Columns["From-Display"].Visible = false;}
        public void ShowFromAddress() { MainDataGrid.Columns["From-Address"].Visible = true;}
        public void HideFromAddress() { MainDataGrid.Columns["From-Address"].Visible = false; }
        public void ShowToDisplay() { MainDataGrid.Columns["To-Display"].Visible = true; }
        public void HideToDisplay() { MainDataGrid.Columns["To-Display"].Visible = false; }
        public void ShowToAddress() { MainDataGrid.Columns["To-Address"].Visible = true; }
        public void HideToAddress() { MainDataGrid.Columns["To-Address"].Visible = false; }
        public void ShowCCDisplay() { MainDataGrid.Columns["CC-Display"].Visible = true; }
        public void HideCCDisplay() { MainDataGrid.Columns["CC-Display"].Visible = false; }
        public void ShowCCAddress() { MainDataGrid.Columns["CC-Address"].Visible = true; }
        public void HideCCAddress() { MainDataGrid.Columns["CC-Address"].Visible = false; }
        public void ShowBccDisplay() { MainDataGrid.Columns["Bcc-Display"].Visible = true;}
        public void HideBccDisplay() { MainDataGrid.Columns["Bcc-Display"].Visible = false; }
        public void ShowBccAddress() { MainDataGrid.Columns["Bcc-Address"].Visible = true; }
        public void HideBccAddress() { MainDataGrid.Columns["Bcc-Address"].Visible = false; }
        public void ShowSubject() { MainDataGrid.Columns["Subject"].Visible = true; }
        public void HideSubject() { MainDataGrid.Columns["Subject"].Visible = false; }
        public void ShowBodyPlainText() { MainDataGrid.Columns["Body-PlainText"].Visible = true; }
        public void HideBodyPlainText() { MainDataGrid.Columns["Body-PlainText"].Visible = false; }
        public void ShowBodyHTML() { MainDataGrid.Columns["Body-HTML"].Visible = true; }
        public void HideBodyHTML() { MainDataGrid.Columns["Body-HTML"].Visible = false; }
        public void ShowTransmitCount() { MainDataGrid.Columns["TransmitCount"].Visible = true; }
        public void HideTransmitCount() { MainDataGrid.Columns["TransmitCount"].Visible = false; }
        #endregion // SetColumnVisibility

        #region GetColumnVisibility // Methods to get the visibility of the columns; return true or false.
        public bool IsNumberChecked() { return MainDataGrid.Columns["Number"].Visible; }
        public bool IsXMLFileChecked() { return MainDataGrid.Columns["XMLFile"].Visible; }
        public bool IsFromDisplayChecked() { return MainDataGrid.Columns["From-Display"].Visible; }
        public bool IsFromAddressChecked() { return MainDataGrid.Columns["From-Address"].Visible; }
        public bool IsToDisplayChecked() { return MainDataGrid.Columns["To-Display"].Visible; }
        public bool IsToAddressChecked() { return MainDataGrid.Columns["To-Address"].Visible; }
        public bool IsCCDisplayChecked() { return MainDataGrid.Columns["CC-Display"].Visible; }
        public bool IsCCAddressChecked() { return MainDataGrid.Columns["CC-Address"].Visible; }
        public bool IsBccDisplayChecked() { return MainDataGrid.Columns["Bcc-Display"].Visible; }
        public bool IsBccAddressChecked() { return MainDataGrid.Columns["Bcc-Address"].Visible; }
        public bool IsSubjectChecked() { return MainDataGrid.Columns["Subject"].Visible; }
        public bool IsBodyPlainTextChecked() { return MainDataGrid.Columns["Body-PlainText"].Visible; }
        public bool IsBodyHTMLChecked() { return MainDataGrid.Columns["Body-HTML"].Visible; }
        public bool IsTransmitCountChecked() { return MainDataGrid.Columns["TransmitCount"].Visible; }

        #endregion  // GetColumnVisibility
        private void saveCurrentMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void saveAllChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void exitWithoutSavingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instantiate the column form and pass the MainForm into it.
            MainForm_ContextMenu_View_ColumnVisibility MainForm_ContextMenu_View_ColumnVisibility = new MainForm_ContextMenu_View_ColumnVisibility(this);
            MainForm_ContextMenu_View_ColumnVisibility.Show();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.  Aye, fohgeht about it.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show(Application.ProductName + "\r\nVersion: " + Application.ProductVersion);
        }

        private void Searchbtn_Click(object sender, EventArgs e) // *** doesn't work
        {
            /*
            // Get a DataView of the table contained in the dataset.
            DataView dv = new DataView(theDataSet.Tables[0]);
            // Create a BindingSource and set its DataSource property to the DataView.
            BindingSource bs = new BindingSource();
            bs.DataSource = dv;
            // Set the data source for the DataGridView.
            MainDataGrid.DataSource = bs;*/
            
            if (Searchtxtbx.Text.Length > 0)  // Search for the string if there is text in the textbox.
            {
                int itemFound = MainBindingSource.Find("Body-PlainText", Searchtxtbx.Text);  // Set the Position property to the results of the Find method.
                MainBindingSource.Position = itemFound;
                MessageBox.Show("Item: " + itemFound);
            }
        }
        
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            //if (MainBindingSource.Position + 1 < MainBindingSource.Count)
            {
                MainBindingSource.MoveNext();
                //MainBindingNavigator();
            } 
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            MainBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            MainBindingSource.MoveFirst();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            MainBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Text = MainBindingSource.Position.ToString();
        }

        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorCountItem.Text = "of " + "{" + MainBindingSource.Count.ToString() + "}";
        }
        // Retry selected messages
        private void RetryMessagestxtbx_Click(object sender, EventArgs e)
        {
            #region DeclareVariablesAndFormObjects
            string MoveFromFile = "";  // *** not used for selected rows any longer, since it's all handled in the method (same with MovetoFile)
            string MoveToFile = "";  // It's *possible* that this directo&ry could be different if I added a feature to import from multiple locations
            string MoveFromDirectory = "";  // The directory path the XML files are moved from (e.g., NoRetry, or custom folders)
            string MoveToDirectory = "";  // The directoyr path where the XML files are moved to (Outbox)
            string OutboxDirectory = "";  // The directory set by appending 'Outbox' to the entered directory var
            int selectedRowCount = MainDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);  // Get the number (count) of selected rows    
            CacheSelectedItemsIndexInGridView = new int [selectedRowCount];  // Cache the selected row index list, so that I don't need to grab live index numbers from the grid view      
            #endregion //Declare varialbes and form objects

            #region CacheSelectedItemsIndexInGridView  // Pass the array of selected items in the grid view and obtain a cached array so that the grid view can change and cache won't.
            for (int SelectedIndexCount = 0; selectedRowCount > SelectedIndexCount; SelectedIndexCount++)  // Pass through each row index selected
            {
                // Copy the currently selected row indexes into the cached array.
                CacheSelectedItemsIndexInGridView[SelectedIndexCount] = MainDataGrid.SelectedRows[SelectedIndexCount].Index;
            }            
            // Since the indexes aren't always in order (e.g., multi-selecting skipping rows), sort them in ascending order.
            Array.Sort(CacheSelectedItemsIndexInGridView); 
            #endregion

            #region InitializePaths: 1)MoveFromDirectory; 2) MoveToDirectory
            // Assume the EnteredDirectory\Outbox will be used to retry messages.  If \Outbox doesn't exist, default to the root.
            try
            {
                if (Directory.Exists(Program.RemoveTrailingBackslashesAddOneBack(EnteredDirectory) + "Outbox\\"))  // The full directory path to Outbox
                {
                    OutboxDirectory = Program.RemoveTrailingBackslashesAddOneBack(EnteredDirectory) + "Outbox\\";  // Set the folder, changing from the default of root
                    TraceLogging.Verbose("The Outbox folder exists to be used to retry messages: " + OutboxDirectory);
                }
                else
                {
                    OutboxDirectory = Program.RemoveTrailingBackslashesAddOneBack(EnteredDirectory);  // Default to the working root directory passed into this form from Program.
                    MessageBox.Show("The Outbox folder doesn't exist to retry message delivery!  " + Program.RemoveTrailingBackslashesAddOneBack(EnteredDirectory) + "Outbox\\.\r\n\r\nDefaulting to: " + OutboxDirectory);
                    TraceLogging.Warning("The Outbox folder doesn't exist to retry message delivery!  " + Program.RemoveTrailingBackslashesAddOneBack(EnteredDirectory) + "Outbox\\.\r\n\r\nDefaulting to: " + OutboxDirectory);
                }
            }
            catch (Exception ex)
            {
                TraceLogging.Error("Caught exception setting the Outbox directory: " + ex.Message);
            }
            MoveToDirectory = OutboxDirectory;  // Set the To directory (either Outbox or entered) to be initially displayed in the retry options
            TraceLogging.Verbose("Initial MoveToDirectory: " + MoveToDirectory);
            MoveFromDirectory = WorkingXMLRootDirectory;  // Set the From directory (NoRetry or other) to be initially displayed in the retry options
            TraceLogging.Verbose("Initial MoveFromDirectory: " + MoveFromDirectory);
            #endregion //InitializePaths: 1)MoveFromDirectory; 2) MoveToDirectory

            #region PopRetryMessagesForm
            MainForm_RetryWithOptions RetryMessagesForm = new MainForm_RetryWithOptions(MoveFromDirectory, MoveToDirectory, selectedRowCount, XMLArrayList.Length);
            if (RetryMessagesForm.ShowDialog() == DialogResult.OK)
            {
                #region InitializeRetryMessagesFormOptions  // Only obtain the advanced option setting, and just initialize defaults for variables to be set later
                bool UseAdvancedOptions = RetryMessagesForm.UseAdvancedOptions();  // true/false
                bool RetryConsecutively = true; // RetryMessagesForm.RetryConsecutively();  // true=retry consecutively with a throttle; false=use the retry interval (seconds)
                int Throttle = 200;  // Research what a valid default (milliseconds) value should be (minimum value) *** jam
                bool OnlyRetryMessagesSelectedInTheMainGridView = true; // RetryMessagesForm.OnlyRetryMessagesSelectedInTheMainGridView();  //true=retry all selected; false= ignore selected, use form options
                int TotalNumberOfMessagesToRetry = 0; // RetryMessagesForm.TotalNumberOfMessagesToRetry();  // Ignore message selection, and retry the array list starting at index 0
                string MessageTypeToRetry = "";  // RetryMessagesForm.MessageTypeToRetry(); // "default (All)", "All", "Voicemails", "Faxes", "Recordings", "Notifications", "Other"
                int RetryIntervalSeconds = 0;  // RetryMessagesForm.RetryIntervalSeconds();  //  The RetryConsecutively option needs to be false to use this
                int NumberOfMessagesToRetryPerInterval = 0; // RetryMessagesForm.NumberOfMessagesToRetryPerInterval();  //  The RetryConsecutively option needs to be false to use this
                Throttle = RetryMessagesForm.Throttle();  // Get the form intered value for the time in milliseconds between message retry attempts (moving message to Outbox)
                MoveToDirectory = RetryMessagesForm.GetMoveTo();  // Change the directory if the user changed it in the RetryMessagesForm
                #endregion // InitializeRetryMessagesFormOptions

                #region ProcessMessagesWithSettings
                if (UseAdvancedOptions == false) // if Use Advanced Options is unchecked, then proceed to retry all messages that were selected in the grid (if any).
                {
                    // Call the method to process (move specified messages and launch the success window) selected messages
                    // (DataGridView)MainDataGrid= main form; (int)selectedRowCount= count of selected rows in grid; (string[])XMLArrayList= file path+names of XML files loaded
                    // (string)MoveToDirectory= the directory to move to (Outbox); (int)Throttle= time in milliseconds between single XML message retry attempts
                    // (bool)RetryConsecutively: true=only throttle (normal-default), false=retry over interval; (bool)OnlyRetryMessagesSelectedInTheMainGridView: true=selected in grid, false=ignore selected
                    // (int)RetryIntervalSeconds=retry x messages every y seconds; (int)NumberOfMessagesToRetryPerInterval= count per interval
                    RetryMessages(MainDataGrid, selectedRowCount, XMLArrayList, MoveToDirectory, Throttle, true, true, 0, 0); // Consecutive retry, no interval options
                }
                else if (UseAdvancedOptions == true)  // If checked, then process each context of enabled radio buttons and entered text in textboxes/dropdowns/etc.
                {
                    #region ObtainRetryMessagesFormOptions
                    // Some of these method calls will return an empty string to int conversion or similar and catch an error.  Try/catch rather than call them when 
                    // necessary for organizational purposes
                    try{ RetryConsecutively = RetryMessagesForm.RetryConsecutively(); } catch { }  // Do nothing // true=retry asap; false=use the retry interval (seconds)
                    try{ OnlyRetryMessagesSelectedInTheMainGridView = RetryMessagesForm.OnlyRetryMessagesSelectedInTheMainGridView(); } catch { }  // Do nothing //true=retry all selected; false= ignore selected, use form options
                    try{ TotalNumberOfMessagesToRetry = RetryMessagesForm.TotalNumberOfMessagesToRetry(); } catch { }  // Do nothing // Ignore message selection, and retry the array list starting at index 0
                    try{ MessageTypeToRetry = RetryMessagesForm.MessageTypeToRetry(); } catch { }  // Do nothing// "default (All)", "All", "Voicemails", "Faxes", "Recordings", "Notifications", "Other"
                    try{ RetryIntervalSeconds = RetryMessagesForm.RetryIntervalSeconds(); } catch { }  // Do nothing //  The RetryConsecutively option needs to be false to use this
                    try{ NumberOfMessagesToRetryPerInterval = RetryMessagesForm.NumberOfMessagesToRetryPerInterval(); } catch { }  // Do nothing //  The RetryConsecutively option needs to be false to use this
                    
                    #endregion // ObtainRetryMessagesFormOptions

                    // Since the largest blocks of code will be rather to retry selected messages only or not, begin processing here.
                    if (OnlyRetryMessagesSelectedInTheMainGridView == true)  // Only process selected messages from the grid (may be consecutive or by interval)
                    {
                        // Call the method to process (move specified messages and launch the success window) selected messages
                        // (DataGridView)MainDataGrid= main form; (int)selectedRowCount= count of selected rows in grid; (string[])XMLArrayList= file path+names of XML files loaded
                        // (string)MoveToDirectory= the directory to move to (Outbox); (int)Throttle= time in milliseconds between single XML message retry attempts
                        // (bool)RetryConsecutively: true=only throttle (normal-default), false=retry over interval; (bool)OnlyRetryMessagesSelectedInTheMainGridView: true=selected in grid, false=ignore selected
                        // (int)RetryIntervalSeconds=retry x messages every y seconds; (int)NumberOfMessagesToRetryPerInterval= count per interval
                        RetryMessages(MainDataGrid, selectedRowCount, XMLArrayList, MoveToDirectory, Throttle, RetryConsecutively, OnlyRetryMessagesSelectedInTheMainGridView, RetryIntervalSeconds, NumberOfMessagesToRetryPerInterval); 
                    }
                    else if (OnlyRetryMessagesSelectedInTheMainGridView == false)  // Ignore selected messages from the grid for processing and use alternative options
                    {
                        // Call the method to process (move specified messages and launch the success window) selected messages
                        // (DataGridView)MainDataGrid= main form; (int)TotalMessageCount= count of selected rows in grid; (string[])XMLArrayList= file path+names of XML files loaded
                        // (string)MoveToDirectory= the directory to move to (Outbox); (int)Throttle= time in milliseconds between single XML message retry attempts
                        // (bool)RetryConsecutively: true=only throttle (normal-default), false=retry over interval; (bool)OnlyRetryMessagesSelectedInTheMainGridView: true=selected in grid, false=ignore selected
                        // (int)RetryIntervalSeconds=retry x messages every y seconds; (int)NumberOfMessagesToRetryPerInterval= count per interval
                        RetryMessages(MainDataGrid, TotalNumberOfMessagesToRetry, XMLArrayList, MoveToDirectory, Throttle, RetryConsecutively, OnlyRetryMessagesSelectedInTheMainGridView, RetryIntervalSeconds, NumberOfMessagesToRetryPerInterval);
                   }
                } 
                #endregion // ProcessMessagesWithSettings

            }
            else if (RetryMessagesForm.DialogResult == DialogResult.Cancel)
            {
                // Do nothing (tear anything down in the future that needs to be, shouldn't for now)
            }

            #endregion // PopRetryMessagesForm

        

        }  // End RetrySelectMessages

        // (DataGridView)MainDataGrid= main form; (int)TotalMessageCount= count of messages to retry; (string[])XMLArrayList= file path+names of XML files loaded
        // (string)MoveToDirectory= the directory to move to (Outbox); (int)Throttle= time in milliseconds between single XML message retry attempts
        // (bool)RetryConsecutively: true=only throttle (normal-default), false=retry over interval;  (int)RetryIntervalSeconds=retry x messages every y seconds
        // (int)NumberOfMessagesToRetryPerInterval= count per interval
        public void RetryMessages(DataGridView MainDataGrid, int TotalMessageCount, string[] XMLArrayList, string MoveToDirectory, int Throttle, bool RetryConsecutively, bool OnlyRetryMessagesSelectedInTheMainGridView, int RetryIntervalSeconds, int NumberOfMessagesToRetryPerInterval)
        {
            MainForm_RetryMessages_SuccessfullyMoved SuccessfullyMovedForm = new MainForm_RetryMessages_SuccessfullyMoved();  // Used to display successfully moved files
            
            string MoveFromFile = "";  // Original file location (e.g., Noretry)
            string MoveToFile = "";  // Move to location (Outbox)
            StringBuilder BuildSuccessMessageString = new StringBuilder();  // To be used to build the success messages to populate into the success form after processing is done.
            int SuccessfullyMovedCounterUpdate = 0;  // To be used to determine whether the message was moved or not to correctly update the moved messages counter in the modeless success form
            int NumberOfMessagesToRetryPerIntervalCounter = NumberOfMessagesToRetryPerInterval;  // Used to increment each time through the loop if retry over intervals is used 

            SuccessfullyMovedForm.Show();  // Launch the non-model form 

            // process selected messages in the data grid view form, if OnlyRetryMessagesSelectedInTheMainGridView == true
                    try
                    {
                        string[] SuccessfullyRetried = new string[TotalMessageCount];  // Build the array with the size of the number of total/or selected messages.  Used to display a form with successfully moved messages.
                        if (TotalMessageCount > 0)  // If at least one message is to be retried, proceed
                        {
                            int iCountPlusOne = 0; // Keep track of the number of times looped starting at 1 rather than 0, as i does.
                            for (int i = 0; TotalMessageCount > i; i++)
                            {

                                // ***figure out how this can be used to cancel retrying ***//if (SuccessfullyMovedForm.DialogResult == DialogResult.Cancel) { MessageBox.Show("cancel requested"); }

                                // Handle MoveFrom (set)
                                try
                                {
                                    if (OnlyRetryMessagesSelectedInTheMainGridView == true) // messages selected in the grid
                                    {
                                        if (File.Exists(XMLArrayList[CacheSelectedItemsIndexInGridView[i]]))  // Set this to the xml path+name for the i selected row if the path exists (should)
                                        {
                                            MoveFromFile = XMLArrayList[CacheSelectedItemsIndexInGridView[i]];
                                            TraceLogging.Verbose("MoveFromFile (grid selection) set to: " + MoveFromFile);
                                        }
                                    }
                                    else if (OnlyRetryMessagesSelectedInTheMainGridView == false)  // Ignore messages selected in the grid and use specified count (type to be determined below)
                                    {
                                        if (File.Exists(XMLArrayList[i]))  // Start at the beginning of the array (should be lowest XML number/name)
                                        {
                                            MoveFromFile = XMLArrayList[i];
                                            TraceLogging.Verbose("MoveFromFile (ignore grid) set to: " + MoveFromFile);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    TraceLogging.Error("Caught exception setting the MoveFromFile value: " + ex.Message);
                                }
                                // Handle MoveToFile (set)
                                try
                                {   // MoveToDirectory is validated in the form, dont' do so here.
                                    if (OnlyRetryMessagesSelectedInTheMainGridView == true) // messages selected in the grid
                                    {
                                        if (File.Exists(XMLArrayList[CacheSelectedItemsIndexInGridView[i]]))  // If the original location+file exists, set the to path
                                        {
                                            MoveToFile = Program.RemoveTrailingBackslashesAddOneBack(MoveToDirectory) + Path.GetFileName(XMLArrayList[CacheSelectedItemsIndexInGridView[i]]);
                                            TraceLogging.Verbose("MoveToFile (grid selection) set to: " + MoveToFile);
                                        }
                                    }
                                    else if (OnlyRetryMessagesSelectedInTheMainGridView == false) // Ignore messages selected in the grid and use specified count (type to be determined below)
                                    {
                                        if (File.Exists(XMLArrayList[i]))  // If the original file exists, set the to path
                                        {
                                            MoveToFile = Program.RemoveTrailingBackslashesAddOneBack(MoveToDirectory) + Path.GetFileName(XMLArrayList[i]);
                                            TraceLogging.Verbose("MoveToFile (ignore grid) set to: " + MoveToFile);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    TraceLogging.Error("Caught exception setting the MoveToFile value: " + ex.Message);
                                }
                                try
                                {
                                    if (OnlyRetryMessagesSelectedInTheMainGridView == true) // messages selected in the grid
                                    {
                                        if (File.Exists(XMLArrayList[CacheSelectedItemsIndexInGridView[i]]))  // Confirm the file still exists
                                        {
                                            TraceLogging.Verbose("XML message being moved from: " + MoveFromFile);
                                            TraceLogging.TraceAlways("XML message being moved to: " + MoveToFile);  // Trace always so that one can go back in the log to see what was tried
                                            File.Move(MoveFromFile, MoveToFile);
                                            TraceLogging.TraceAlways("Success.");  // Trace always so that one can go back in the log to see what was tried and succeeded
                                            SuccessfullyRetried[i] = MoveToFile;  // Add the string of the path+name.xml for each XML message successfully moved to the Outbox folder and to be displayed in a form when done.
                                            SuccessfullyMovedCounterUpdate += 1;  // Proceed to increase the counter to update the moved counter on the success modeless form (end of loop)

                                            // Update the Array that is keeping track of messages that were retried, prior to them being removed from the XMLArrayList array.
                                            UpdateRetriedXMLMessages(MoveToFile);
                                            // Update the objects: 1) blank the current index (since retry complete on index=i); 2) At the end (TotalMessageCount -1 = i), shift all rows to remove empty XMLData indexes
                                            Update_XMLArrayList_XMLData_theDataSet_MainDataView_MainBindingSource_MainDataGrid_MainBindingNavigator(i, TotalMessageCount, true);

                                        }
                                        else  // This should never happen unless the file is moved or deleted from the time of load to when the retry is done.
                                        {
                                            MoveFromFile = "[ File doesn't exist here: " + XMLArrayList[CacheSelectedItemsIndexInGridView[i]] + " ]";
                                            TraceLogging.Warning("The XML file doesn't exist: " + XMLArrayList[CacheSelectedItemsIndexInGridView[i]] + "\r\n\r\nIt may have been moved or deleted between being loaded and receiving the retry request");
                                            MoveToFile = "[ File not moved ]";
                                            TraceLogging.Warning("File not moved.");
                                        }
                                    }
                                    else if (OnlyRetryMessagesSelectedInTheMainGridView == false)  // Ignore messages selected in the grid and use specified count/type
                                    {
                                        if (File.Exists(XMLArrayList[i]))  // Confirm the file still exists
                                        {
                                            // determine type check here *** jam IF THE TYPE DOESN'T MATCH, SKIP MOVE, IF MATCH THEN PROCEED BELOW
                                            TraceLogging.Verbose("XML message being moved from: " + MoveFromFile);
                                            TraceLogging.TraceAlways("XML message being moved to: " + MoveToFile);  // Trace always so that one can go back in the log to see what was tried
                                            File.Move(MoveFromFile, MoveToFile);
                                            TraceLogging.TraceAlways("Success.");  // Trace always so that one can go back in the log to see what was tried and succeeded
                                            SuccessfullyRetried[i] = MoveToFile;  // Add the string of the path+name.xml for each XML message successfully moved to the Outbox folder and to be displayed in a form when done.
                                            SuccessfullyMovedCounterUpdate += 1;  // Proceed to increase the counter to update the moved counter on the success modeless form (end of loop)

                                            // Update the Array that is keeping track of messages that were retried, prior to them being removed from the XMLArrayList array.
                                            UpdateRetriedXMLMessages(MoveToFile);
                                            // Update the objects: 1) blank the current index (since retry complete on index=i); 2) At the end (TotalMessageCount -1 = i), shift all rows to remove empty XMLData indexes
                                            Update_XMLArrayList_XMLData_theDataSet_MainDataView_MainBindingSource_MainDataGrid_MainBindingNavigator(i, TotalMessageCount, false);

                                        }
                                        else  // This should never happen unless the file is moved or deleted from the time of load to when the retry is done.
                                        {
                                            MoveFromFile = "[ File doesn't exist here: " + XMLArrayList[i] + " ]";
                                            TraceLogging.Warning("The XML file doesn't exist: " + XMLArrayList[i] + "\r\n\r\nIt may have been moved or deleted between being loaded and receiving the retry request");
                                            MoveToFile = "[ File not moved ]";
                                            TraceLogging.Warning("File not moved.");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    TraceLogging.Error("Failed to move message!  " + ex.Message);
                                }
                                try
                                {
                                //move out of for    SuccessfullyMovedForm.Show();  // Launch the non-model form 
                                //move out    if (SuccessfullyMovedForm.DialogResult == DialogResult.Cancel) { MessageBox.Show("cancel requested"); }
                                    // WOW *** this really is terrible on the CPU.  It pegs one core nearly and the other are around 20-30%.  
                                    // Without dynamically updating the form textbox, the CPU still hits all cores around 50% or so it seems, 
                                    // but only for up to 3-4 seconds for 1300-1400 messages to process, versus several minutes at 2-5 messages per second
                                    //SuccessfullyMovedForm.AddMessageMoved(System.DateTime.Now.TimeOfDay.ToString() + " :: " + (i + 1) + " :: From: " + MoveFromFile + " :: ");  // Add the From/original location of the moved mesage (path+name.xml)
                                    //SuccessfullyMovedForm.AddMessageMoved(System.DateTime.Now.TimeOfDay.ToString() + " :: " + (i + 1) + " :: To: " + MoveToFile + "\r\n");  // Add successfully moved message to the form.
                                    // Instead, let's build a string to pass to the form after all messages are processed

                                    
                                    iCountPlusOne = i + 1;  // Keep track of the number of times looped starting at 1 rather than 0, as i does.

                                    BuildSuccessMessageString.AppendLine(System.DateTime.Now.TimeOfDay.ToString() + " :: " + iCountPlusOne + " :: From: " + MoveFromFile + " :: " + "To: " + MoveToFile);  // Build string output for message move feedback/status

                                    ProgressBar.Value = ProgressBarUpdate(iCountPlusOne, TotalMessageCount);  // Update the progress bar
                                }
                                catch (Exception ex)
                                {
                                    TraceLogging.Warning("Exception updating the messages retried form or main progress bar: " + ex.Message);  // *** remove/refine message, used for debugging right now.
                                }

                                if (RetryConsecutively == false)  // Retry over intervals is enabled (honor retry interval and number per interval)
                                {
                                    if (NumberOfMessagesToRetryPerIntervalCounter == iCountPlusOne)  // When the loop counter is equal to the number of messages per interval
                                    {
                                        NumberOfMessagesToRetryPerIntervalCounter += NumberOfMessagesToRetryPerInterval;  // Increase the counter by the number to retry in each interval
                                        int RetryIntervalMilliseconds = RetryIntervalSeconds * 1000;  // Convert the input from seconds to milliseconds 
                                        System.Threading.Thread.Sleep(RetryIntervalMilliseconds);  // Sleep (milliseconds) according to the retry interval configuration.
                                    }
                                }
                                else  // If RetryConsecutively is enabled, implement throttling.  Don't throttle for retry over intervals (above).
                                {
                                    System.Threading.Thread.Sleep(Throttle);  // *** jam look into possibly doing the processing on a background thread
                                }
                            } // End for loop

                         




                            SuccessfullyMovedForm.AddMessageMoved(BuildSuccessMessageString.ToString());

                            SuccessfullyMovedForm.AddMessageMoved("\r\n\r\nComplete.  \r\n\r\nMessages have been moved.  Please confirm whether the messages are delivered (e.g., they don't go back to the NoRetry folder or remain 'stuck' in the Processing folder).");
                            // *** This is no longer real-time since the form updates too quickly and whites out the textboxes, which is unhelpful.  Display at the end instead.
                            SuccessfullyMovedForm.TotalMessagesToMove(TotalMessageCount);  // Pass the total number of messages to move into the form displaying moved messaages.  Keep this outside the for loop.
                            SuccessfullyMovedForm.UpdateMessagesMovedCount(SuccessfullyMovedCounterUpdate);  // Update the number of messages moved in the popped form (at the end, not realtime)
                            // Since these are invisible by default now (due to the explanation above, make them visible after messages are all moved.
                            SuccessfullyMovedForm.ShowMessagesMovedStatus();
                            // ***
                            //if (ProgressBar.Value == 100)  //  If the ProgressBar is at 100% progress, reset it to 0.
                            {  // I'm going to leave out the if statement for now in case something happens where it makes it this far and the progress for some reason wasn't 100%.  I still want to reset it.
                                //System.Threading.Thread.Sleep(8000);  // sleep time in milliseconds
                                ProgressBarReset();   // Reset the MainForm's progress bar back to 0 if it is currently set to 100 when the MainForm becomes the active control.  Is this a good idea? ***  First done to reset it after messages are retried.
                            }

                        } // End - if (selectedRowCount > 0) 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Retry selected messages caught an exception: " + ex.Message);
                        TraceLogging.Error("Retry selected messages caught an exception: " + ex.Message);
                    }
        }

        public int ProgressBarStatus()
        {
            return this.ProgressBar.Value;  // return the value of the progress bar
        }
        public void ProgressBarReset()
        {
            ProgressBar.Value = 0;  // Reset the progress bar back to 0
        }
        public int ProgressBarUpdate(float CurrentNumber, int TotalCount)   
        {
            // Update the progress bar (bottom-right)
            float ProgressBarValuefloat = (((float)CurrentNumber) / TotalCount) * 100;  // Obtain the decimal number to determine the percentage complete
            int ProgressBarValueint = (int)ProgressBarValuefloat;  // Convert the float to an int using casting
            return ProgressBarValueint;
        }

        // Update the ArrayList that is keeping track of messages that were retried, prior to them being removed from the XMLArrayList array.
        public void UpdateRetriedXMLMessages(string ToFiletemp)
        {
            RetriedXMLMessages.Add(ToFiletemp);
            TraceLogging.Verbose("Message added to the retried messages list: " +  RetriedXMLMessages[(RetriedXMLMessages.Count - 1)]);
        }

        // *** jam break out to distinct functions: 1) remove message from xmldata cache, 2) defrag array, 3) update objects below
        // 1) Current index; 2) Total messages being retried; 3) Whether only selected messages are being retried or ignored and other configurations being used (true/false)
        public void Update_XMLArrayList_XMLData_theDataSet_MainDataView_MainBindingSource_MainDataGrid_MainBindingNavigator(int CurrentXMLRetryIndex, int TotalMessageCounttemp, bool OnlyRetryMessagesSelectedInTheMainGridView)   // TotalMessagecounttempt starts at 1
        {  // CurrentXMLRetryIndex starts at 0
            // Empty the XMData index that was retried (moved to Outbox)
            try
            {

                MainDataGrid.CurrentCell = null;  // Unselect all rows so that all can be marked invisible (will be removed from the objects shortly - dataset, xmldata, xmlarraylist, etc)
                if (OnlyRetryMessagesSelectedInTheMainGridView == true) // Retry messages selected in the grid only
                {
                    TraceLogging.Verbose("Removing the currently retried XML file from XMLData cache: " + XMLData[CacheSelectedItemsIndexInGridView[CurrentXMLRetryIndex]]);
                    XMLData[CacheSelectedItemsIndexInGridView[CurrentXMLRetryIndex]] = "";  // clear the current index
                    MainDataGrid.Rows[CacheSelectedItemsIndexInGridView[CurrentXMLRetryIndex]].Visible = false;  // Hide the row, it will be deleted when the XMLDatat is loaded into the dataset .. -> datagridview
                }
                else if (OnlyRetryMessagesSelectedInTheMainGridView == false) // Ignore messages in the grid was selected
                {
                    TraceLogging.Verbose("Removing the currently retried XML file from XMLData cache: " + XMLData[CurrentXMLRetryIndex]);
                    XMLData[CurrentXMLRetryIndex] = "";  // clear the current index
                    MainDataGrid.Rows[CurrentXMLRetryIndex].Visible = false;  // Hide the row, it will be deleted when the XMLDatat is loaded into the dataset .. -> datagridview
                }

            }
            catch (Exception ex)
            {
                TraceLogging.Error("Exception removing the curently retried XML file from XMLData cache: " + XMLData[CacheSelectedItemsIndexInGridView[CurrentXMLRetryIndex]] + ex.Message);
            }
            // Shrink the XMLData array if the message retries are done.
            try
            {
                int XMLDataOriginalArraySize = XMLData.Length;  // Obtain the current size to be used in the tracing below
                if ((TotalMessageCounttemp - 1) == CurrentXMLRetryIndex)  // This means we're at the end of the messages to retry in the main form, so clean up the XMLData array (shift to remove empty indexes)
                {
                    for (int i = 0; XMLData.Length > i; i++)
                    {
                        if (XMLData[i] == "") // && i != (XMLData.Length - 1))  // If the index is empty, shift all the indexes down - defrag (if it's not at the end of the array)
                        {
                            while (XMLData[i] == "")  // As long as the i index is blank, continue to remove the indexes.  This will be used multiple times when there are multiple blank indexes
                            {
                                XMLData = ArrayRemoveAtIndex(XMLData, i);  // Removes the index, shrinks the array (XMLData)
                                XMLArrayList = ArrayRemoveAtIndex(XMLArrayList, i);  // Removes the index, shrinks the array (XMLArrayList)
                            }
                        }
                    }
                    int XMLDataNewArraySize = XMLData.Length;  // Obtain the current size that the array was shrunk to within each iteration of ArrayRemoveAtIndex()
                    TraceLogging.Verbose("Done shrinking the XMLData array from: " + XMLDataOriginalArraySize + " to: " + XMLDataNewArraySize);
                }
            }
            catch (Exception ex)
            {
                TraceLogging.Error("Exception shrinking the XMLData array" + ex.Message);
            }




            // move to method
            if ((TotalMessageCounttemp - 1) == CurrentXMLRetryIndex)  // It's at the end of the messages to retry that were selected
            {
                // move to method after loop done
                
                
                MainDataGrid.EndEdit();

                theDataSet.Clear();
                // Load the data into the respective objects leading to the data set, data grid view, etc.
                try
                {
                    string XMLTempString = "";  // To be used to trace out the complete XML string to load into the data set/ data grid.
                    XMLTempString = "";  // Reset the string.
                    for (int x = 0; x < XMLData.Length; x++)  // Loop through each XMLData[x] table/row and load into the reader and data set
                    {
                        TraceLogging.Verbose("[" + x + "] Reading temp XML file data into the reader and data set, since it was updated.");
                        StringReader theReader = new StringReader(XMLData[x]);
                        theDataSet.ReadXml(theReader); // the data set to read the above XML data (XMLData[x]) into
                        XMLTempString += XMLData[x];  //  To be used to trace out the complete XML string to load into the data set/ data grid.
                    }
                    TraceLogging.Verbose("Complete temp XML file data read into the data set from the reader: " + XMLTempString);
                    TraceLogging.Verbose("Loading the data set into the main data grid...");
                    //MainDataGrid.DataSource = theDataSet.Tables[0].DefaultView;  // Load the data set into the data grid *** OLD code, use dataview and bindingsource now
                    // ************************NEW SECTION WITH BINDING SOURCE*******************************************
                    // Get a DataView of the table contained in the dataset.
                    DataView DataViewtemp = new DataView(theDataSet.Tables[0]);  // Not sure why I have this temp dataview, but keep for now...***
                    // Copy the temp dataview to the main dataview
                    MainDataView = DataViewtemp;
                    // Set the MainBindingSource's DataSource property to the DataView.
                    MainBindingSource.DataSource = MainDataView;
                    // Set the data source for the DataGridView.
                    MainDataGrid.DataSource = MainBindingSource;
                    MainBindingNavigator.BindingSource = MainBindingSource;
                    // *******************************************************************
                    TraceLogging.Verbose("Data grid update complete.");

                    // Refresh the main data grid view
                       
                       MainDataGrid.Refresh();
                }
                catch (Exception ex)
                {
                    TraceLogging.Error("Exception caught updating the XML objects to refresh the main grid view: " + ex.Message);
                }

             }

             
        
             
             
             
             
             
             
        }
        // Props to http://www.eggheadcafe.com/community/aspnet/2/72799/how-to-remove-the-element-from-array.aspx
        public string[] ArrayRemoveAtIndex(string[] originalArray, int index)  // Remove the index and shrink the array
        {
            string[] newArr = new string[originalArray.Length - 1];
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (i < index) newArr[i] = originalArray[i];
                if (i > index) newArr[i - 1] = originalArray[i];
            }
            return newArr;
        }

        

        // Export the datagrid to a CSV file
        public static void ExportXMLReportCSV(DataSet ds, String path, String columnlist)
        {

            //DataTable dt = new DataTable(ds);
            
        }
        private void CheckMessageBodyOptions()  // Avoid having redundant code for MainDataGrid_RowEnter; HTMLBodyckbx_CheckedChanged; PlainTextBodyckbx_CheckedChanged; and PopOutBody_CheckedChanged
        {
            string BodyValue = MainDataGrid["Body-PlainText", MainDataGrid.SelectedRows[0].Index].Value.ToString(); // Obtain the value of the plaintext body (selected row)
            if (PlainTextBodyckbx.Checked == true)
            {
                if (PopOutBodychkbx.Checked == true)  // Display the message body text within the new popped out form now
                {
                    MessageBodyForm.SetMessageBody(BodyValue);
                }
                else if (PopOutBodychkbx.Checked == false)  // Keep the message body text within the main form
                {
                    MessageBodytxtbx.Text = BodyValue; // Update the textbox with the body contents
                }
            }
            else if (PlainTextBodyckbx.Checked == false)
            {
                if (PopOutBodychkbx.Checked == true) // Display the message body text within the new popped out form now
                {
                    MessageBodyForm.SetMessageBody("");
                }
                else if (PopOutBodychkbx.Checked == false) // Keep the message body text within the main form
                {
                    MessageBodytxtbx.Text = "";
                }
            }
        }
        private void MainDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = MainDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);  // Get the number (count) of selected rows
            if (selectedRowCount > 0)  // If at least one row is selected, proceed
            {
                // http://msdn.microsoft.com/en-us/library/x8x9zk5a.aspx How to: Get the Selected Cells, Rows, and Columns in the Windows Forms DataGridView Control
                // If ctrl+click is done = displays body of last selected (most recent) row
                // If shift+click is done = displays body of the highest indexed row (it seems)
                CheckMessageBodyOptions(); // Consolidate the checkbox checks within this method call
            }
        }

        private void HTMLBodyckbx_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented.");
        }

        private void PlainTextBodyckbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckMessageBodyOptions();  // Consolidate the checkbox checks within this method call
        }

        private void PopOutBody_CheckedChanged(object sender, EventArgs e) // Display the message body text within the new popped out form now 
        {
            if (PopOutBodychkbx.Checked == true)
            {
                MessageBodyForm.Show();  // Launch new form as non-modal.
                MessageBodytxtbx.Text = "";  // Blank out the MainForm message body since it's being displayed in the popped out form.
                HideBottomPanelchkbx.Enabled = true;  // Show/give the option to hide the bottom message panel to give more XML data grid view space
            }
            else if (PopOutBodychkbx.Checked == false)
            {
                MessageBodyForm.Hide();  // Hide the form.
                HideBottomPanelchkbx.Enabled = false; // Hide the option to hide the bottom message panel so that these options remain in-tact.
            }
            CheckMessageBodyOptions();  // Consolidate the checkbox checks within this method call
        }

        public void UncheckPopOutBodychkbxAndHidePanel()
        {
            PopOutBodychkbx.Checked = false;
            HideBottomPanelchkbx.Checked = false;
        }




        /*
  
         * 
                   XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
            
                   XslTransform xt = new XslTransform();
                   StreamReader reader = new StreamReader("Excel.xsl");  //StreamReader reader = new StreamReader(typeof(WorkbookEngine).Assembly.GetManifestResourceStream(typeof(WorkbookEngine), "Excel.xsl"));
                   XmlTextReader xRdr = new XmlTextReader(reader);
                   xt.Load(xRdr, null, null);

                   StringWriter sw = new StringWriter();
                   xt.Transform(xmlDataDoc, null, sw, null);
            
                   StreamWriter myWriter = new StreamWriter(path + "\\Report.xls");
                   myWriter.Write (sw.ToString());
                   myWriter.Close ();
   
         */


    }
}
