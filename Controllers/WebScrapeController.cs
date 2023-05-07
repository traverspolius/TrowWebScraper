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
            string imagex = "";
            string titlex = "";
            var web = new HtmlWeb();
            var doc = web.Load("https://www.landmarkcinemas.com/now-playing/new-westminster#");
            foreach(var item in doc.DocumentNode.SelectNodes("//li[@class='movieitem']"))
            {
                imagex = item.SelectSingleNode(".//img").GetAttributeValue("data-original", null);
                titlex = item.SelectSingleNode(".//span[@class='filmListItemTitle']").InnerText.Trim();

                movies.Add(new NowPlayingMovies()
                {
                    image = imagex,
                    title = titlex,
                });
            };
            return View(movies);
        }
    }
}
