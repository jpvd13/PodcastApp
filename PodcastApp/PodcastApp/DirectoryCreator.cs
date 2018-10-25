using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DirectoryCreator
    {

        public string CreateMainDirectory()
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            Directory.CreateDirectory(xmlDirectory);
            return xmlDirectory;
        }


    }
}
   