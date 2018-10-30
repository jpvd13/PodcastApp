using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    class XmlWriter : IPathfinder, IDirectoryCreator
    {
        string LocalPath; 

        public XmlWriter()
        {
            LocalPath = GetPath();
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

            xDoc.Save(LocalPath + @"\" + newPodTitle + ".xml");
        }

        public void CreateCategoriesXml()
        {
            if (!File.Exists(LocalPath + @"\Categories\Categories.xml"))
            {
                XDocument xDoc = new XDocument(
                            new XDeclaration("1.0", "UTF-16", null),
                            new XElement("Categories",
                                new XElement("Category", "Skräck")));

                string categoryPath = LocalPath + @"\Categories\";
                CreateDirectory(categoryPath);

                StringWriter sw = new StringWriter();
                xDoc.Save(sw);
                xDoc.Save(LocalPath + @"\Categories\Categories.xml");
            }
        }

        public void WriteNewCategory(string name)
        {
            XDocument xDoc = XDocument.Load(LocalPath + @"\Categories\Categories.xml");
            XElement category = xDoc.Element("Categories");
            category.Add(new XElement("Category", name));
            xDoc.Save(LocalPath + @"\Categories\Categories.xml");

                                       
        }

        public string GetPath()
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            return xmlDirectory;
           
        }

        public void CreateDirectory(string path)
        {
            string newDirectory = Path.Combine(Environment.CurrentDirectory, path);
            Directory.CreateDirectory(newDirectory);
        }
    }
}

