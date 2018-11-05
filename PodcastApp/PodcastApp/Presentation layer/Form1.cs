using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    delegate void Del(Podcast pod);
    public partial class Form1 : Form, IDirectoryCreator, IPathfinder
    {
        public string CurrentPodcast;
        Timer theTimer;

        public Validate validator = new Validate();
        public CategoryHandler categoryHandler = new CategoryHandler();
        public PodcastHandler pReader = new PodcastHandler();


        public Form1()
        {
            InitializeComponent();

            cbbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            lvFeeds.Sorting = SortOrder.Ascending;

            categoryHandler.CreateCategoryStorage();


            SetUpdateInterval();
            PopulateCategoriesList();
            PopulateFeedList();
            FillCategoryCbb();

        }

        public void PopulateCategoriesList()
        {

            List<Category> cat = categoryHandler.GetCategories();
            foreach (var c in cat)
            {
                SetCategoriesList(c);
            }
        }
        public async Task FetchNewRss(Podcast pod)
        {
            await Task.Delay(1000);
            PodcastHandler writer = new PodcastHandler(pod.Url);
            writer.SaveOriginalRssFeed();
            var episodes = pReader.GetEpisodesByTitle(pod.PodTitle);
            Podcast newPod = new Podcast(pod.Url, pod.PodTitle, pod.Frequency, pod.Category, episodes, episodes.Count());
            writer.CreatePodcast(newPod);
        }

        private async Task Interval_Tick(object sender, EventArgs e, Podcast p)
        {
            await FetchNewRss(p);

            var item = lvFeeds.FindItemWithText(p.PodTitle);
            if (item != null)
            {
                lvFeeds.Items[item.Index].Remove();
            }
            if (item != null)
            {
                SetListFeed(p);
            }

        }

        private async Task SetUpdateInterval()
        {
            await Task.Delay(1000);
            List<Podcast> podz = pReader.GetPodcasts();
            foreach (var p in podz)
            {
                string intFreq = p.Frequency.Replace(" min", "");
                int.TryParse(intFreq, out int freq);
                int freqToSeconds = freq * 36000;

                theTimer = new Timer
                {
                    Interval = (freqToSeconds)
                };
                theTimer.Start();
                theTimer.Tick += (sender2, e2) => Interval_Tick(sender2, e2, p);

            }

        }

        private void PopulateFeedList()
        {
            List<Podcast> pod = pReader.GetPodcasts();
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


                List<Episode> episodes = new List<Episode>(pReader.GetEpisodesByTitle(CurrentPodcast));

                var query = from ep in episodes
                            where ep.Title == currentEpisode
                            where ep.Id.ToString() == lwEpisodes.SelectedItems[0].SubItems[1].Text
                            select ep;

                List<Episode> selectedEpisode = query.ToList();

                string descNoXmlTags = StringManipulator.RemoveXmlTags(selectedEpisode[0].Description);

                tbEpisodeDesc.Clear();


                lblTitleDesc.Text = lwEpisodes.SelectedItems[0].Text;
                tbEpisodeDesc.Text = descNoXmlTags;
            }
        }

        public string GetTextUrl()
        {
            return txtFeedUrl.Text;
        }

        public string GetSelectedItemListFeeds()
        {
            string selected = "FAsfaf";
            if (lvFeeds.SelectedItems.Count > 0)
            {
                selected = lvFeeds.SelectedItems[0].Text;
            }
            return selected;
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
            var ph = new PodcastHandler();
            List<Podcast> podcasts = ph.GetPodcasts();

            lwEpisodes.Items.Clear();
            lblTitleDesc.Text = "";
            tbEpisodeDesc.Clear();

            if (lvFeeds.SelectedItems.Count > 0)
            {
                CurrentPodcast = lvFeeds.SelectedItems[0].SubItems[0].Text;
                List<Episode> episodes = new List<Episode>(pReader.GetEpisodesByTitle(CurrentPodcast));

                foreach (var episode in episodes)
                {
                    string[] row = { episode.Title, episode.Id.ToString() };
                    ListViewItem list = new ListViewItem(row);
                    lwEpisodes.Items.Add(list);
                }

                foreach (var pod in podcasts)
                {
                    if (pod.PodTitle == CurrentPodcast)
                    {
                        txtFeedUrl.Text = pod.Url;
                        cbbCategories.Text = pod.Category;
                        cbbFrequency.Text = pod.Frequency;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            bool validLength = false;
            bool validUrl = false;

            if (validator.ValidateLength(GetTextUrl(), 5, 2083))
            {
                validLength = true;
            }
            if (validator.ValidateUrl(GetTextUrl()))
            {
                validUrl = true;
            }

            if (validLength && validUrl)
            {
                CreateDirectory(@"PoddarXml\");

                PodcastHandler writer = new PodcastHandler(GetTextUrl());
                var podTitle = writer.GetPodcastTitleFromRss();
                var episodes = writer.GetEpisodesFromRss();

                try
                {
                    if (podTitle != "")
                    {
                        Podcast pod = new Podcast(GetTextUrl(), podTitle, cbbFrequency.Text, cbbCategories.Text, episodes, episodes.Count());

                        SetListFeed(pod);

                        writer.CreatePodcast(pod);
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



        private void button3_Click(object sender, EventArgs e)
        {
            if (validator.ValidateLength(txtCategory.Text, 2, 25))
            {

                categoryHandler.CreateCategory(txtCategory.Text);
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
            List<Category> cat = categoryHandler.GetCategories();
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
            List<Podcast> podlist = pReader.GetPodcasts();
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

        public string GetPath()
        {
            string xmlDirectory = Path.Combine(Environment.CurrentDirectory, @"PoddarXml\");
            return xmlDirectory;
        }

        private void BtnUpdateCategory(object sender, EventArgs e)
        {

            try
            {

                if (lwCategories.SelectedItems.Count > 0)
                {
                    string selectedCategory = lwCategories.SelectedItems[0].Text;
                    string input = txtCategory.Text;
                    categoryHandler.UpdateCategory(input, selectedCategory);

                    lwCategories.Items.Clear();
                    PopulateCategoriesList();
                    FillCategoryCbb();
                }
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show("No category is selected", "No selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                List<Category> categories = categoryHandler.GetCategories();

                foreach (var cat in categories)
                {
                    if (lwCategories.Items.Count > 1)
                    {
                        if (lwCategories.SelectedItems[0].Text.Equals(cat.Name))
                        {
                            categoryHandler.DeleteCategory(cat.Name);

                            var item = lwCategories.FindItemWithText(cat.Name);
                            if (item != null)
                            {
                                lwCategories.Items[item.Index].Remove();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There must always be at least on category available", "Can't remove that", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No category is selected", "No selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void btnDeletePod_Click_1(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = lvFeeds.SelectedItems[0].Text;
                pReader.DeletePodcast(selectedItem);

                var item = lvFeeds.FindItemWithText(selectedItem);
                if (item != null)
                {
                    lvFeeds.Items[item.Index].Remove(); //Clears categories list

                }
            }

            catch (ArgumentOutOfRangeException) { MessageBox.Show("No podcast selected", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                var ph = new PodcastHandler();
                ph.UpdatePodcast(txtFeedUrl.Text, cbbCategories.Text, cbbFrequency.Text, lvFeeds.SelectedItems[0].Text);

                lvFeeds.Items.Clear();
                PopulateFeedList();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show("No podcast is selected", "No selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
