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
        public XmlReader()
        {
            MainFolder = new DirectoryCreator().CreateMainDirectory();
        }

        public List<Podcast> LoadPodcastXml()
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
                    episodes.Add(new Episode(episodeTitle, episodeDescription));

                    i++;
                }

                XmlNodeList title = xDoc.SelectNodes("//channel");

                var x = 0;
                string podcastTitle = "";
                string frequency = "";
                string category = "";

                foreach (var smth in title)
                {
                    podcastTitle = title[x].SelectSingleNode("title").InnerText;
                    category = title[x].SelectSingleNode("category").InnerText;
                    frequency = title[x].SelectSingleNode("frequency").InnerText;

                   x++;
                }


                var pod = new Podcast(podcastTitle, frequency, category, episodes, episodes.Count());
                podcasts.Add(pod);
                episodes.Clear();
            }
            return podcasts;
        }

        public List<Episode> GetEpisodesByPodcastTitleXml(string title)
        {
            StringManipulator sm = new StringManipulator();
            string titleNoSpecialChars = sm.RemoveSpecialChars(title);
            string[] files = Directory.GetFiles(MainFolder, "*", SearchOption.TopDirectoryOnly);
            List<Episode> episodes = new List<Episode>();
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

            
            

            XmlNodeList items = xDoc.SelectNodes("//item");

            int x = 0;
            foreach (var item in items)
            {
              string episodeTitle = items[x].SelectSingleNode("title").InnerText;
              string episodeDescription = items[x].SelectSingleNode("description").InnerText;
               episodes.Add(new Episode(episodeTitle, episodeDescription));
                x++;
            }

            return episodes;
        }
    }
}