using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class CollectionDataSource : DataSourceBase<CollectionSchema>
    {
        private const string _file = "/Assets/Data/CollectionDataSource.json";

        protected override string CacheKey
        {
            get { return "CollectionDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<CollectionSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<CollectionSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("CollectionDataSource.LoadData", ex.ToString());
                return new CollectionSchema[0];
            }
        }
    }
}
