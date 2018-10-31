using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TImer
    {
        public System.Timers.Timer theTimer;



        public async Task UpdateFeed(Podcast pod)
        {
            await FetchNewRss(pod);
         
           // List<Podcast> updatedPodcasts = new List<Podcast>(xr.LoadPodcastsXml());
            
            
          
        }

        public async Task FetchNewRss(Podcast pod)
        {
           
            RssRetriever rr = new RssRetriever(pod.Url);
            rr.SaveOriginalFeedXml();
            var episodes = rr.GetEpisodes();
         
            Podcast pod2 = new Podcast(pod.Url, pod.PodTitle, pod.Frequency, pod.Category, episodes, episodes.Count());
            XmlWriter xw = new XmlWriter();
            xw.CreatePodcastXml(pod2);

           /* string intFreq = pod.Frequency.Replace(" min", "");
            int.TryParse(intFreq, out int freq);
            int freqToSeconds = freq * 1000;
            await Task.Delay(freqToSeconds); */

        }

        public async Task StartShit(Podcast pod)
        {
            Task t1 = FetchNewRss(pod);
            Task t2 = UpdateFeed(pod);
        }

        public async Task SetFrequency(Podcast pod)
        {
            Task t1 = FetchNewRss(pod);

            string intFreq = pod.Frequency.Replace(" min", "");
            int.TryParse(intFreq, out int freq);
            int freqToSeconds = freq * 1000;
            await Task.Delay(freqToSeconds);

       


            //var theTimer = new System.Timers.Timer(freqToSeconds);
            //theTimer.Start();

        }
    }
        
}

   

    

