using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Core;
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

        [Fact]
        public void loghelper_test()
        {
            LogHelper.WriteInfo("info");
            LogHelper.WriteError("error");
        }
        [Fact]
        public void passwordEncodingTest()
        {
            var a = Genersoft.Platform.Core.Common.Utils.passwordExpand("96niR3fsIyEsVNejULxb6lR3/bs=");
            var b = Genersoft.Platform.Core.Common.Utils.passwordExpress("96niR3fsIyEsVNejULxb6lR3/bs=");
            var c = Genersoft.Platform.Core.Common.Utils.passwordExpand("aaaaaa");
            var d = Genersoft.Platform.Core.Common.Utils.passwordExpress("aaaaaa");
            var e = Genersoft.Platform.Core.Common.Serializer.Deserialize(Convert.FromBase64String("96niR3fsIyEsVNejULxb6lR3/bs="));
            Genersoft.Platform.Core.Common.HashCryptographer hashCry = new Genersoft.Platform.Core.Common.HashCryptographer(System.Security.Authentication.HashAlgorithmType.Md5);
        }


    }
}
