﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDMWebsite;
using EDMWebsite.Models;
using Xunit;


namespace CC.EDM.UnitTest
{
    public class MysqlToSqlTest
    {
        DeviceDbContext MysqlDb = new DeviceDbContext();
        WriteableSqlDbContext SqlDb = new WriteableSqlDbContext();
        [Fact]
        public void mysql_connection_test()
        {
            var tb_data = MysqlDb.tb_data.Take(10).ToList();
            Assert.NotEmpty(tb_data);
        }

        public void Sync_Data_Test()
        {

        }


    }
}