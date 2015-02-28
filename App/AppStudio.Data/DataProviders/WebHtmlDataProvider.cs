using System;
using System.IO;
using System.IO.Compression;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppStudio.Data
{
    /// <summary>
    /// Rss data provider class
    /// </summary>
    public class WebHtmlDataProvider
    {
        private const string Imgpattern = @"<(?<Tag_Name>([^a])|img)\b[^>]*?\b(?<URL_Type>(?(1)href|src))\s*=\s*(?:""(?<URL>(?:\\""|[^""])*)""|'(?<URL>(?:\\'|[^'])*)')";
        private const string Urlpattern = @"(www.+|http.+)([\s]|$)";

        private Uri _uri;
        private string _userAgent;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url"></param>
        public WebHtmlDataProvider(string url, string userAgent = null)
        {
            _uri = new Uri(url);
            _userAgent = userAgent;
        }

        /// <summary>
        /// Starts loading the feed and initializing the reader for the feed type.
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<PhotoTileSchema>> Load()
        {
            string content = await DownloadAsync();

            var imageList = this.GetImagesInHTMLString(content).ToList();
            var schemas = new ObservableCollection<PhotoTileSchema>();
            foreach (var item in imageList)
            {
                PhotoTileSchema schemaItem = new PhotoTileSchema();
                schemaItem.Id = Guid.NewGuid().ToString();
                schemaItem.Image = item;
                schemaItem.Thumbnail = item;
                schemas.Add(schemaItem);
            }
            return schemas;
        }

        private async Task<string> DownloadAsync()
        {
            var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri);
            if (!string.IsNullOrEmpty(_userAgent))
            {
                request.Headers.UserAgent.ParseAdd(_userAgent);
            }
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            using (var stream = await responseMessage.Content.ReadAsStreamAsync())
            {
                using (var memStream = new MemoryStream())
                {
                    // Note: Some RSS feeds return gzipped data even when they are not requested to.
                    // This code check if data is gzipped and unzip data if needed.

                    await stream.CopyToAsync(memStream);
                    byte[] buffer = memStream.ToArray();
                    memStream.Position = 0;

                    if (buffer[0] == 31 && buffer[1] == 139 && buffer[2] == 8)
                    {
                        using (var gzipStream = new GZipStream(memStream, CompressionMode.Decompress))
                        {
                            return ReadStream(gzipStream);
                        }
                    }
                    else
                    {
                        return ReadStream(memStream);
                    }
                }
            }
        }

        private string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }



        public IEnumerable<string> GetImagesInHTMLString(string htmlString)
        {
            var images = new List<string>();
            const string pattern = Imgpattern;
            var rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                if (true)//matches[i].Value.Contains(".jpg") || matches[i].Value.Contains(".png"))
                {
                    var ms = Regex.Matches(matches[i].Value, Urlpattern);
                    if (ms.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ms[0].Value))
                            images.Add(ms[0].Value.Replace("\"", string.Empty));
                    }
                }
            }

            return images;
        }


    }
}
