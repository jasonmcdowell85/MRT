using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;
using System.Reflection;
using System.Security.Principal;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;

// Utility first thought about around the 1st week of July and coding a week or two after.

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            #region Variable Initializations
            // ####### Declare variables to be used later. #######
            string MailRootDirectory = "NULL";
            string MailNoRetryDirectory = "NULL";
            string MailOutboxDirectory = "NULL";
            string OtherRootDirectory = "NULL";
            string OtherRootDirectoryOption = "False";
            string WorkingXMLRootDirectory = "NULL";
            string EnteredDirectory = "NULL";
            string XMLRetrievalSettingBrowseXMLFile = "NULL";  // Contains the XML file name selected for a single browse-to option
            string ICSiteName = "NULL";
            string UtilityConfigDirectory = "NULL";

            #endregion

            // Generic error catching for the entire Main() method.
            try
            {
                /*string[] test = new string[2];
                test[0] = @"c:\i3\ic\mail\noretry\507963150twoEachBccSU9.xml";
                test[1] = @"c:\i3\ic\mail\noretry\507963149TwoEachSU9.xml";
                MainForm MainF = new MainForm(test);
                Application.Run(MainF);
                */

                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Get the configuration file.
                //string dbPath = System.Configuration.ConfigurationSettings.AppSettings["TraceSwitch1"];
                // *** test MessageBox.Show("app user path: " + Application.UserAppDataPath);
                
                // The first time running the utility will not trace out the Trace Initializations region
                // since the trace config file doesn't yet exist.  I could probably hardcode the tracing and then
                // check to see if the file exists and if so, use the file rather than the hardcoded config.
                // I don't think it's worth my time to do this, currently.
                #region Trace Initializations  // System information, app start, tracing level
                // ####### Trace initializations #######
                // Trace system information such as domain|workgroup/user, machine name, time zone, ...
                TraceLogging.TraceSystemInformation();
                // Trace that the application is starting.
                TraceLogging.TraceAlways("Application starting...");
                // Trace the current logging level as configured in the App.config file for TraceSwitch1.
                TraceLogging.TraceAlways("Tracing level [off(0), error(1), warning(2), info(3), verbose(4)]: " + TraceLogging.TraceLevel() + "\r\n");
                #endregion

                // Create the \Message Recovery Tool directory if it doesn't exit. If that fails, try %temp%,
                // and if that fails, attempt to create the folder in the current working directory.
                UtilityConfigDirectory = SetGetUtilityDir();  

                // Create the default startup App.config file to be used for tracing configuration/settings: 
                TraceLogging.CreateDefaultAppConfigFile(UtilityConfigDirectory);

                // These came out of the box, however, I'm not entirely sure what they do.  I'll leave them though.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                #region Application processing  // The main logic
                // ####### BEGIN MAIN APPLICATION - METHODS #######


                #region Mail directory paths GET and SET  // "Mail", "Mail/NoRetry", "Mail/Outbox", OR Other Directory
                // Try to automatically obtain the root Mail directory path (from the registry).  If it fails, "manual" is returned.
                string ManualFormPop = GetMailDirAuto();
                // If Auto failed (returns "manual"), a manual user input form pop will be used by calling GetMailDirManual().
                // This should never happen, but if null or "" is returned proceed to GetMailDirManual as well.
                string[] ManualFormDirAndOption = new string[2];  // Capture the GetMailDirManual return.  [0] - directory path; [1]= Other dir option
                bool ExitLoop = false;
                // ExitLoop is defaulted to false.  At each exit point in the loop, set the bool to true.
                while (ExitLoop == false)
                {
                    if (ManualFormPop == "manual" || ManualFormPop == null || ManualFormPop == "" || ManualFormPop == "NULL")
                    {
                        // Call the GetMailDirManual method to obtain the path [0] as well as the option [1] to select a custom path that doesn't assume
                        // the NoRetry or Outbox subfolders, but rather points to the path where the XML files directly reside.
                        ManualFormDirAndOption = GetMailDirManual();
                    }

                    // If the checkbox option for Other Directory was left at the default of disabled, proceed with the Mail dir and set NoRetry and Outbox dir.
                    if (ManualFormDirAndOption[1] == "False")
                    {
                        // Set the root directory
                        MailRootDirectory = ManualFormDirAndOption[0];
                        // Redundantly set the entered directory to be used later
                        EnteredDirectory = MailRootDirectory;
                        // Set the NoRetry directory.
                        MailNoRetryDirectory = SetMailNoRetryDir(MailRootDirectory);
                        // Redundantly set the Working directory to the same path in case I have a later use.
                        WorkingXMLRootDirectory = MailNoRetryDirectory;
                        // If the NoRetry directory attempted doesn't exist/can't be accessed (returns "ERROR"), 
                        // don't allow the application to proceed past the manual directory entry (method pops error).
                        if (MailNoRetryDirectory == "ERROR")
                        {
                            // This isn't necessary, but set it anyway to server as a placeholder.
                            ExitLoop = false;
                        }
                        else
                        {
                            ExitLoop = true;
                        }
                        // If the Outbox set fails, directory attempted doesn't exist, (returns "ERROR"), continue (method pops error).
                        // Set the Outbox reference path using the Mail path as the input.  It's 'ok' if this fails, if doing read-only.
                        MailOutboxDirectory = SetMailOutboxDir(ManualFormDirAndOption[0]);
                    }
                    // The Other Directory checkbox was checked (enabled) and this path will be set to obtain XML files directly from this root dir.
                    else if (ManualFormDirAndOption[1] == "True")
                    {
                        OtherRootDirectory = ManualFormDirAndOption[0];
                        OtherRootDirectoryOption = ManualFormDirAndOption[1];
                        // Right now this seems redundant, however, it may be useful when more features are used to expand functionality.
                        // This WorkingXMLRootDirectory path will be used to feed into retieving the XML file list.
                        WorkingXMLRootDirectory = OtherRootDirectory;
                        EnteredDirectory = OtherRootDirectory;
                        ExitLoop = true;
                    }
                }
                
                #endregion
                
                #endregion


                #region Acceptance code

                
                // public XMLRetrievalSettings(string TotalMessageCountTemp, string MailNoRetryDir, string MailDir, string OtherRootDirectoryOption)
                // Assume we want the XML message count under NoRetry.
                XMLRetrievalSettings XMLRetrieveSettingsForm = new XMLRetrievalSettings(GetXMLMailCount(WorkingXMLRootDirectory), MailNoRetryDirectory, EnteredDirectory, OtherRootDirectoryOption);
                // Create array to obtain the Settings array from XMLRetrievalSettings
                // Settings[0] = filter option (1-all, 2-subcount, 3-oneXML); 
                // Settings[1] = Message count filter; Settings[2] = Mail directory; Settings[3] = BrowseXML file name
                string[] XMLRetrievalSettingsArray = new string [4];
                string XMLRetrievalSettingXMLFilterOption = "NULL";
                string XMLRetrievalSettingCountFilter = "NULL";
                string XMLRetrievalSettingDirectory = "NULL";
                string XMLRetrievalSettingOtherDirectory = "NULL";
                // One string for now, soon to be an array when multi-select is added.
                //string BrowseToXMLFile = "NULL";  // XMLRetrievalSettingBrowseXMLFile will be used instead *** remove in the future
                // Pop form and when the OK button is pressed on the XMLRetrievalSettings Form, execute below
                // Continue to pop until data is valid (directories exist and radio button selected) - handled in XMLRetrievalSettings
                // The result will be a list of XML files with their path and name (option 1-2) or single/multi-select files (opt. 3)
                bool ExitWhile = false;
                while (!ExitWhile)
                {
                    if (XMLRetrieveSettingsForm.ShowDialog() == DialogResult.OK)
                    {
                        // Obtain the array list of configuration settings from the XMLRetrievalSettings form.
                        XMLRetrievalSettingsArray = XMLRetrieveSettingsForm.GetXMLRetrievalSettings();
                        XMLRetrievalSettingXMLFilterOption = XMLRetrievalSettingsArray[0];
                        XMLRetrievalSettingCountFilter = XMLRetrievalSettingsArray[1];
                        
                        
                        XMLRetrievalSettingOtherDirectory = XMLRetrievalSettingsArray[3];  // "True" or "False"
                        // The all or subset XML option was selected.  Set the directories to the new values (if it changed) from the user input form XMLRetrievalSettings
                        if (XMLRetrievalSettingXMLFilterOption == "1" || XMLRetrievalSettingXMLFilterOption == "2")
                        {
                            XMLRetrievalSettingDirectory = XMLRetrievalSettingsArray[2]; // Set the directory entered to this variable
                            // If using default Mail subfolders (Other Directory option not checked), set the Root, NoRetry, and Outbox to new (if any) values
                            if (XMLRetrievalSettingOtherDirectory == "False")
                            {
                                MailNoRetryDirectory = SetMailNoRetryDir(XMLRetrievalSettingDirectory);
                                MailOutboxDirectory = SetMailOutboxDir(XMLRetrievalSettingDirectory);
                                WorkingXMLRootDirectory = MailNoRetryDirectory;
                                break;  // either break or ExitWhile = true can be used.
                            }
                            // If the "Other Directory" option is selected, skip NoRetry and Outbox setting assumptions.
                            else if (XMLRetrievalSettingOtherDirectory == "True")
                            {
                                WorkingXMLRootDirectory = XMLRetrievalSettingDirectory;  // *** keep or delete?
                                break;  // either break or ExitWhile = true can be used.
                            }
                        }
                        else if (XMLRetrievalSettingXMLFilterOption == "3")
                        {
                            XMLRetrievalSettingBrowseXMLFile = XMLRetrievalSettingsArray[2];  // Set the XML file path+name to this variable
                            // Remove the file name so the directory name is left of XMLRetrievalSettingBrowseXMLFile
                            WorkingXMLRootDirectory =  Path.GetDirectoryName(XMLRetrievalSettingBrowseXMLFile).ToString();
                            TraceLogging.Verbose("Selected XML File: " + XMLRetrievalSettingBrowseXMLFile);
                            break;  // either break or ExitWhile = true can be used.
                        }
                    }
                    else if (XMLRetrieveSettingsForm.DialogResult == DialogResult.Retry)  
                    {
                        //  Do nothing here.  This is just to prevent the ConfirmDialog from popping twice if the user tries to close the XMLRetrievalSettingsform but cancels the closure.
                    }
                    else  // The Window was manually excited (most likely).  Prompt to confirm exiting the program.
                    {
                        // Pop Confirm dialog.  *** add/move this to the top of main(), only line below
                        ConfirmDialog ConfirmDialog = new ConfirmDialog();
                        if (ConfirmDialog.ShowDialog() == DialogResult.Yes)
                        {
                            Application.Exit();
                            Environment.Exit(0);  //  IS this considered as exiting successfully in the Win code?
                        }
                        else
                        {
                            // Leave empty for now.  The user did NOT choose to exit the application (yes).
                        }
                    }
                }
                // Exit while loop.

                // At this point, we should have the directory+ path to the XML files to load (SingleXMLFile or the array)
                #region UseXMLFileList  // Use the XML file names+path to load, parse, and display in the main Windows form.
                // This is the array list of XML files to use.  Use an input size based on count returned from XML form to grow the XMLFileListArray.
                string[] XMLFileListArray = new string[int.Parse(XMLRetrievalSettingCountFilter)];
                // If option 1 or 2 (1=all XML files, 2=Specify XML quantity)
                if (XMLRetrievalSettingXMLFilterOption == "1" || XMLRetrievalSettingXMLFilterOption == "2")
                {
                    // Return all xml file names (with given count XMLRetrievalSettingsArray[1]) with directory paths in an array.  

                    XMLFileListArray = GetXMLFileList(XMLRetrievalSettingCountFilter, WorkingXMLRootDirectory);
                }
                else if (XMLRetrievalSettingXMLFilterOption == "3")
                {
                    // We don't need to get an XML file list, because it has already been obtained from the form, however, we need to set the array
                    XMLFileListArray[0] = XMLRetrievalSettingBrowseXMLFile;
                }

                // Pass the XMLFileListArray into the Main form to read in and display the XML messages
                //                          1) Array;                   2) String                               3) String                   4) String           5) String
                MainForm MainF = new MainForm(XMLFileListArray, XMLRetrievalSettingXMLFilterOption, XMLRetrievalSettingOtherDirectory, WorkingXMLRootDirectory, EnteredDirectory);
                //                         1)*path+name list; 2)* 1 (all), 2 (specify), 3 single xml (don't allow \NoRetry); 3)* "True, "False"; 
                // 4) if other dir option, then entered value; if not other dir, then \NoRetry; if browsetoxml then dir of that xml  5) Directory entered in the maildirform
                MainF.ShowDialog();

                #endregion // </UseXMLFileList>

                #endregion  // </Acceptance code>

                #region Testing Code






            #endregion
                
            }
            // Catch any unknown exception in Main() or propagated back to Main() and do nothing
            catch (Exception ex)
            {
                MessageBox.Show("Generic error caught in Main(): " + ex.Message + "  Doing nothing in response.");
                TraceLogging.Error("Generic error caught in Main(): " + ex.Message + "  Doing nothing in response.");
            }
        }
        //convert from string to base64, include try | catch later
        // http://arcanecode.com/2007/03/21/encoding-strings-to-base64-in-c/
        static public string EncodeTo64(string toEncode)
        {
            TraceLogging.Info("Encoding ASCII string to base64.  This is done when an XML message is updated through the GUI, since the change requires propagating the modification back to the XML file where the encoding is base64 rather than ASCII text.");
            try
            {
                byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
                string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                TraceLogging.Info("Since an exception hasn't been caught, assuming ASCII to base64 encoding was successful.");
                return returnValue;
            }
            catch (Exception ex)
            {
                TraceLogging.Error("Error encoding the ASCII string to base64: " + ex.Message);
                // Let the calling method deal with the result of "NULL".
                return "NULL";
            }
        }
        //convert from base64 to string, include try | catch later
        //http://arcanecode.com/2007/03/21/encoding-strings-to-base64-in-c/
        static public string DecodeFrom64(string encodedData)
        {
            TraceLogging.Info("Decoding base64 to ASCII text.  This is done when reading in an XML message to display the message in ASCII text.");
            try
            {
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
                string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                TraceLogging.Info("Since an exception hasn't been caught, assuming base64 to ASCII decoding was successful.");
                return returnValue;
            }
            catch (Exception ex)
            {
                TraceLogging.Error("Error decoding the base64 message to an ASCII string: " + ex.Message);
                // Let the calling method deal with the result of "NULL".
                return "NULL";
            }
        }
        // Create the \Message Recovery Tool folder in the following attempt order (first chosen): 1) %appdata%, 2) Program Files, 3) Current working directory.
        // Also return the path
        static public string SetGetUtilityDir()
        {
            string UtilityFolderName = "\\Message Recovery Tool\\";
            // Build path: %appdata%\Message Recovery Tool
            string UtilityAppDataDir = Environment.GetEnvironmentVariable("APPDATA") + UtilityFolderName;
            // Build path: %temp%\Message Recovery Tool
            string UtilityTempDir = Environment.GetEnvironmentVariable("TEMP") + UtilityFolderName;
            // Build path: [current_directory_EXE_ran_under]\Message Recovery Tool
            string UtilityCurrentDir = Environment.CurrentDirectory + UtilityFolderName;

            // Return %app%\Message Recovery Tool if it exists.
            if (Directory.Exists(UtilityAppDataDir))
            {
                TraceLogging.Info("Existing utility directory found: " + UtilityAppDataDir);
                return UtilityAppDataDir;
            }
            // Return %temp%\Message Recovery Tool if it exists.
            else if (Directory.Exists(UtilityTempDir))
            {
                TraceLogging.Info("Existing utility directory found: " + UtilityTempDir);
                return UtilityTempDir;
            }
                // Return [current_working_directory]\Message Recovery Tool if it exists.
            else if (Directory.Exists(UtilityCurrentDir))
            {
                TraceLogging.Info("Existing utility directory found: " + UtilityCurrentDir);
                return UtilityCurrentDir;
            }
            // If the \Message Recovery Tool folder doesn't exist under any folder above, then attempt to create it in the respective order.
            else
            {
                // If the %appdata%\Message Recovery Tool path doesn't exist, create it (assuming that hits an Exception, go on, bad reasoning?? ***)
                // *** Should I do more checking at the end of the method to confirm a directory does exist in 1 of 3 locations at least?
                try
                {
                    if (!Directory.Exists(UtilityAppDataDir))
                    {
                        Directory.CreateDirectory(UtilityAppDataDir);
                        TraceLogging.Info("The utility directory has been created: " + UtilityAppDataDir);
                        return UtilityAppDataDir;
                    }
                }
                catch (Exception ex)
                {
                    // This likely won't trace since it failed to find the directory for the app.config file to be written to.
                    TraceLogging.Warning("The utility directory could NOT be created: " + UtilityAppDataDir + ".  Exception: " + ex.Message);
                    // Attempt to create the utility directory under %temp% now.
                    try
                    {
                        if (!Directory.Exists(UtilityTempDir))
                        {
                            Directory.CreateDirectory(UtilityTempDir);
                            TraceLogging.Info("The utility directory has been created: " + UtilityTempDir);
                            return UtilityTempDir;
                        }
                    }
                    // If the directory creation fails under %temp%, just create the utility directory in the current directory.
                    catch (Exception ex2)
                    {
                        // This likely won't trace since it failed to find the directory for the app.config file to be written to.
                        TraceLogging.Warning("The utility directory could NOT be created: " + UtilityTempDir + ".  Exception: " + ex2.Message);
                        // Attempt to create the utility directory under the current working directory where the EXE is being ran.
                        try
                        {
                            if (!Directory.Exists(UtilityCurrentDir))
                            {
                                Directory.CreateDirectory(UtilityCurrentDir);
                                TraceLogging.Info("The utility directory has been created: " + UtilityCurrentDir);
                                return UtilityCurrentDir;
                            }
                        }
                        // If we catch the exception this far down, I currently plan to stop and have app.config creation fail.
                        // Tracing will not work since we don't have a directory to write it to.  This should be rare.
                        catch (Exception ex3)
                        {
                            // This likely won't trace since it failed to find the directory for the app.config file to be written to.
                            TraceLogging.Error("The utility directory could NOT be created in the current directory: " + UtilityCurrentDir + ".  Exception: " + ex3.Message + ".  Application tracing will not function.");
                            // State which directories we tried to create and that tracing will NOT work along with any new feature that may use the directory
                            MessageBox.Show("Application tracing will not function!  Failed to create folder '" + UtilityFolderName + "' under the following directories: \r\n\r\n" + UtilityAppDataDir + "\r\n" + UtilityTempDir + "\r\n" + UtilityCurrentDir);
                            return "NULL";
                        }
                    }
                }
                // If the code makes it this far, assume failure and return "NULL", meaning tracing won't work (etc) since we have no dir.
                return "NULL";
            }
        }
        // This method will try to return the full directory path to the Mail\NoRetry folder, whether local or UNC.
        static public string GetMailDirAuto ()
        {
            // Generic error handling for GetMailDirAuto
            try
            {
                // First let's try a quick and dirty method of assuming and guessing the most likely Mail directory.
                // If "NULL" is returned, then we'll skip to the 2-part registry check, which I believe will only
                // really be successful when ran against/on the primary IC server in a s/o pair.
                string CheapTrickMail = CheapTrick();
                if (CheapTrickMail != "NULL")
                {
                    // The value returned should be a valid directory path and return this to the main method.
                    return CheapTrickMail;
                }
                // Continue to the 2-part check if the quick and dirty method check fails.
                else
                {
                    TraceLogging.Info("Trying to automatically determine the Mail directory path using the 2-part registry check.");
                    // If "NULL" is returned, then we couldn't obtain the IC site name due to a error.
                    // If "" is returned, then the SITE key exists but the registry key value is empty,
                    // which I don't believe should  occur since that means something may be terribly wrong with the IC server's registry.
                    // If null is returned, then the SITE key likely doesn't exist.
                    // In EACH scenario, we can't ultimately find the path for the Mail  folder, so prompt for path.
                    string ICSiteNameReg = GetICSiteNameReg();
                    if (ICSiteNameReg == "NULL" || ICSiteNameReg == "" || ICSiteNameReg == null)
                    {
                        // We couldn't automatically obtain the ICSiteName so we'll return "manual" for another method 
                        // that will pop a new form to enter the Mail directory path.
                        TraceLogging.Warning("Failed to automatically obtain the Mail directory path.");
                        return "manual";
                    }
                    // We obtained the ICSiteName - \[SiteName].  The "\" is stripped.  Attempt the Root Path value using SiteName as input.
                    else
                    {
                        TraceLogging.Info("IC site name retrieved successfully.");
                        string MailDirReg = GetMailDirReg(ICSiteNameReg);
                        TraceLogging.Info("Mail directory path returned: " + MailDirReg);
                        if (MailDirReg == "NULL" || MailDirReg == "" || MailDirReg == null)
                        {
                            // We couldn't automatically obtain the path+value so we'll return "manual" for another method 
                            // that will pop a new form to enter the Mail directory path.
                            TraceLogging.Warning("Failed to  obtain the mail root path using the IC site name.");
                            return "manual";
                        }
                        else
                        {
                            // This is the full path to return, obtained from the registry (Utility most likely ran ON server)
                            // If the directory exists, return it.  If not, then return "manual" and use the GetMailDirManual() method
                            // I would never expect the directory to not exist, however, I'd like to catch if it doesn't.
                            if (Directory.Exists(MailDirReg))
                            {
                                TraceLogging.Info("The full Mail directory path exists and will be set to: " + MailDirReg);
                                return MailDirReg;
                            }
                            else
                            {
                                TraceLogging.Info("The Mail directory path does NOT exist.  Failed to automatically obtain the Mail directory path using the IC server name.");
                                return "manual";
                            }
                        }
                    }
                }
            }
            // Generic catch; log; return "manual" to pop the Windows form for manual entry.
            catch (Exception ex)
            {
                TraceLogging.Warning("Exception caught in GetMailDirAuto: " + ex.Message);
                return "manual";
            }
        }
        // Use this quick and dirty method for guessing the Mail directory and check if it exists.
        // If it doesn't exist, return "NULL", then use the 2-part check.
        static public string CheapTrick()
        {
            TraceLogging.Info("Making assumptions and testing the quickest best guess of the mail directory.");
            // Obtain reference to the HKLM registry key
            RegistryKey rkHKLM = Registry.LocalMachine;
            // This will be assigned later with an OpenSubKey method
            RegistryKey InteractiveIntelligenceKeyLeft;

            // This is the Reg key containing the value of the [drive]\I3\IC path
            string ValueKeyName = "Value";
            // This is the string of the [drive]\I3\IC path.  Will be the returned string.
            string I3ICPath;

            // Obtain reference to SOFTWARE\\Interactive Intelligence subkey
            try
            {
                // Open the left-pane key
                InteractiveIntelligenceKeyLeft = rkHKLM.OpenSubKey("SOFTWARE\\Interactive Intelligence");
                // Obtain the string value of the ValueKeyName "Value" right-pane
                I3ICPath = ((string)InteractiveIntelligenceKeyLeft.GetValue(ValueKeyName.ToUpper()));
                // This is the *string value* return of:
                // HKEY_LOCAL_MACHINE\SOFTWARE\Interactive Intelligence, key "Value", *value [string]*
                TraceLogging.Info("[drive]\\I3\\IC path returned: " + I3ICPath);
                // Append \Mail to the returned value.
                I3ICPath = I3ICPath + "Mail\\";
                TraceLogging.Info("Appending \\Mail and checking whether the directory exists: " + I3ICPath);
                // And check whether I3ICPath exists.
                if (Directory.Exists(I3ICPath))
                {
                    TraceLogging.Info("The path exists and will be used for the Mail directory path: " + I3ICPath);
                    return I3ICPath;
                }
                else
                {
                    // The I3ICPath directory does NOT exist.
                    TraceLogging.Warning("The path does not exist: " + I3ICPath);
                    return "NULL";
                }
            }
            catch (Exception ex)
            {
                // Error while opening SOFTWARE\\Interactive Intelligence.  Only throw Warning since not critical.
                TraceLogging.Warning("Error while obtaining the value of the 'Value' key under HKEY_LOCAL_MACHINE\\SOFTWARE\\Interactive Intelligence.  Error:  " + ex.Message);
                // Close the HKLM key...
                rkHKLM.Close();
                return "NULL";
            }
            // Close both RegistryKey references
            InteractiveIntelligenceKeyLeft.Close();
            rkHKLM.Close();
        }
        // Pop a new form to obtain the Mail root path manually - local or UNC network share.
        static public string[] GetMailDirManual()
        {
            // Generic error handling for GetMailDirManual.
            try
            {
                TraceLogging.Info("Trying to manually obtain the Mail directory path.  Launching window for user input.");
                // Instanstiate the form object ( directory path entry)
                MailDirForm MailDirForm = new MailDirForm();
                // To be used to hold the true/false value for the option to use the Other Directory feature.  Default to false.
                string OtherDirectoryFormOption = "False";
                // Will be returned as the full  directory path via manual prompt input from the form.
                string DirManualTemp = "NULL";
                // As long as the DirManualTemp var hasn't been set, pop the form again and again.
                while (DirManualTemp == "NULL")
                {
                    // Pop the form.
                    if (MailDirForm.ShowDialog() == DialogResult.OK)
                    {
                        // Obtain the entered directory from the form.  By default, this is the path to the Mail directory.
                        string DirectoryEntered = MailDirForm.GetDirectoryEntered();
                        // Obtain the state (true/false) of the checkbox for "Other Directory".  This overrides t default assumption of the Mail directory 
                        // such as no longer assuming a NoRetry or Outbox directory.  The XML files should exist in this root directory.
                        bool OtherDirectoryFormOptionbool = MailDirForm.GetOtherDirectory();
                        // Convert the bool to string in order to return in a string array.
                        OtherDirectoryFormOption = OtherDirectoryFormOptionbool.ToString();
                        // what to do with new vars??***
                        TraceLogging.Info("Other Directory checkbox enabled: " + OtherDirectoryFormOption);
                        TraceLogging.Info("Directory path entered (OK pressed): " + DirectoryEntered);
                        // Before saving the text box value to DirManualTemp, confirm the directory exists.
                        if (Directory.Exists(DirectoryEntered))
                        {
                            TraceLogging.Info("Directory path entered exists.");
                            // Remove all trailing backslashes and ad one back to the end for formatting purposes.
                            DirManualTemp = RemoveTrailingBackslashesAddOneBack(DirectoryEntered);
                        }
                        else if (DirectoryEntered == @"e.g., D:\I3\IC\Mail or \\servername\Mail")
                        {
                            // Do nothing; default text pre-entered in the text box.  Loop back to beginning of while.
                        }
                        else
                        {
                            TraceLogging.Warning("Directory path entered does NOT exist!  Please try again (re-pop Window).");
                            MessageBox.Show("Path does not exist!  Please try again.");
                        }
                    }
                    else
                    {
                        // I'm assuming the Windows form was closed out.  Prompt to confirm whether the application should exit.
                        TraceLogging.Verbose("The Mail directory entry form was closed, and since there is no Mail directory to work from, the application will prompt to confirm termination.");
                        /*string header = "Terminate Application?";   // *** This doesn't work due to below causing an exception passing vars to form.
                        string message = "Are you sure you'd like to exit the application?";
                        string button1 = "Exit";
                        string button2 = "Cancel";*/
                        //ConfirmDialog ConfirmDialog = new ConfirmDialog(header, message, button1, button2);  //***This doesn't work; throws exception
                        ConfirmDialog ConfirmDialog = new ConfirmDialog();
                        if (ConfirmDialog.ShowDialog() == DialogResult.Yes)
                        {
                            // Proceed with closing the application
                            TraceLogging.Warning("The application was intentionally terminated by the user.");
                            Application.Exit();
                            Environment.Exit(0);  // Code of 0 tells Windows it was successfully terminated.
                        }
                        else  // Don't close the application and reprompt the form to enter the manual Mail directory
                        {
                        }
                    }
                }
                // This string array will contain the directory path entered as well as "true" or "false" to handle the Other Directory feature
                // DirAndOption[0] = directory path; DirAndOption[1] = option enabled?
                string[] DirAndOption = new string[2];
                DirAndOption[0] = DirManualTemp;
                DirAndOption[1] = OtherDirectoryFormOption;
                return DirAndOption;
            }
            // Generic catch; log; recall this method again.
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught while handling manual Mail directory entry from the Windows form: " + ex.Message);
                TraceLogging.Error("Exception caught while handling manual Mail directory entry from the Windows form: " + ex.Message);
                // I'm not sure what this will do.  *** Try to reproduce.
                return GetMailDirManual();
            }
        }
        // Get the IC site name from the registry we are pointed to
        // HKEY_LOCAL_MACHINE\SOFTWARE\Interactive Intelligence\EIC\Directory Services\Root, key "Site", value [string]
        // Returns include: 1) IC site name; 2) "NULL" - string return where Root subkey throws error; 3) null - ICSiteName IS null
        static public string GetICSiteNameReg()
        {
            TraceLogging.Info("Mail directory check - Part 1: Trying to obtain the IC site name from the registry.");
            // Obtain reference to the HKLM registry key
            RegistryKey rkHKLM = Registry.LocalMachine;
            // This will be assigned later with an OpenSubKey method
            RegistryKey RootKeyLeft;

            // This is the Reg key containing the value of the IC site name 
            string SiteKeyName = "SITE";
            // This is the string of the site name obtained from the Root key.  Will be the returned string.
            string ICSiteName;

            // Obtain reference to SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root subkey
            try
            {
                // Open the left-pane key
                RootKeyLeft = rkHKLM.OpenSubKey("SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root");
                // Obtain the string value of the KeyName (SITE) right-pane
                ICSiteName = ((string)RootKeyLeft.GetValue(SiteKeyName.ToUpper()));
                TraceLogging.Info("GetICSiteName is currently non-functional.  Handle REG_MULTI_SZ.");
                //*** THIS IS NOT CURRENTLY WORTH THE TIME SINCE IT WILL RARELY NEED TO BE USED.  Do later if time permits.

                //Registry.LocalMachine.OpenSubKey("SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root").GetValue("SITE".
                // Strip off "/" at the beginning of the value of SITE.
                ICSiteName = ICSiteName.TrimStart('\\');
                // This is the *string value* return of:
                // HKEY_LOCAL_MACHINE\\SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root, key "SITE", *value [string]*
                TraceLogging.Info("IC site name returned: " + ICSiteName);
                return ICSiteName;
            }
            catch (Exception ex)
            {
                // Error while opening SOFTWARE\\Interactive Intelligence\\EIC\\Notifier
                TraceLogging.Warning("Error while obtaining the value of the 'SITE' key under HKEY_LOCAL_MACHINE\\SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root.  Error:  " + ex.Message);
                // Close the HKLM key...
                rkHKLM.Close();
                return "NULL";
            }
            // Close both RegistryKey references
            RootKeyLeft.Close();
            rkHKLM.Close();

        }
        // Use the output from the GetICServerNameReg method as an input here to find the Mail directory path
        static public string GetMailDirReg(string ICSiteName)
        {
            TraceLogging.Info("Mail directory check - Part 2: Trying to obtain the mail root path from the registry using the IC site name.");
            // Obtain reference to the HKLM registry key
            RegistryKey rkHKLM = Registry.LocalMachine;
            // This will be assigned later with an OpenSubKey method
            RegistryKey RootPathKeyLeft;

            // This is the Reg key containing the value of the Mail directory
            string RootPathKeyName = "Root Path";
            // This is the string of the Root Path key used for the Mail directory path.  Will be the returned string.
            string RootPathValue;

            // Obtain reference to SOFTWARE\Interactive Intelligence\EIC\Directory Services\Root\  [ICSiteName]   \Production\Configuration\Mail
            try
            {
                // Open the left-pane key
                RootPathKeyLeft = rkHKLM.OpenSubKey("SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root\\" + ICSiteName + "\\Production\\Configuration\\Mail");
                // Obtain the string value of the KeyName (NotifierServer) right-pane
                RootPathValue = ((string)RootPathKeyLeft.GetValue(RootPathKeyName.ToUpper()));
                // This is the *string value* return of:
                // HKEY_LOCAL_MACHINE\SOFTWARE\Interactive Intelligence\EIC\Directory Services\Root\[ICServerName]\Production\Configuration\Mail, key "Root Path", *value [string]*
                return RootPathValue;
            }
            catch (Exception ex)
            {
                // Error while opening SOFTWARE\\Interactive Intelligence\\EIC\\Notifier
                TraceLogging.Error("Error while obtaining the value of the 'Root Path' key under HKEY_LOCAL_MACHINE\\SOFTWARE\\Interactive Intelligence\\EIC\\Directory Services\\Root\\" + ICSiteName + "\\Production\\Configuration\\Mail.  Error: " + ex.Message);
                // Close the HKLM key...
                rkHKLM.Close();
                // Return "NULL" so that the Window will pop for manual user input of the Mail directory path.
                return "NULL";
            }
            // Close both RegistryKey references
            RootPathKeyLeft.Close();
            rkHKLM.Close();
        }
            // The full path to the Mail directory is the input and the return merely appends \NoRetry for XML workspace.
        static public string SetMailNoRetryDir(string MailDir)
        {
             TraceLogging.Info("Trying to set the Mail\\NoRetry\\ directory.");
             string MailNoRetryDirvar = MailDir + "NoRetry\\";
             // Confirm this NoRetry directory exists.
             if (Directory.Exists(MailNoRetryDirvar))
             {
                 TraceLogging.Info("Mail\\NoRetry\\ exists and will be set to: " + MailNoRetryDirvar);
                 return MailNoRetryDirvar;
             }
             // If the NoRetry directory doesn't exist, throw error and return "null".
             else
             {
                 TraceLogging.Error("Mail\\NoRetry\\ path not found or set: " + MailNoRetryDirvar + ".  XML messages can't be retrieved!  Please ensure this directory exists and can be accessed.");
                 MessageBox.Show("Directory path not found or set: " + MailNoRetryDirvar + ".  XML messages can't be retrieved!  Please ensure this directory exists and can be accessed.");
                 return "ERROR";
             }
        }

        // The full path to the Mail directory is the input and the return merely appends \Outbox for XML (message) retries
        static public string SetMailOutboxDir(string MailDir)
        {
            TraceLogging.Info("Trying to set the Mail\\Outbox\\ directory.");
            string MailOutboxDirvar = MailDir + "Outbox\\";
            // Confirm this Outbox directory exists.
            if (Directory.Exists(MailOutboxDirvar))
            {
                TraceLogging.Info("Mail\\Outbox\\ exists and will be set to: " + MailOutboxDirvar);
                return MailOutboxDirvar;
            }
            // If the Outbox directory doesn't exist, throw error and return "null".
            else 
            {
                TraceLogging.Error("Mail\\Outbox\\ path not found or set: " + MailOutboxDirvar + ".  XML messages can't be retried!  Please ensure this directory exists and can be accessed.");
                MessageBox.Show("Directory path not found or set: " + MailOutboxDirvar + ".  XML messages can't be retried!  Please ensure this directory exists and can be accessed.");
                return "ERROR";
            }
        }

        // Determine the number of XML files in the Mail directory, which could be Mail\NoRetry or possibl
        // a root folder if I implement the ability to point to a single folder with no presumption about the NoRetry subfolder.
        static public int GetXMLMailCount(string XMLMaildir)
        {
            int fileCount = Directory.GetFiles(XMLMaildir, "*.xml").Length;
            TraceLogging.Verbose("Obtain the total number (count) of XML files in the specified directory: " + XMLMaildir + ".  Count: " + fileCount);
            return fileCount;
        }
        // Obtain an array of the XML files by directory + name to be read into the main Windows form
        static public string[] GetXMLFileList(string NumberofFiles, string MailNoRetryDirectoryOrOtherXMLPath)
        {   // The count is the filtered number selected by the user in the XMLRetrievalSettings Windows form.
            int XMLCount = int.Parse(NumberofFiles);
            // Get all file names (full dir path) in the specified directory since there doesn't seem to be a way to pass a file number count into it.
            string[] UnfilteredXMLFileNames = Directory.GetFiles(MailNoRetryDirectoryOrOtherXMLPath, "*.xml");
            // To be used to store the filtered XML file list.  Filter the UnfilteredXMLFileNames array within the while loop below.
            string[] FilteredXMLFileList = new string[XMLCount];
            TraceLogging.Verbose("Obtaining the filtered XML file list.  Directory: " + MailNoRetryDirectoryOrOtherXMLPath + ".  Number of files: " + NumberofFiles);
            try
            {
                int Counter = 0;
                while (Counter < XMLCount)
                {
                    //MessageBox.Show("File name: " + UnfilteredXMLFileNames[Counter] + " counter: " + Counter);
                    FilteredXMLFileList[Counter] = UnfilteredXMLFileNames[Counter];
                    int DisplayCount = Counter + 1;  // Used to increase the Counter by 1 so the logging starts at 1 rather than 0.
                    TraceLogging.Verbose("File " + DisplayCount.ToString() + ": " + FilteredXMLFileList[Counter]);
                    Counter++;
                }
                // Return the list of XML names + path that the user wanted (all, specified count).
                return FilteredXMLFileList;
            }
            catch (Exception ex)  // *** update / change handling
            {
                if (ex.Message == "Index was outside the bounds of the array.")
                {
                    MessageBox.Show("Error: likely successful loop exit.");
                }
                else
                {
                    MessageBox.Show("loop exception: " + ex.Message);
                }
            }
            return FilteredXMLFileList;
            
            //XmlDocument doc = new XmlDocument();

            //doc.Load(@"C:\i3\ic\mail\NoRetry\507963150TwoEachBccSU9.xml");

            //XmlNode node = doc.FirstChild;

        }
        // If the input string has trailing backslashes (/'s), this will strip off each
        public static string RemoveTrailingBackslashes(string Path)
        {
            Regex ExpressionPattern = new Regex("\\A(.+?)(\\\\*)\\Z");  // $1 before trailing backslashes, $2 trailing backslashes
            return ExpressionPattern.Replace(Path, "$1"); // Removes trailing backslashes in Path
        }
        public static string RemoveTrailingBackslashesAddOneBack(string Path)
        {
            Regex ExpressionPattern = new Regex("\\A(.+?)(\\\\*)\\Z");  // $1 before trailing backslashes, $2 trailing backslashes
            return ExpressionPattern.Replace(Path, "$1\\");  // Takes the result with no ending backslash(es) and adds a backslash.
        }
        // This will be used to return the server name, the app is ran against, in the XMLRetrievalSettings form.
        public static string ServerRanAgainst(string CurrentDirectory)
        {
            string ServerName = "NULL";
            Regex ExpressionPattern = new Regex("(\\\\\\\\)*([^\\\\]*)(.*)");  // $1= \\ (only 2), $2= server name, $3= trailing characters after server name (don't need)
            string Match1DoubleSlash = ExpressionPattern.Replace(CurrentDirectory, "$1");
            string Match2ServerName = ExpressionPattern.Replace(CurrentDirectory, "$2");
            // If the current directory starts with a \\, then we'll know it's a UNC path and the following value should be the server name running the app against.
            if (Match1DoubleSlash == "\\\\")
            {
                ServerName = Match2ServerName;
            }
            // If the current directory doesn't start with a \\, then assume the application is being ran on the IC server.
            else
            {
                ServerName = Environment.MachineName;
            }
            return ServerName;

        }

/* smtp example
        static public void SendEmail()
        {
            
        //Initialize a SmtpClient object as follows:
            
        SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
         
        //Initialize a NetworkCredential object if your SMTP server requires a login name and password. You can do so as follows:
            
        NetworkCredential credentials = new NetworkCredential("username", "password");
            
        client.Credentials = credentials;

        // Initialize a new MailMessage object as follows:

        MailMessage message = new MailMessage();

        message.From = "from@ouremail.com";
        message.To = "to@anaddress.com";
        message.Subject = "A Subject";
        message.Body = "The message body goes here.";
        SmtpMail.SmtpServer = "the same SMTP server address as the SmtpClient object";
        //Finally, send the email message using the SmtpClient object as follows:

        Client.Send(message);

        }
*/
    }
}


// test code to cause exception
/*
                int x = 0;
                int div = 100 / x;
                Console.WriteLine(div);
*/