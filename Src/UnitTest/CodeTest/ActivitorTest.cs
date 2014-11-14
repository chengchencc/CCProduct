using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.CodeTest
{
    class ActivitorTest
    {
        [Fact]
        public void test()
        {
            Object[] aa = new Object[3];
            aa[0] = "ctorCreated";
            aa[1]=10;
            aa[2] = 15;

            var class1 = (Class1)Activator.CreateInstance(typeof(Class1),aa);
            var result = class1.Method1(1, "key");
        }
    }

    class Class1
    {
        private string _ctorCreateValue;
        private int _ctorCreateIntValue;
        private int _ctorCreateIntValue2;
        public Class1(string inValue, int inIntValue, int ctorCreateIntValue2)
        {
            _ctorCreateValue = inValue;
            _ctorCreateIntValue = inIntValue;
            _ctorCreateIntValue2 = ctorCreateIntValue2;
        }
        public string Method1(int i,string key)
        {
            return i + key+_ctorCreateValue;
        }
    }
}
