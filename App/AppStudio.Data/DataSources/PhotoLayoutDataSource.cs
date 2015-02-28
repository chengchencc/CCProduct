using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotoLayoutDataSource : DataSourceBase<PhotoLayoutSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "ccd467e1-2fd6-4f13-a0fb-6ca261f872ec";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public PhotoLayoutDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "PhotoLayoutDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<PhotoLayoutSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<PhotoLayoutSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("PhotoLayoutDataSource.LoadData", ex.ToString());
                return new PhotoLayoutSchema[0];
            }
        }
    }
}
