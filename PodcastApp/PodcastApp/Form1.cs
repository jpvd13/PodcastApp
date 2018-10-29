using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string InputTxtUrl { get; set; }
        public List<string> ListFeeds { get; set; }
        public string CurrentPodcast { get; set; }
        public System.Timers.Timer theTimer;

        public Form1()
        {
            InitializeComponent();
            //cbbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;

            var xw = new XmlWriter();
            xw.CreateCategoriesXml();

            var xr = new XmlReader();
            List<Podcast> pod = xr.LoadPodcastsXml();
            foreach (var p in pod)
            {           
                SetListFeed(p);            
            }

            GetFrequenciesAndUrls();           

        }

        private void lwEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwEpisodes.SelectedItems.Count > 0)
            {
                string currentEpisode = lwEpisodes.SelectedItems[0].Text;

                XmlReader xr = new XmlReader();
                List<Episode> episodes = new List<Episode>(xr.GetEpisodesByPodcastTitleXml(CurrentPodcast));

                var query = from ep in episodes
                            where ep.Title == currentEpisode
                            where ep.Id.ToString() == lwEpisodes.SelectedItems[0].SubItems[1].Text
                            select ep;

                List<Episode> selectedEpisode = query.ToList();

                string descNoXmlTags = xr.GetXmlElementWithoutTags(selectedEpisode[0].Description);

                    tbEpisodeDesc.Clear();
               
               
                    lblTitleDesc.Text = lwEpisodes.SelectedItems[0].Text;
                    tbEpisodeDesc.Text = descNoXmlTags;
            }
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
            lblTitleDesc.Text = "";
            tbEpisodeDesc.Clear();

            if (lvFeeds.SelectedItems.Count > 0)
            {
                CurrentPodcast = lvFeeds.SelectedItems[0].SubItems[0].Text;
                
                XmlReader xr = new XmlReader();
                List<Episode> episodes = new List<Episode>(xr.GetEpisodesByPodcastTitleXml(CurrentPodcast));
                
                foreach (var episode in episodes)
                {
                    string[] row = { episode.Title, episode.Id.ToString() };
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
            Podcast pod = new Podcast(getTextUrl(),retriever.GetPodcastTitleFromRss(), cbbFrequency.Text, cbbCategories.Text, episodes, episodes.Count());
            SetListFeed(pod);

            XmlWriter xw = new XmlWriter();
            xw.CreatePodcastXml(pod);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var xw = new XmlWriter();
            xw.WriteNewCategory(txtCategory.Text);
        }

        private void SetTimer(int freq, string url, string frequency, string category, string title)
        {
            theTimer = new System.Timers.Timer(freq);
            theTimer.Start();
            theTimer.Elapsed += (sender2, e2) => UpdatePodList(sender2, e2, url, frequency, category, title);

        }

        private void UpdatePodList(object sender, EventArgs e, string url, string frequency, string category, string title)
        {
            MethodInvoker me = delegate
            {
                var item = lvFeeds.FindItemWithText(title);
                lvFeeds.Items[item.Index].Remove();

                DirectoryCreator dc = new DirectoryCreator();
                dc.CreateMainDirectory();

                RssRetriever retriever = new RssRetriever(url);
                var episodes = retriever.GetEpisodes();

                Podcast pod = new Podcast(url, title, frequency, category, episodes, episodes.Count());

                SetListFeed(pod);

                XmlWriter xw = new XmlWriter();
                xw.CreatePodcastXml(pod);


            };

            if (InvokeRequired)
            {
                Invoke(me);
            }

        }

        private void GetFrequenciesAndUrls()
        {

            var xr = new XmlReader();
            List<Podcast> podcasts = new List<Podcast>(xr.LoadPodcastsXml());
            int freq;
            foreach (var pod in podcasts)

            {
                string url = pod.Url;
                string frequency = pod.Frequency;
                string category = pod.Category;
                string title = pod.PodTitle;

                string intFreq = frequency.Replace(" min", "");
                int.TryParse(intFreq, out freq);
                int freqToSeconds = freq * 1000;
                SetTimer(freqToSeconds, url, frequency, category, title);



            }


        }
    }
}
