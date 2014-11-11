using System.Net;

namespace DAL
{
    public class JsonDownloader
    {
        public string GetJson(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
