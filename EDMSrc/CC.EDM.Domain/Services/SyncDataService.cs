using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;
using EDMWebsite;
using EDMWebsite.Models.DbModels;
using EDMWebsite.Models;
namespace CC.EDM.Domain.Services
{
    public interface ISyncDataService
    {


    }
    public class SyncDataService : ISyncDataService
    {
        public DeviceDbContext MysqlDbContext { get; set; }
        public WriteableSqlDbContext NewEdmDb { get; set; }

        public SyncDataService()
        {
            MysqlDbContext = new DeviceDbContext();
            NewEdmDb = new WriteableSqlDbContext();
        }



    }
}
