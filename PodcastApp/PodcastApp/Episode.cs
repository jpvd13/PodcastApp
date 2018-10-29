using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Episode
    {
        public string Title { get; set; }
        public string Description;
        public int Id { get; set; }
        public Episode(string title, string description, int id)
        {
            Title = title;
            Description = description;
            Id = id;
        }

        public Episode(string title, string description)
        {
            Title = title;
            Description = description;
            
        }

    }
    
 
}
