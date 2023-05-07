using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrowWebScraper.Models
{
    public class NowPlayingMovies
    {
        public string title { get; set; }
        public string image { get; set; }

        public NowPlayingMovies()
        {
            title = "";
            image = "";
        }
    }
}
