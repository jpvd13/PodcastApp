﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    class XmlWriter
    {
        string path = new DirectoryCreator().CreateMainDirectory();
        public XmlWriter()
        {

        }

        public void CreatePodcastXml(Podcast pod)
        {

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement("channel",
                            new XElement("url", pod.Url),
                            new XElement("title", pod.PodTitle),
                            new XElement("category", pod.Category),
                            new XElement("frequency", pod.Frequency)));

            for (var i = 0; i < pod.Episodes.Count; i++)
            {
                xDoc.Root.Add(new XElement("item",
                    new XElement("ID", i.ToString()),
                    new XElement("title", pod.Episodes[i].Title),
                    new XElement("description", pod.Episodes[i].Description)
                    ));
            }
            StringWriter sw = new StringWriter();
            xDoc.Save(sw);
            StringManipulator sm = new StringManipulator();
            string newPodTitle = sm.RemoveSpecialChars(pod.PodTitle);
            xDoc.Save(path + @"\" + newPodTitle + ".xml");
        }

        public void CreateCategoriesXml()
        {

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement("channel",
                            new XElement("title", "Categories")));

            Directory.CreateDirectory(path + @"\" + "Categories");
            StringWriter sw = new StringWriter();
            xDoc.Save(sw); 
            xDoc.Save(path + @"\Categories" +@"\" + "Categories" + ".xml");
        }

        public void WriteNewCategory(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + @"\Categories" + @"\" + "Categories" + ".xml");

           // xDoc.Root.Add(new XElement("item",
                 //   new XElement("Name", name)));
                                       
        }
    }
}

