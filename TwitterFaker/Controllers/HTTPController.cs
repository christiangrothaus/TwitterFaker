using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using TwitterFaker.Models;
using System.Net.Http;
using HtmlAgilityPack;

namespace TwitterFaker.Controllers
{
    public class HTTPController : Controller
    {
        //TODO add all functionality
        public async void GetPage()
        {
            HttpClient client = new HttpClient();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync("https://twitter.com/elonmusk"));
        }
    }
}
