using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotoDataSource : DataSourceBase<PhotoSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "bb2a95d1-25f1-43b8-ae6d-2d495716c6be";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public PhotoDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "PhotoDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<PhotoSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<PhotoSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("PhotoDataSource.LoadData", ex.ToString());
                return new PhotoSchema[0];
            }
        }
    }
}
