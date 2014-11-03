using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.Repository;
using Xunit;

namespace UnitTest
{
    public class SubsonicTest
    {
        IRepository repository;
        public SubsonicTest()
        {
            repository = new SimpleRepository("DefaultConnection", SimpleRepositoryOptions.RunMigrations);
        }
        [Fact]
        public void Test()
        {
            ClassA a = new ClassA() { Id = 1, Name = "name", Gender = Gender.Male, CreateTime = DateTime.Now, No = "001", IsOut = false };
            repository.Add<ClassA>(a);
            var a1 = repository.Find<ClassA>(s => s.Id == 1);
        
        
        }

    }

   

}
