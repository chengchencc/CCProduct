using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AppStudio.Data
{
    public class TouchDevelopDataProvider
    {
        private Uri _localUri;
        private Uri _remoteUri;

        public TouchDevelopDataProvider(string htmlPath, string projectCode)
        {
            _localUri = new Uri(string.Format("ms-appx://{0}", htmlPath));
            _remoteUri = new Uri(string.Format("https://www.touchdevelop.com/api/{0}", projectCode));
        }

        public async Task<IEnumerable<TouchDevelopSchema>> Load()
        {
            try
            {
                TouchDevelopSchema record = await GetRemoteProject();

                if (record == null)
                {
                    record = await GetLocalProject();
                }

                var records = new List<TouchDevelopSchema>() { record };
                return records;
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("TouchDevelopDataProvider.Load", ex);
                return null;
            }
        }

        private async Task<TouchDevelopSchema> GetRemoteProject()
        {
            string data = await DownloadAsync(_remoteUri);
            TouchDevelopItem item = JsonConvert.DeserializeObject<TouchDevelopItem>(data);
            return new TouchDevelopSchema(item);
        }

        public async Task<string> DownloadAsync(Uri url)
        {
            HttpClient client = new HttpClient();
            var message = new HttpRequestMessage(HttpMethod.Get, url);
            using (var response = await client.SendAsync(message))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<TouchDevelopSchema> GetLocalProject()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(_localUri);
            IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();

            using (StreamReader r = new StreamReader(randomStream.AsStreamForRead()))
            {
                string data = await r.ReadToEndAsync();
                return JsonConvert.DeserializeObject<DataSourceContent<TouchDevelopSchema>>(data).Items.FirstOrDefault();
            }
        }
    }
}
