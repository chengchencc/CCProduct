using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GenericLayoutDataSource : DataSourceBase<GenericLayoutSchema>
    {
        private const string _appId = "d402a850-cb48-4d08-a938-d2c838a299c6";
        private const string _dataSourceName = "6db1e7d0-5216-4519-8978-d51f1452f9f2";
        private Guid _storeId;
        private string _deviceType;
        private bool _isBackgroundAgent;

        public GenericLayoutDataSource(Guid storeId, string deviceType, bool isBackgroundAgent = false)
        {
            _storeId = storeId;
            _deviceType = deviceType;
            _isBackgroundAgent = isBackgroundAgent;
        }

        protected override string CacheKey
        {
            get { return "GenericLayoutDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<GenericLayoutSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName, _storeId, _deviceType, _isBackgroundAgent);
                return await serviceDataProvider.Load<GenericLayoutSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("GenericLayoutDataSource.LoadData", ex.ToString());
                return new GenericLayoutSchema[0];
            }
        }
    }
}
