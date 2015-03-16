using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CC.Product.TallyBook.Common
{
    public class UploadStorage
    {
        public static async Task<Stream> ConvertStaticFileToStream(string filePath)
        {
            string url = String.Format("ms-appx://{0}", filePath);
            Uri uri = new Uri(url);
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();
                return randomStream.AsStream();
            }
            catch (Exception ex)
            {
                //AppLogs.WriteError("UploadStorage.ConvertStaticFileToStream", ex);
                //return null;
                throw ex;
            }
        }


    }

}
