using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.EDM.Domain.Services
{
    public interface IIocTest{
        string GetName();
    }
   public class IocTest:IIocTest
    {
       public string GetName()
       {
           return "ChengChen";
       }
    }
}
