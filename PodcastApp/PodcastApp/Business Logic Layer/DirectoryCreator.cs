using System;
using System.IO;

namespace WindowsFormsApp1
{
    class DirectoryCreator
    {

        public string CreateDirectory(string directoryName)
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            Directory.CreateDirectory(xmlDirectory);
            return xmlDirectory;
        }
    }
}
   