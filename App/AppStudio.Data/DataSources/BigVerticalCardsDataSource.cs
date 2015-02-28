using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class BigVerticalCardsDataSource : DataSourceBase<BigVerticalCardsSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "ced43f53-2333-45d5-a819-dd0a95a45e32";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public BigVerticalCardsDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "BigVerticalCardsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<BigVerticalCardsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<BigVerticalCardsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("BigVerticalCardsDataSource.LoadData", ex.ToString());
                return new BigVerticalCardsSchema[0];
            }
        }
    }
}
