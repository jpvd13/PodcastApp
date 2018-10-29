using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    class XmlReader
    {
        string MainFolder;

        StringManipulator sm = new StringManipulator();

        public XmlReader()
        {
            MainFolder = new DirectoryCreator().CreateMainDirectory();
        }

        public List<Podcast> LoadPodcastsXml()
        {
            string[] files = Directory.GetFiles(MainFolder, "*", SearchOption.TopDirectoryOnly);
            List<Podcast> podcasts = new List<Podcast>();
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

        public XmlDocument LoadLocalXml(string title)
        { 
            string titleNoSpecialChars = sm.RemoveSpecialChars(title);
            string[] files = Directory.GetFiles(MainFolder, "*", SearchOption.TopDirectoryOnly);
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
            XmlDocument xDoc = LoadLocalXml(title);
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

    }
}