# TrowWebScraper
A simple web scraping project created with ASP.NET Core.
## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This is a simple web scraping project. This ASP.NET Core application scrapes the data from a specific website URL and displays the data on separate web page. 
	
## Technologies
Project is created with: 
* Visual Studio 2022
* ASP.NET Core
* C#
* HTML
* Bootstrap 5
* JQuery
* CSS
* Javascript

	
## Setup
In the TrowWebScraper project, the target URL as well as the html nodes being used can be found in the WebScrapeController.cs file... 
```
public class WebScrapeController : Controller
    {
        private const string URL = "https://www.landmarkcinemas.com/now-playing/new-westminster#";
        private const string TOP_NODE = "//li[@class='movieitem']";
        private const string SUB_NODE_A = ".//img";
        private const string ATTR_VALUE = "data-original"; // Attribute Value
        private const string SUB_NODE_B = ".//span[@class='filmListItemTitle']";
```

...this information is used to scrape the data from the target URL.