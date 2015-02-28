using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class VerticalCardsDataSource : DataSourceBase<VerticalCardsSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "ed5c38fa-594b-4560-8aa7-71ac1669908a";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public VerticalCardsDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "VerticalCardsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<VerticalCardsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<VerticalCardsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("VerticalCardsDataSource.LoadData", ex.ToString());
                return new VerticalCardsSchema[0];
            }
        }
    }
}
