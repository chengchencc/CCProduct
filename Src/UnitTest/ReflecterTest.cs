using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    class ReflecterTest
    {
        [Fact]
        public void test()
        {

            //获取class实例
            var createdByGenericity = Activator.CreateInstance<ReflecterUsedClass>();
            var createdByReflecter = Activator.CreateInstance(typeof(ReflecterUsedClass));

            var properties = typeof(ReflecterUsedClass).GetProperties();
            var propertie = properties[0];


        //   private void reflectControls(){
        //    var controls = this.GetType().GetProperties().Where(s=>s.PropertyType is XmlElement);
        //    MethodInfo GetControlByIdMethod = this.GetType().GetMethod("GetControlById");

        //    foreach (var control in controls)
        //    {
        //      var curMethod=   GetControlByIdMethod.MakeGenericMethod(control.PropertyType);
        //        var parameters = new object[1];
        //        parameters[1] = "cbHZND";
        //      curMethod.Invoke(this, parameters);
        //    }
        //        Convert.ChangeType()
        //}

        }

    }

    public class ReflecterUsedClass
    {
        public int IntProperty { get; set; }
        public string StringProperty { get; set; }
    }


}
