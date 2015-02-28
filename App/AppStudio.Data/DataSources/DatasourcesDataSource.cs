using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DatasourcesDataSource : DataSourceBase<MenuSchema>
    {
        private const string _file = "/Assets/Data/DatasourcesDataSource.json";

        protected override string CacheKey
        {
            get { return "DatasourcesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<MenuSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<MenuSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("DatasourcesDataSource.LoadData", ex.ToString());
                return new MenuSchema[0];
            }
        }

    }
}
