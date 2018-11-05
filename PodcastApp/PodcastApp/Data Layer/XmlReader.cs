using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    class XmlReader : IPathfinder

    {
        string LocalDirectory;
        StringManipulator sm = new StringManipulator();

        public XmlReader()
        {
            LocalDirectory = GetPath();
        }

        public List<Podcast> LoadPodcastsXml()
        {
            string[] files = Directory.GetFiles(GetPath(), "*", SearchOption.TopDirectoryOnly);                                                 
            List<Podcast> podcasts =new List<Podcast>();
            List<Episode> episodes = new List<Episode>();

            XmlDocument xDoc = new XmlDocument();

            foreach (var file in files)
            {
                xDoc.Load(file);
                XmlNodeList items = xDoc.SelectNodes("//item");

                int i = 0;
                foreach (var item in items)
                {
                    string episodeDescription = items[i].SelectSingleNode("description").InnerText;
                    string episodeTitle = items[i].SelectSingleNode("title").InnerText;
                    string episodeId = items[i].SelectSingleNode("ID").InnerText;
                    episodes.Add(new Episode(episodeTitle, episodeDescription, int.Parse(episodeId)));

                    i++;
                }

                XmlNodeList title = xDoc.SelectNodes("//channel");

                var x = 0;
                string podcastTitle = "";
                string frequency = "";
                string category = "";
                string url = "";

                foreach (var smth in title)
                {
                    podcastTitle = title[x].SelectSingleNode("title").InnerText;
                    category = title[x].SelectSingleNode("category").InnerText;
                    frequency = title[x].SelectSingleNode("frequency").InnerText;
                    url = title[x].SelectSingleNode("url").InnerText;

                    x++;
                }

                var pod = new Podcast(url, podcastTitle, frequency, category, episodes, episodes.Count());
                podcasts.Add(pod);
                episodes.Clear();
            }
            return podcasts;
        }

        public XmlDocument LoadLocalXmlFileByTitle(string title)
        { 
            string titleNoSpecialChars = sm.RemoveSpecialChars(title);
            string[] files = Directory.GetFiles(GetPath(), "*", SearchOption.TopDirectoryOnly);
            XmlDocument xDoc = new XmlDocument();

            var isFound = false;
            var i = 0;
            while (!isFound)
            {
                if (files[i].ToString().Contains(titleNoSpecialChars))
                {
                    xDoc.Load(files[i]);
                    isFound = true;
                }
                i++;
            }
            return xDoc;
        }

        public List<Episode> GetEpisodesByPodcastTitleXml(string title)
        {
            XmlDocument xDoc = LoadLocalXmlFileByTitle(title);
            XmlNodeList items = xDoc.SelectNodes("//item");
            List<Episode> episodes = new List<Episode>();
            
            int x = 0;
            foreach (var item in items)
            {         
              string episodeTitle = items[x].SelectSingleNode("title").InnerText;
              string episodeDescription = items[x].SelectSingleNode("description").InnerText;
              string episodeId = items[x].SelectSingleNode("ID").InnerText;
              episodes.Add(new Episode(episodeTitle, episodeDescription, int.Parse(episodeId)));
              x++;
            }            
            return episodes;
        }

      public string GetXmlElementWithoutTags(string element)
        {          
               string xmlEscape = StringManipulator.EscapeXMLValue(element);             
                string textWithoutTags = "";
            
                var startAsXml = "<root>" + xmlEscape + "</root>";
                var doc = XElement.Parse(startAsXml);
                

                foreach (var node in doc.Nodes())
                {
                    if (node.NodeType == XmlNodeType.Text)
                    {
                        textWithoutTags += node.ToString().Trim();
                    }
                }
            string xmlUnescape = StringManipulator.UnescapeXMLValue(textWithoutTags);
            return xmlUnescape;                      
        }

        public List<Category> GetCategories()
        {
            List<Category> categoriesList = new List<Category>();
            if (File.Exists(GetPath() + @"\Categories\Categories.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GetPath() + @"\Categories\Categories.xml");
                XmlNodeList categories = doc.SelectNodes("//Category");
                
                var i = 0;
                if (categories.Count > 0)
                {
                    foreach (var cat in categories)
                    {
                        string category = categories[i].InnerText;
                        categoriesList.Add(new Category(category));
                        i++;
                    }
                }
            }
            return categoriesList;
        }
        
        public string GetPath()
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            return xmlDirectory;
        }
    }
}