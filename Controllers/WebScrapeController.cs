using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HtmlAgilityPack;
using TrowWebScraper.Models;

namespace TrowWebScraper.Controllers
{
    public class WebScrapeController : Controller
    {
        // GET: Now Playing Movies
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<NowPlayingMovies> movies = new List<NowPlayingMovies>();

            var web = new HtmlWeb();
            var doc = web.Load("https://www.landmarkcinemas.com/now-playing/new-westminster#");
            foreach(var item in doc.DocumentNode.SelectNodes("//li[@class='movieitem']"))
            {
                string title = item.SelectSingleNode(".//span[@class='filmListItemTitle']").InnerText.Trim();

                movies.Add(new NowPlayingMovies()
                {
                    title = title
                });
            }
            return View(movies);
        }
    }
}
