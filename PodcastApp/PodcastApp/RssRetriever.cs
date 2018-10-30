using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace WindowsFormsApp1
{

    class RssRetriever: IPathfinder, IDirectoryCreator
    {
        readonly string LocalPath;
        XmlDocument doc = new XmlDocument();
        


        public RssRetriever(string url)
        {
            LocalPath = GetPath();
            Form1 form = new Form1();


            try { doc.Load(url); }
            catch (ArgumentException e) { MessageBox.Show(e.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (FileNotFoundException f) { MessageBox.Show(f.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (XmlException) { MessageBox.Show("URL did not lead to a valid source", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (System.Net.WebException) { MessageBox.Show("URL did not lead to a valid source", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            SaveOriginalFeedXml();
        }
   


        // Saves original xml file to specified directory with same name as file
        public void SaveOriginalFeedXml()
        {
            try
            {
                doc.PreserveWhitespace = true;

                string mainTitle = GetPodcastTitleFromRss();
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
        
        public string GetPath()
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            return xmlDirectory;
        }

        public void CreateDirectory(string path)
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, path);
            Directory.CreateDirectory(xmlDirectory);            
        }
    }
}

