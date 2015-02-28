using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class BigPicturesDataSource : DataSourceBase<BigPicturesSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "e973a745-25fa-4355-8532-f6222de46cb9";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public BigPicturesDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "BigPicturesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<BigPicturesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<BigPicturesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("BigPicturesDataSource.LoadData", ex.ToString());
                return new BigPicturesSchema[0];
            }
        }
    }
}
