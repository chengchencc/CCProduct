using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDMWebsite.Models;
using Xunit;

namespace CC.EDM.UnitTest
{
    public class MysqlToSqlTest
    {
        DeviceDbContext db = new DeviceDbContext();

        [Fact]
        public void mysql_connection_test()
        {
            var tb_data = db.tb_data.Take(10).ToList();
            Assert.NotEmpty(tb_data);
        }
    }
}
