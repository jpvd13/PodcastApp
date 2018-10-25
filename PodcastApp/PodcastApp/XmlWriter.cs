using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    class XmlWriter
    {

        public XmlWriter()
        {

        }

        public void CreateXml(Podcast pod)
        {

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement("channel",
                            new XElement("title", pod.PodTitle),
                            new XElement("category", pod.Category),
                            new XElement("frequency", pod.Frequency)));

            for (var i = 0; i < pod.Episodes.Count; i++)
            {
                xDoc.Root.Add(new XElement("item",
                    new XElement("title", pod.Episodes[i].Title),
                    new XElement("description", pod.Episodes[i].Description)
                    ));
            }
            StringWriter sw = new StringWriter();
            xDoc.Save(sw);
            StringManipulator sm = new StringManipulator();
            string path = new DirectoryCreator().CreateMainDirectory();
            string newPodTitle = sm.RemoveSpecialChars(pod.PodTitle);
            xDoc.Save(path + @"\" + newPodTitle + ".xml");
        }
    }
}

