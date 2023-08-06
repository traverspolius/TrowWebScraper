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
        private const string URL = "https://www.landmarkcinemas.com/now-playing/new-westminster#";
        private const string TOP_NODE = "//li[@class='movieitem']";
        private const string SUB_NODE_A = ".//img";
        private const string ATTR_VALUE = "data-original"; // Attribute Value
        private const string SUB_NODE_B = ".//span[@class='filmListItemTitle']";

        // GET: Now Playing Movies1
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<NowPlayingMovies> movies = new List<NowPlayingMovies>();
            string imagex = "";
            string titlex = "";
            var web = new HtmlWeb();
            var doc = web.Load(URL);
            foreach(var item in doc.DocumentNode.SelectNodes(TOP_NODE))
            {
                imagex = item.SelectSingleNode(SUB_NODE_A).GetAttributeValue(ATTR_VALUE, null);
                titlex = item.SelectSingleNode(SUB_NODE_B).InnerText.Trim();

                if (imagex is not null)
                {
                    movies.Add(new NowPlayingMovies()
                                {
                                    image = imagex,
                                    title = titlex,
                                });
                }
                
            };
            return View(movies);
        }
    }
}
