using System;
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
            

        }

        private void lwEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string getTextUrl()
        {
            InputTxtUrl = txtFeedUrl.Text;
            return InputTxtUrl;
        }

        public void SetListFeed(Podcast pod)
        {
            pod = new Podcast(pod.PodTitle, pod.Frequency, pod.Category, pod.EpisodeTitles, pod.EpisodeDescriptions);
            string[] row = { pod.PodTitle, pod.Category, pod.EpisodeTitles.Count.ToString(), pod.Frequency };
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
            DataRetriever retriever = new DataRetriever();    
            
            foreach (var epi in retriever.GetEpisodes())
            {
                string[] row = { epi };
                ListViewItem list = new ListViewItem(row);
                lwEpisodes.Items.Add(list);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {          
            DataRetriever retriever = new DataRetriever();
            XmlWriter xw = new XmlWriter();
            Podcast pod = new Podcast(retriever.GetPodcastTitle(), cbbFrequency.Text, cbbCategories.Text, retriever.GetEpisodes(), retriever.GetDescriptions());

            
            xw.CreateXml(pod);

            SetListFeed(pod);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dre = new DataRetriever();            

            List<Podcast> pod = dre.LoadPodcastXml();

            foreach (var p in pod)
            {
                SetListFeed(p);
            }
        }
    }
}
