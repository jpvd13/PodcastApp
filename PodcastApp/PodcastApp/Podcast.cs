using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Podcast
    {
        public string PodTitle { get; set; }
        public string Frequency { get; set; }
        public string Category { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Url { get; set; }
        public int NumberOfEpisodes { get; set; }   

        public Podcast(string url, string podTitle, string frequency, string category, List<Episode> episodes, int numberOfEpisodes)
        {
            Url = url;
            PodTitle = podTitle;
            Frequency = frequency;
            Category = category;
            Episodes = episodes;
            NumberOfEpisodes = numberOfEpisodes;
        }

        

    }
    
}
