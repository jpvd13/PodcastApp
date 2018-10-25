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
            List<string> descriptions = new List<string>();
            List<string> titles = new List<string>();

            XmlDocument xDoc = new XmlDocument();

            foreach (var file in files)
            {
                xDoc.Load(file);
                XmlNodeList items = xDoc.SelectNodes("//item");

                int i = 0;
                foreach (var item in items)
                {
                    descriptions.Add(items[i].SelectSingleNode("description").InnerText);
                    titles.Add(items[i].SelectSingleNode("title").InnerText);

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


                var pod = new Podcast(podcastTitle, frequency, category, titles, descriptions);
                podcasts.Add(pod);
            }
            return podcasts;
        }
    }
}