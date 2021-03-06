﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public class PodcastHandler : IDirectoryCreator, IPathfinder
    {
        readonly string LocalPath;
        XmlDocument doc = new XmlDocument();

        public PodcastHandler(string url)
        {
            LocalPath = GetPath();

            try { doc.Load(url); }
            catch (ArgumentException e) { MessageBox.Show(e.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (FileNotFoundException f) { MessageBox.Show(f.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (XmlException) { MessageBox.Show("URL did not lead to a valid source", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (System.Net.WebException) { MessageBox.Show("URL did not lead to a valid source", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public PodcastHandler()
        {
            LocalPath = GetPath();

        }

        public List<Podcast> GetPodcasts()
        {
            XmlReader xr = new XmlReader();

            return xr.LoadPodcastsXml();
        }

        public List<Episode> GetEpisodesByTitle(string title)
        {
            XmlReader xr = new XmlReader();
            return xr.GetEpisodesByPodcastTitleXml(title);

        }

        public void CreatePodcast(Podcast pod)
        {
            XmlWriter xw = new XmlWriter();
            xw.CreatePodcastXml(pod);
        }

        public string GetPodcastTitleFromRss(XmlDocument xDoc)
        {
            XmlNodeList title = xDoc.SelectNodes("//channel");

            var x = 0;
            string podcastTitle = "";

            foreach (var titles in title)
            {
                podcastTitle = (title[x].SelectSingleNode("title").InnerText);
            }

            return podcastTitle;
        }

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

        public List<Episode> GetEpisodesFromRss()
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

        public void SaveOriginalRssFeed()
        {
            XmlWriter xw = new XmlWriter();
            xw.SaveOriginalFeedXml(doc);
        }

        public void DeletePodcast(string selectedPodcast)
        {
            var sm = new StringManipulator();

            var fileName = GetPath() + sm.RemoveSpecialChars(selectedPodcast + ".xml");
            string originalDirectory = fileName.Replace(".xml", "Original"); //Path to the directory in which the original XML file was saved

            if ((File.Exists(fileName)))
            {
                File.Delete(fileName);
                Directory.Delete(originalDirectory, true); //Deletes original XML directory and its content

            }
        }

        public void UpdatePodcast(string url, string category, string frequency, string title)
        {
            var xw = new XmlWriter();
            Podcast newPod = new Podcast(url, title, frequency, category, GetEpisodesByTitle(title), GetEpisodesByTitle(title).Count);

            xw.CreatePodcastXml(newPod);
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
