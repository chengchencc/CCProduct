using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class BigPhotoDataSource : DataSourceBase<BigPhotoSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "62cb60e6-e142-4d8a-ad11-3f252cead06e";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public BigPhotoDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "BigPhotoDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<BigPhotoSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<BigPhotoSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("BigPhotoDataSource.LoadData", ex.ToString());
                return new BigPhotoSchema[0];
            }
        }
    }
}
