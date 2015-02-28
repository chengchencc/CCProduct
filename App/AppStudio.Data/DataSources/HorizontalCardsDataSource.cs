using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class HorizontalCardsDataSource : DataSourceBase<HorizontalCardsSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "2301142f-87c9-43d5-b0dc-5cb4a0a0f8b4";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public HorizontalCardsDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "HorizontalCardsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<HorizontalCardsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<HorizontalCardsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("HorizontalCardsDataSource.LoadData", ex.ToString());
                return new HorizontalCardsSchema[0];
            }
        }
    }
}
