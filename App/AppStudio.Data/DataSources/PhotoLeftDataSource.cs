using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotoLeftDataSource : DataSourceBase<PhotoLeftSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "0031601e-7f72-4d30-8867-1ba7678a914e";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public PhotoLeftDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "PhotoLeftDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<PhotoLeftSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<PhotoLeftSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("PhotoLeftDataSource.LoadData", ex.ToString());
                return new PhotoLeftSchema[0];
            }
        }
    }
}
