using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Timers;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, IDirectoryCreator
    {
        public string InputTxtUrl { get; set; }
        public List<string> ListFeeds { get; set; }
        public string CurrentPodcast { get; set; }
        public System.Windows.Forms.Timer theTimer;


        XmlWriter xw;
        XmlReader xr;

        public Form1()
        {
            InitializeComponent();

            cbbCategories.DropDownStyle = ComboBoxStyle.DropDownList;           
            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;

            xw = new XmlWriter();
            xr = new XmlReader();
            xw.CreateCategoriesXml();           

            SetUpdateInterval();
            PopulateCategoriesList();
            PopulateFeedList();
            FillCategoryCbb();

        }

        public void PopulateCategoriesList()
        {

            List<Category> cat = xr.GetCategories();
            foreach (var c in cat)
            {
                SetCategoriesList(c);
            }
        }
        public async Task FetchNewRss(Podcast pod)
        {          
            RssRetriever rr = new RssRetriever(pod.Url);
            rr.SaveOriginalFeedXml();
            var episodes = rr.GetEpisodes();

            Podcast pod2 = new Podcast(pod.Url, pod.PodTitle, pod.Frequency, pod.Category, episodes, episodes.Count());
            XmlWriter xw = new XmlWriter();
            xw.CreatePodcastXml(pod2);
        }

        private void Interval_Tick(object sender, EventArgs e, Podcast p)
        {          
                var t1 = FetchNewRss(p);
               
                var item = lvFeeds.FindItemWithText(p.PodTitle);
                if(item != null)
                {
                    lvFeeds.Items[item.Index].Remove();
                }
                SetListFeed(p);         
        }

            private async Task SetUpdateInterval()
            {
            
            List<Podcast> podz = xr.LoadPodcastsXml();
            foreach (var p in podz)
            {
                await Task.Delay(1000);
                string intFreq = p.Frequency.Replace(" min", "");
                int.TryParse(intFreq, out int freq);
                int freqToSeconds = freq * 1000;

                theTimer = new System.Windows.Forms.Timer
                {
                    Interval = (freqToSeconds)
                };
                theTimer.Start();                
                theTimer.Tick += (sender2, e2) => Interval_Tick(sender2, e2, p);

            }

        }

        private void PopulateFeedList()
        {
            xr = new XmlReader();
            List<Podcast> pod = xr.LoadPodcastsXml();
            foreach (var p in pod)
            {
                SetListFeed(p);
            }
        }
      

        private void lwEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwEpisodes.SelectedItems.Count > 0)
            {
                string currentEpisode = lwEpisodes.SelectedItems[0].Text;


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

        public void SetCategoriesList(Category cat)
        {
            string[] row = { cat.Name };
            ListViewItem list = new ListViewItem(row);
            lwCategories.Items.Add(list);
        }

        private void lvFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            lwEpisodes.Items.Clear();
            lblTitleDesc.Text = "";
            tbEpisodeDesc.Clear();

            if (lvFeeds.SelectedItems.Count > 0)
            {
                CurrentPodcast = lvFeeds.SelectedItems[0].SubItems[0].Text;
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
            var validate = new Validate();
            bool validLength = false;
            bool validUrl = false;

            if (validate.ValidateLength(getTextUrl(), 5, 2083))
            {
                validLength = true;
            }
            if (validate.ValidateUrl(getTextUrl()))
            {
                validUrl = true;
            }

            if (validLength && validUrl)
            {
                CreateDirectory(@"PoddarXml\");

                RssRetriever retriever = new RssRetriever(getTextUrl());
                var episodes = retriever.GetEpisodes();
                try
                {
                    if (retriever.GetPodcastTitleFromRss() != "")
                    {
                        Podcast pod = new Podcast(getTextUrl(), retriever.GetPodcastTitleFromRss(), cbbFrequency.Text, cbbCategories.Text, episodes, episodes.Count());

                        SetListFeed(pod);

                        xw.CreatePodcastXml(pod);
                    }
                }
                catch (ArgumentException) { }

            }
            else
            {
                if (!validLength)
                {
                    MessageBox.Show("The Url must be between 5-2083 characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                if (validLength && !validUrl)
                {
                    MessageBox.Show("Input is not a valid Url", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SetUpdateInterval();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var validate = new Validate();
            if (validate.ValidateLength(txtCategory.Text, 2, 25))
            {
                xw.WriteNewCategory(txtCategory.Text);
                Category cat = new Category(txtCategory.Text);
                SetCategoriesList(cat);
                FillCategoryCbb();
            }
            else
            {
                MessageBox.Show("Categories must be between 2-25 characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCategoryCbb()
        {
            XmlReader xr = new XmlReader();
            List<Category> cat = xr.GetCategories();
            cbbCategories.Items.Clear();
            foreach (var c in cat)
            {
                cbbCategories.Items.Add(c.Name);
            }
            cbbCategories.SelectedIndex = 0;
        }

      

        public void CreateDirectory(string path)
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, path);
            Directory.CreateDirectory(xmlDirectory);
        }

        private void lwCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvFeeds.Items.Clear();
            List<Podcast> podlist = xr.LoadPodcastsXml();
            if (lwCategories.SelectedItems.Count == 1)
            {
                string selectedCategory = lwCategories.SelectedItems[0].Text;





                foreach (var pod in podlist)
                {
                    if (pod.Category == selectedCategory)
                    {

                        string[] row = { pod.PodTitle, pod.Category, pod.NumberOfEpisodes.ToString(), pod.Frequency };
                        ListViewItem lvi = new ListViewItem(row);
                        lvFeeds.Items.Add(lvi);
                    }
                }
            }
            else
            {
                foreach (var pod in podlist)
                {
                    SetListFeed(pod);
                }
            }
        }
    }
}
