using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.EDM.Domain.Services;
using StructureMap.Configuration.DSL;

namespace CC.EDM.Domain.DI
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

            For<IIocTest>().Use<IocTest>();

        }

    }
}
