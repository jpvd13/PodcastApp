using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{

    class DataRetriever
    {
        readonly string MainFolder = @"C:\Users\JD\Desktop\podcastApp\PodcastApp\bin\PoddarXml";
        Form1 form = new Form1();
        XmlDocument doc = new XmlDocument();

        public DataRetriever()
        {
            doc.Load(@"C:\Users\JD\Desktop\PodcastApp\PodcastApp\bin\PoddarXml\StrictlyComeDancingStrictlyConfidential.xml");
            //XmlDocument docTfURL = new XmlDocument();
            //docTfURL.Load(tf.blavblbal)
            SaveXml();
        }

        public void CreateMainDirectory()
        {            
            System.IO.Directory.CreateDirectory(MainFolder);
        }

        public string GetMainDirectory()
        {
            return MainFolder;
        }

        // Removes special characters from a string
        // Flyttapårej
        public string RemoveSpecialChars(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        // Saves original xml file to specified directory with same name as file
        public void SaveXml()
        {
            doc.PreserveWhitespace = true;
            string mainTitle = GetPodcastTitle();
            string titleNoSpecialLetter = RemoveSpecialChars(mainTitle) + "Original";

            System.IO.Directory.CreateDirectory(MainFolder + @"\" + titleNoSpecialLetter);

            string pathToSave = MainFolder + @"\" + titleNoSpecialLetter + @"\" + titleNoSpecialLetter;
            doc.Save(pathToSave + ".xml");
        }


        // Returns current xml-document <channel><title>
        public string GetPodcastTitle()
        {
            XmlNodeList title = doc.SelectNodes("//channel");

            var x = 0;
            string podcastTitle = "";

            foreach (var titles in title)
            {
                podcastTitle = (title[x].SelectSingleNode("title").InnerText);
            }

            return podcastTitle;
        }

        // Returns number of episodes in specified podcast xml
        public int GetNumberOfEpisodes()
        {            
            XmlNodeList item = doc.SelectNodes("//item");            
            return item.Count;
        }

        // Returns a list of episodes in specified podcast xml
        public List <string> GetEpisodes()
        {
            List<string> episodes = new List<string>();
            XmlNodeList item = doc.SelectNodes("//item");


            var i = 0;
            foreach (var items in item)
            {
                episodes.Add(item[i].SelectSingleNode("title").InnerText);
                i++;

            }
            return episodes;
        }
        
        // Returns a list of descriptions in a specified podcast xml
        public List<string> GetDescriptions() //Kanske kan snyggas till lite
        {
            List<string> description = new List<string>();
            XmlNodeList item = doc.SelectNodes("//item");


            var i = 0;
            foreach (var items in item)
            {
                description.Add(item[i].SelectSingleNode("description").InnerText);
                i++;

            }
            return description;
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
                foreach(var item in items)
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

