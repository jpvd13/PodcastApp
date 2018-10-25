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

    class RssRetriever
    {
        readonly string MainFolder;
        XmlDocument doc = new XmlDocument(); 
        
        public RssRetriever(string url)
        {  
            MainFolder = new DirectoryCreator().CreateMainDirectory();
            Form1 form = new Form1();
            doc.Load(url);
            SaveOriginalFeedXml();
        }
   


        // Saves original xml file to specified directory with same name as file
        public void SaveOriginalFeedXml()
        {
            doc.PreserveWhitespace = true;
            string mainTitle = GetPodcastTitleFromRss();
            StringManipulator sm = new StringManipulator();
            string titleNoSpecialLetter = sm.RemoveSpecialChars(mainTitle) + "Original";

            Directory.CreateDirectory(MainFolder + @"\" + titleNoSpecialLetter);

            string pathToSave = MainFolder + @"\" + titleNoSpecialLetter + @"\" + titleNoSpecialLetter;
            doc.Save(pathToSave + ".xml");
        }


        // Returns current xml-document <channel><title>
        public string GetPodcastTitleFromRss()
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

        // Returns a list of episodes in specified podcast xml
        public List <Episode> GetEpisodes()
        {
            List<Episode> episodes = new List<Episode>();
            XmlNodeList item = doc.SelectNodes("//item");


            var i = 0;
            foreach (var items in item)
            {
                string title = item[i].SelectSingleNode("title").InnerText;
                string description = item[i].SelectSingleNode("description").InnerText;
                episodes.Add(new Episode(title, description));
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

      
    }
}

