using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotoLeftDescriptionDataSource : DataSourceBase<PhotoLeftDescriptionSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "43b48886-9a30-490b-a877-82d1b728cdfb";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public PhotoLeftDescriptionDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "PhotoLeftDescriptionDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<PhotoLeftDescriptionSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<PhotoLeftDescriptionSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("PhotoLeftDescriptionDataSource.LoadData", ex.ToString());
                return new PhotoLeftDescriptionSchema[0];
            }
        }
    }
}
