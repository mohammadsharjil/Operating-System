using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;

//  [25/3/2007 Created By Naveed $Khan]
// Created AT 20:25

// Student of : Kohat University of Science and Technology 
// Kohat Pakistan
// Email   : nidostyle@gamil.com
// contact : 0322-9093727


namespace MyTaskManager
{
    partial class MainClass
    {
        private XmlTextWriter writer;
        private void ConformXmlFile()
        {
            XmlTextReader myreader = new XmlTextReader("Kill List.xml");

            if (!File.Exists("Kill List.xml"))
            {
                CreateXmlFile("Kill List.xml");
            }
            if (!File.Exists("Except List.xml"))
            {
                CreateXmlFile("Except List.xml");
                SaveExceptFile();
            }
        }

        public void CreateXmlFile(string filepath)
        {

            //FileStream fs = new FileStream("filepath", FileMode.Create);
            writer = new XmlTextWriter(filepath, new System.Text.UTF8Encoding());
            writer.Formatting = System.Xml.Formatting.Indented;
            
            writer.Close();
        }

        #region Saving Funtion
        public void save(string filename, string[] kill_list, int noOfkill)
        {
            
            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ProcessNames");
            }
            catch
            {
                writer = writer = new XmlTextWriter(filename, new System.Text.UTF8Encoding());
                writer.WriteStartDocument();
                writer.WriteStartElement("ProcessNames");
               
            }
            for (int i = 0; i < noOfkill; i++)
            {
                writer.WriteStartElement("process"); // i,e <process>
                writer.WriteString(kill_list[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
        #endregion

        #region SaveExceptFile
        public void SaveExceptFile()
        {
            
                string[] pNames ={ "explorer\r", "spoolsv\r", "svchost\r", "lass\r"
                    , "services\r", "winlogon\r", "csrss\r", "smss\r", "System\r", "intinfo\r" };
                save("Except List.xml", pNames, pNames.Length);
            

        }

        #endregion

       


    }
         
}
