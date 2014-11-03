using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Data;
using CC.Product.Data.Contexts;
using CC.Product.Data.Repositories;
using Xunit;

namespace UnitTest
{
    public class EFConnectionTest
    {
        [Fact]
        public void ef_connection_test()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var allUsers = unitOfWork.UserRepository.Get().ToList();
        }
        [Fact]
        public void model_test()
        {
            LocalDBContext localDbContext = new LocalDBContext();
            var repository = new GenericRepository<TestModel>(localDbContext);
            var all = repository.Get();
        }

    }
    public class TestModel{
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
