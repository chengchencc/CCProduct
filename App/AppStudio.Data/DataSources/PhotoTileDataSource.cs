using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotoTileDataSource : DataSourceBase<PhotoTileSchema>
    {
        private const string _file = "/Assets/Data/PhotoTileDataSource.json";

        protected override string CacheKey
        {
            get { return "PhotoTileDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<PhotoTileSchema>> LoadDataAsync()
        {
            try
            {
                //var serviceDataProvider = new StaticDataProvider(_file);
                //return await serviceDataProvider.Load<PhotoTileSchema>();
            
                var serviceDataProvider = new WebHtmlDataProvider("http://cn.bing.com/images?FORM=Z9LH");
                //var serviceDataProvider = new WebHtmlDataProvider("http://cn.bing.com/images/search?q=%E5%AE%8B%E6%99%BA%E5%AD%9D%E7%99%BB%E6%9D%82%E5%BF%97+&FORM=ISTRTH&id=BD44D381DF2DDD14AAEE4F5E0B47CB101B6E9D0A&cat=%E4%BB%8A%E6%97%A5%E7%83%AD%E5%9B%BE&lpversion=e932c543-6715-4391-8e7b-c47a27ae297e#a");
                return await serviceDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("PhotoTileDataSource.LoadData", ex.ToString());
                return new PhotoTileSchema[0];
            }
        }
    }
}
