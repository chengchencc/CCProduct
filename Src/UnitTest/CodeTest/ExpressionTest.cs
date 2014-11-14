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
