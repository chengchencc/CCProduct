using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NoPhotoDataSource : DataSourceBase<NoPhotoSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "581986cf-c69c-49be-8f12-f85029a5afa4";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public NoPhotoDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "NoPhotoDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<NoPhotoSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<NoPhotoSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("NoPhotoDataSource.LoadData", ex.ToString());
                return new NoPhotoSchema[0];
            }
        }
    }
}
