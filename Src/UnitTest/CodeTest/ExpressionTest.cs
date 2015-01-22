using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;
using Xunit;

namespace UnitTest
{
    public class ExpressionTest
    {
        [Fact]
        public void test()
        {


            Expression<Func<ClassA, bool>> e = s => s.Id == 1 && s.Name == "";

            //List<ClassA> lc = new List<ClassA>();
            //lc.Where(s => s.Name == "");



        }

        [Fact]
        public void string_test()
        {
            var str = "http://10.24.15.5:9090/cwbase/WebFramework/mainHJ.htm?gnd=JGXT_WPRY&gndCode=JGXT_WPRY";
            var gndindex = str.IndexOf("gndCode=");
            var res = str.Substring(gndindex+8);
        }
    }
    public class ClassA
    {
        public int Id { get; set; }

        [SubSonicNullString]
        public string Name { get; set; }
        public string No { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
        public bool IsOut { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
