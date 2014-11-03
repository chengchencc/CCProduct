using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Xunit;
namespace UnitTest
{
    class NLogTest
    {
        [Fact]
        public void test()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            logger.Debug("aaaaaaaaaaaaaaaaaaaaaa");
            
        }

    }
}
