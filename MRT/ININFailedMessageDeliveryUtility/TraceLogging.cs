using System;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Principal;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;



namespace WindowsFormsApplication1
{

    public static class TraceLogging
    {
        /*public TraceLogging()  // testing, keep for now ***
        {

        }*/
        // On startup of the utility, dynamically build the configuration file to be used for modifying trace topics
        public static void CreateDefaultAppConfigFile(string UtilityConfigDirectory)
        {
            try
            {
                // First check whether the file exists.  If it does, then do nothing.  If it does not, then create it.
                if (File.Exists(UtilityConfigDirectory + "Message Recovery Tool.exe.config"))
                {
                    Info("Using existing trace configuration file: " + UtilityConfigDirectory + "Message Recovery Tool.exe.config");
                }
                // Create the file under the \Message Recovery Tool folder if it ddoesn't exist.
                else
                {
                    // Create the document    
                    XmlDocument AppConfig = new XmlDocument();

                    // Insert warning about not modifying the file 
                    string CommentWarningstring = " WARNING: DO NOT MODIFY the contents of this configuration file manually.  ";
                    CommentWarningstring += "To modify the trace level, do so within the Message Recovery Tool, which modifies the value below under switches. ";
                    XmlNode CommentWarningNode = AppConfig.CreateComment(CommentWarningstring);
                    AppConfig.AppendChild(CommentWarningNode);


                    //AppConfigComment = AppConfig.CreateComment("test");
                    // Create the header declaration:# <?xml version="1.0" encoding="UTF-8"?>
                    XmlNode AppConfigNode = AppConfig.CreateXmlDeclaration("1.0", "UTF-8", null);

                    // Open the configuration node:# <configuration>
                    XmlNode ConfigurationNode = AppConfig.CreateElement("configuration");

                    // Open the system.diagnostics node:# <system.diagnostics>
                    XmlNode SystemDiagnosticsNode = AppConfig.CreateElement("system.diagnostics");

                    // Open the trace node:# <trace
                    XmlNode TraceNode = AppConfig.CreateElement("trace");
                    // Create two attributes under the trace name: # autoflush="true" indentsize="4">
                    XmlAttribute TraceAttribute1 = AppConfig.CreateAttribute("autoflush");
                    TraceAttribute1.Value = "true";
                    TraceNode.Attributes.Append(TraceAttribute1);
                    XmlAttribute TraceAttribute2 = AppConfig.CreateAttribute("indentsize");
                    TraceAttribute2.Value = "4";
                    TraceNode.Attributes.Append(TraceAttribute2);

                    // Open the listeners node:# <listeners>
                    XmlNode ListenersNode = AppConfig.CreateElement("listeners");

                    // Open the add node:# <add
                    XmlNode AddNode = AppConfig.CreateElement("add");
                    // Create the add node attributes:# name="myTraceSource" type="System.Diagnostics.TextWriterTraceListener" 
                    // initializeData="Message Recovery Tool.log"
                    XmlAttribute NameAttribute = AppConfig.CreateAttribute("name");
                    NameAttribute.Value = "myTraceSource";
                    AddNode.Attributes.Append(NameAttribute);
                    XmlAttribute TypeAttribute = AppConfig.CreateAttribute("type");
                    TypeAttribute.Value = "System.Diagnostics.TextWriterTraceListener";
                    AddNode.Attributes.Append(TypeAttribute);
                    XmlAttribute InitializeDataAttribute = AppConfig.CreateAttribute("initializeData");
                    InitializeDataAttribute.Value = "Message Recovery Tool.log";
                    AddNode.Attributes.Append(InitializeDataAttribute);
                    // Close the add node:# />
                    ListenersNode.AppendChild(AddNode);

                    // Open the remove node:# <remove
                    XmlNode RemoveNode = AppConfig.CreateElement("remove");
                    // Create the remove node attributes:# name="Default"
                    XmlAttribute RemoveNameAttribute = AppConfig.CreateAttribute("name");
                    RemoveNameAttribute.Value = "Default";
                    RemoveNode.Attributes.Append(RemoveNameAttribute);
                    // Close the remove node:# />
                    ListenersNode.AppendChild(RemoveNode);

                    // Close the listeners node:# </listeners>
                    TraceNode.AppendChild(ListenersNode);
                    // Close the trace node:# </trace>
                    SystemDiagnosticsNode.AppendChild(TraceNode);

                    // Open the switches node:# <switches>
                    XmlNode SwitchesNode = AppConfig.CreateElement("switches");

                    // Trace comment information about trace switch value meanings
                    XmlNode CommentTraceValue = AppConfig.CreateComment(" Trace value: 0 [off]; 1 [error]; 2 [warning - default]; 3 [info]; 4 [verbose] ");
                    SwitchesNode.AppendChild(CommentTraceValue);

                    // Open the add node:# <add
                    XmlNode AddNode2 = AppConfig.CreateElement("add");
                    // Create the add node attributes:# name="TraceSwitch1" value="4"
                    XmlAttribute NameAttribute2 = AppConfig.CreateAttribute("name");
                    NameAttribute2.Value = "TraceSwitch1";
                    AddNode2.Attributes.Append(NameAttribute2);
                    XmlAttribute ValueAttribute = AppConfig.CreateAttribute("value");
                    ValueAttribute.Value = "2";
                    AddNode2.Attributes.Append(ValueAttribute);
                    // Close the add node:# />
                    SwitchesNode.AppendChild(AddNode2);

                    // Close the switches node:# </switches>
                    SystemDiagnosticsNode.AppendChild(SwitchesNode);
                    // Close the system.diagnostics node: </system.diagnostics>
                    ConfigurationNode.AppendChild(SystemDiagnosticsNode);
                    // Close the configuration node: </configuration>
                    AppConfig.AppendChild(ConfigurationNode);

                    // Save the file.  As of now (7/16) the name IS name sensitive.
                    AppConfig.Save(UtilityConfigDirectory + "Message Recovery Tool.exe.config");
                }
            }
            // The App.config file couldn't be created and tracing will NOT be done!
            catch (Exception ex)
            {
                string message = "There was an error creating and saving the tracing configuration file.";
                message += "This does not impact functionality, ";
                message += "however, the utility  will not trace to a log file for debugging purposes.";
                MessageBox.Show(message + "\r\n\r\nError: " + ex.Message);  

            }

            /*  FINAL OUTPUT to file (7/16/2011)
              
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.diagnostics>
    <trace autoflush="true" indentsize="4">
      <listeners>
        <add name="myTraceSource" type="System.Diagnostics.TextWriterTraceListener" initializeData="Message Recovery Tool.log" />
        <remove name="Default" />
      </listeners>
    </trace>
    <switches>
      <add name="TraceSwitch1" value="2" />
    </switches>
  </system.diagnostics>
</configuration> 
              
             */
        }
        // Modify the trace level WARNING! Currently, this will only work with one switch to my knowledge, fine for now.
        public static void ModifyAppConfigFileTraceLevel(int TraceLevel, string UtilityConfigDir)
        {
            try
            {
                // The trace value will never be above 4 if set within the utility, however,
                // if set and read from the app config file, then possible.  Convert all values > 4, to 4.
                int newValue;
                if (TraceLevel > 4)
                {
                    newValue = 4;
                }
                else
                {
                    newValue = TraceLevel;
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(UtilityConfigDir + "Message Recovery Tool.exe.config");
                // This assumes there is only one switch and that the XML file is layed out t way still.
                XmlNode node = xmlDoc.SelectSingleNode("configuration/system.diagnostics/switches/add");
                node.Attributes[1].Value = newValue.ToString();
                xmlDoc.Save(UtilityConfigDir + "Message Recovery Tool.exe.config");
                SetTraceLevel(UtilityConfigDir, newValue.ToString());
                TraceAlways("Tracing level changed to: " + newValue);
            }
            catch (Exception ex)
            {
                // If the trace level change fails, pop a message box stating so and log error - tracealways
                MessageBox.Show("Tracing level could not be changed!  \r\n\r\nError: " + ex.Message);
                TraceAlways("Tracing level could not be changed!  Error: " + ex.Message);
            }
        }
        public static void TraceSystemInformation()
        {
            // Beginning of the log header. 

            MessageOnly("\r\n--*Date*---|----*Time*----|*Trace Level *|----*Method*-------------|-----*Message*----------------------\r\n");

            TraceAlways("######  *System Information*  ######");

            // Trace the application utility version.
            TraceAlways("Message Recovery Tool version: pre-alpha | 0.0");
            // Trace time zone.
            TimeZone TimeZone = TimeZone.CurrentTimeZone;
            TraceAlways("Time zone: " + TimeZone.StandardName);
            // Trace the machine name.
            string MachineName = Environment.GetEnvironmentVariable("COMPUTERNAME");
            TraceAlways("Machine name: " + MachineName);
            // Trace the domain or workgroup name and user name.
            string UserName = WindowsIdentity.GetCurrent().Name;
            TraceAlways("User: " + UserName);

            TraceAlways("####################################\r\n");

        }
        public static string TraceLevel()
        {
            // Instantiate the first switch as per the App.config name for the purpose of obtaining the tracing level value.
            TraceSwitch TraceSwitch1 = new TraceSwitch("TraceSwitch1", "First Switch");
            // Obtain the trace level (0-4).
            string TraceLevel = TraceSwitch1.Level.ToString();
            return TraceLevel;
        }
        // Assumes preformating of 0-4.  Change the tracer to obey new tracing output.
        public static void SetTraceLevel(string UtilityConfigDir, string newValue)
        {
            // Instantiate the first switch as per the App.config name for the purpose of setting the tracing level value.
            //TraceSwitch TraceSwitch1 = new TraceSwitch("TraceSwitch1", "First Switch", newValue);
            // Set the trace level (0-4).  Anything above 4 is handled by the calling method (ModifyAppConfigFileTraceLevel)

            /***
            MessageBox.Show("Util dir: " + UtilityConfigDir);
            MessageBox.Show("App config file location before: " + System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile = UtilityConfigDir + "Message Recovery Tool.exe.config";
            MessageBox.Show("App config file location after: " + System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            */

            
            
        }
        // This will be used to only display the message, excluding any timestamp/level/method information.  Always traced.
        public static void MessageOnly(string message)
        {
            WriteEntry(message, "Message", "Only");
        }
        // Always trace anything passed into this method even if tracing is set to 0.  
        // Formatting prefix of timestamp, trace level, metod, message is still written.
        public static void TraceAlways(string message)
        {
            // Spaces were added for formating/alligning purposes.
            WriteEntry(message, "Trace", "Always      ");
        }
        // Trace errros at level 1 for exceptions.
        public static void Error(Exception ex)
        {
            // Spaces were added for formating/alligning purposes.
            WriteEntry(ex.Message, "TraceSwitch1", "TraceError  ");
        }
        // Trace errors at level 1.
        public static void Error(string message)
        {
            // Spaces were added for formating/alligning purposes.
            WriteEntry(message, "TraceSwitch1", "TraceError  ");
        }
        // Trace warnings at level 2.
        public static void Warning(string message)
        {
            WriteEntry(message, "TraceSwitch1", "TraceWarning");
        }
        // Trace info at level 3.
        public static void Info(string message)
        {
            // Spaces were added for formating/alligning purposes.
            WriteEntry(message, "TraceSwitch1", "TraceInfo   ");
        }
        // Trace verbose at level 4.
        public static void Verbose(string message)
        {
            WriteEntry(message, "TraceSwitch1", "TraceVerbose");
        }
        // Pass in the message content, name of the switch to use, and the tracing level to be properly displayed.
        private static void WriteEntry(string message, string switchname, string leveltype)
        {
            // Obtain the method in which the trace statement was called to display.
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(2);
            MethodBase methodBase = stackFrame.GetMethod();
            // Instantiate the first switch as per the App.config name, description, and default value of 2 - error/warning.
            TraceSwitch TraceSwitch1 = new TraceSwitch("TraceSwitch1", "First Switch", "2");
            // Use for the switch statement below to build the TraceSwitch tracing level parameter/property.
            string TraceParameter = switchname + "." + leveltype;
            // Format the trace line with a timestamp, trace level, method, and message.
            string TraceString = string.Format("{0} | {1} | {2} | {3}", DateTime.Now.ToString("yyyy-MM-dd | HH:mm:ss") + "_" + DateTime.Now.Millisecond, leveltype, methodBase.Name, "#: " + message);
            
            switch(TraceParameter)
            {
                case "TraceSwitch1.TraceError  ":  // Spaces were added for formating/alligning purposes.
                    Trace.WriteLineIf(TraceSwitch1.TraceError, TraceString);
                    break;  
                case "TraceSwitch1.TraceWarning":
                    Trace.WriteLineIf(TraceSwitch1.TraceWarning, TraceString);
                    break;
                case "TraceSwitch1.TraceInfo   ":  // Spaces were added for formating/alligning purposes.
                    Trace.WriteLineIf(TraceSwitch1.TraceInfo, TraceString);
                    break;
                case "TraceSwitch1.TraceVerbose":
                    Trace.WriteLineIf(TraceSwitch1.TraceVerbose, TraceString);
                    break;
                // This will catch any message that doesn't want the timestamp/level/method traced as a prefix.
                    // This will always trace.
                case "Message.Only":
                    Trace.WriteLine(message);
                    break;
                case "Trace.Always      ":  // Spaces were added for formating/alligning purposes.
                    Trace.WriteLine(TraceString);
                    break;
                default:
                    // A trace switch and level was not matched; throw warning.
                    Trace.WriteLineIf(TraceSwitch1.TraceWarning, "A trace switch and level was not matched - switch() | default: [likely benign]");
                    break;
            }
            
        } 
    }
}
