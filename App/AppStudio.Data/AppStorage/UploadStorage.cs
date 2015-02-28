using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using PCLStorage;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AppStudio
{
    public class UploadStorage
    {

        public static async Task<Stream> ConvertStaticFileToStream( string filePath)
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
                AppLogs.WriteError("UploadStorage.ConvertStaticFileToStream", ex);
                return null;
            }
        }

        public static async Task<Stream> ConvertTempFileToStream(string fileName)
        {
            try
            {
                var folder = FileSystem.Current.LocalStorage;
                var file = await folder.GetFileAsync(fileName);
                if (file != null)
                {
                    //Windows.Storage.
                    var fileStream = await file.OpenAsync(FileAccess.Read);
                    //Stream s = new System.IO.MemoryStream(); ;
                    //fileStream.CopyTo(s);
                    //return s;
                    return fileStream;
                    //return await file.ReadAllTextAsync();
                }
                
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UploadStorage.ConvertFileToStream", ex);
            }
            return null;
            //return String.Empty;
        }

    }
}
