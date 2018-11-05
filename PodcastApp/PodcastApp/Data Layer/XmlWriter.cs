using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
     public class XmlWriter : IPathfinder, IDirectoryCreator
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

        public void CreateCategoryStorage()
        {
            if (!File.Exists(LocalPath + @"\Categories\Categories.xml"))
            {
                XDocument xDoc = new XDocument(
                            new XDeclaration("1.0", "UTF-16", null),
                            new XElement("Categories",
<<<<<<< HEAD
                                new XElement("Category", "Övrigt",
                                new XAttribute("id", 0),
                                new XAttribute("value", "Övrigt"))));
=======
                                new XElement("Category", "Skräck",
                                new XAttribute("value", "Skräck"),
                                new XAttribute("id", 0))));

>>>>>>> 3f70a386699582bf3e97c2167b51d4f5c0db9392

                string categoryPath = LocalPath + @"\Categories\";
                CreateDirectory(categoryPath);

                StringWriter sw = new StringWriter();
                xDoc.Save(sw);
                xDoc.Save(LocalPath + @"\Categories\Categories.xml");
            }
        }
        public void CreateCategory(string name)
        {
            XmlReader xr = new XmlReader();
            int id = xr.GetCategoryId();
            XDocument xDoc = XDocument.Load(LocalPath + @"\Categories\Categories.xml");
            XElement category = xDoc.Element("Categories");
            category.Add(new XElement("Category", name,
                                new XAttribute("value", name),
                                new XAttribute("id", id)));

            xDoc.Save(LocalPath + @"\Categories\Categories.xml");
        }

        public void SaveOriginalFeedXml(XmlDocument doc)
        {
            try
            {
                doc.PreserveWhitespace = true;

                PodcastHandler podHandler = new PodcastHandler();
                string mainTitle = podHandler.GetPodcastTitleFromRss(doc);
                if (mainTitle != "")
                {
                    StringManipulator sm = new StringManipulator();
                    string titleNoSpecialLetter = sm.RemoveSpecialChars(mainTitle) + "Original";

                    CreateDirectory(LocalPath + @"\" + titleNoSpecialLetter);
                    string pathToSave = LocalPath + @"\" + titleNoSpecialLetter + @"\" + titleNoSpecialLetter;

                    doc.Save(pathToSave + ".xml");
                }
            }
            catch (XmlException) { }

        }

        public void DeleteCategory(string name)
        {
            XDocument doc = XDocument.Load(LocalPath + @"\Categories\Categories.xml");
            var q = from node in doc.Descendants("Category")
                    let attr = node.Attribute("value")
                    where attr != null && attr.Value == name
                    select node;
            q.ToList().ForEach(x => x.Remove());
            doc.Save(LocalPath + @"\Categories\Categories.xml");
        }

        public virtual void UpdateCategory(string input, string category)
        {
            XDocument doc = XDocument.Load(LocalPath + @"\Categories\Categories.xml");

            foreach (XElement element in doc.Element("Categories").Descendants())
            {
                if (category == element.Value)
                {
                    element.Attribute("value").Value = input;
                    element.Value = input;
                }
            }
            doc.Save(LocalPath + @"\Categories\Categories.xml");
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

