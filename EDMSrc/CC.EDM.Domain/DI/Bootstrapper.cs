using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using StructureMap;

namespace CC.EDM.Domain.DI
{
    public class Bootstrapper
    {
        public static bool _hasBeenInitialized = false;
        public static void Start()
        {
            if (!_hasBeenInitialized)
            {
                ConfigueInjection();
            }
        }
        public static void ConfigueInjection()
        {
            DependencyResolver.SetResolver(
                c =>
                {
                    try
                    {
                        return ObjectFactory.GetInstance(c);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }, s =>  ObjectFactory.GetAllInstances<object>().Where(t => t.GetType() == s));

            ObjectFactory.Configure(s => s.AddRegistry(new ControllerRegistry()));
        }




    }
}
