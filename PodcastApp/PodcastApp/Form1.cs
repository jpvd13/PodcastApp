﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string InputTxtUrl { get; set; }
        public List<string> ListFeeds { get; set; }

        public Form1()
        {
            InitializeComponent();
            //cbbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;


            var xr = new XmlReader();
            List<Podcast> pod = xr.LoadPodcastXml();
            foreach (var p in pod)
            {           
                SetListFeed(p);            
            }



        }

        private void lwEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string getTextUrl()
        {
            return txtFeedUrl.Text;
        }

        public void SetListFeed(Podcast pod)
        {
            
            string[] row = { pod.PodTitle, pod.Category, pod.NumberOfEpisodes.ToString(), pod.Frequency };
            ListViewItem list = new ListViewItem(row);
            lvFeeds.Items.Add(list);

        }
        

        public void SetEpisodeList(string name)
        {

            string[] row = { name };
            ListViewItem list = new ListViewItem(row);
            lwEpisodes.Items.Add(list);

        }

        private void lvFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            lwEpisodes.Items.Clear();

            if (lvFeeds.SelectedItems.Count > 0)
            {
                string title = lvFeeds.SelectedItems[0].SubItems[0].Text;
                XmlReader xr = new XmlReader();
                List<Episode> episodes = new List<Episode>(xr.GetEpisodesByPodcastTitleXml(title));
                
                foreach (var episode in episodes)
                {
                    string[] row = { episode.Title };
                    ListViewItem list = new ListViewItem(row);
                    lwEpisodes.Items.Add(list);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DirectoryCreator dc = new DirectoryCreator();
            dc.CreateMainDirectory();
           
            RssRetriever retriever = new RssRetriever(getTextUrl());
            var episodes = retriever.GetEpisodes();
            Podcast pod = new Podcast(retriever.GetPodcastTitleFromRss(), cbbFrequency.Text, cbbCategories.Text, episodes, episodes.Count());
            SetListFeed(pod);

            XmlWriter xw = new XmlWriter();
            xw.CreateXml(pod);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
