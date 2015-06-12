using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.EDM.Domain.Services;
using EDMWebsite;
using EDMWebsite.Models;
using Xunit;

namespace CC.EDM.UnitTest
{
    public class SyncTest
    {
        DeviceDbContext MysqlDb = new DeviceDbContext();
        WriteableSqlDbContext SqlDb = new WriteableSqlDbContext();

        [Fact]
        public void Sync_Data_Test()
        {
            SyncDataService syncService = new SyncDataService();
            syncService.SyncEnergyItemData();
        }
        [Fact]
        public void Sync_Hour_Test()
        {
            SyncDataService syncService = new SyncDataService();
            syncService.SyncEnergyHourData();
        }

    }
}
