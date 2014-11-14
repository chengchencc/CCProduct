using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Domain.Interfaces;
using CC.Product.Domain.Services;
using StructureMap.Configuration.DSL;

namespace CC.Product.Domain.DI
{
    public class ControllerRegistry:Registry
    {
        public ControllerRegistry()
        {
            Startup();
        }
        public void Startup(){
            RegisterCommonService();
        }
        public void RegisterCommonService()
        {
            For<IAccountServiceEF>().Use<AccountServiceEF>();
            For<IAccountService>().Use<AccountService>();
            For<ICarPoolingService>().Use<CarPoolingService>();
            For<IIocTest>().Use<IocTest>();
        }

    }
}
