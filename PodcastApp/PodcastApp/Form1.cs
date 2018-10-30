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
        public System.Timers.Timer theTimer;
        private HttpClient Client = new HttpClient();

        XmlWriter xw;
        XmlReader xr;

        public Form1()
        {
            InitializeComponent();

            cbbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            FillCategoryCbb();

            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;

            xw = new XmlWriter();
            xw.CreateCategoriesXml();

            xr = new XmlReader();
            List<Podcast> pod = xr.LoadPodcastsXml();
            foreach (var p in pod)
            {
                SetListFeed(p);
            }

            List<Category> cat = xr.GetCategories();
            foreach (var c in cat)
            {
                SetCategoriesList(c);
            }

           Task.Run(() => GetFrequenciesAndUrls());

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
        }

        private async Task SetTimer(int freq, string url, string frequency, string category, string title)
        {
           
            theTimer = new System.Timers.Timer(freq);
            theTimer.Start();
            theTimer.Elapsed += async (sender2, e2) =>  await UpdatePodList(sender2, e2, url, frequency, category, title);
        }

        private async Task UpdatePodList(object sender, EventArgs e, string url, string frequency, string category, string title)
        {

            MethodInvoker me = delegate
            {
                if (lvFeeds.Items.Count != 0)
                {
                    var item = lvFeeds.FindItemWithText(title);
                    if (item != null)
                    {
                        lvFeeds.Items[item.Index].Remove();

                        RssRetriever retriever = new RssRetriever(url);
                        var episodes = retriever.GetEpisodes();

                        Podcast pod = new Podcast(url, title, frequency, category, episodes, episodes.Count());
                        SetListFeed(pod);
                        xw.CreatePodcastXml(pod);
                    }
                }
            };

            if (InvokeRequired)
            {
                Invoke(me);
            }

        }

        private async Task GetFrequenciesAndUrls()
        {
            
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
               await SetTimer(freqToSeconds, url, frequency, category, title);
            }
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
