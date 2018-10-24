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
        public List<string> EpisodeTitles { get; set; }
        public List<string> EpisodeDescriptions { get; set; }
        public int EpisodeCount { get; set; }
           

        public Podcast(string podTitle, string frequency, string category, List<string> episodeTitles, List<string> episodeDescriptions)
        {
            PodTitle = podTitle;
            Frequency = frequency;
            Category = category;
            EpisodeTitles = episodeTitles;
            EpisodeDescriptions = episodeDescriptions;

        }

        public Podcast(string podTitle, string frequency, string category)
        {
            PodTitle = podTitle;
            Frequency = frequency;
            Category = category;
           

        }


    }
    
}
