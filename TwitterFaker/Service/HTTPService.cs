using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace TwitterFaker.Service
{
    public class HTTPService
    {
        public async Task<string> GetName(string account)
        {
            HttpClient client = new HttpClient();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync($"https://twitter.com/{account}"));
            string name = doc.DocumentNode.SelectSingleNode("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div/span[1]/span").InnerText;
            return name;
        }
    }
}