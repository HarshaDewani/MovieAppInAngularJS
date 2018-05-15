using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAppInAngularJS.Models
{
    public class Movie
    {
        public string title { get; set; }
        public string director { get; set; }
        public string videoUrl { get; set; }
        public Array stars { get; set; }
        public string thumb { get; set; }
        public string description { get; set; }
        public string posterThumb { get; set; }
        public Array writers { get; set; }
        public DateTime release_date { get; set; }
       
    }
}