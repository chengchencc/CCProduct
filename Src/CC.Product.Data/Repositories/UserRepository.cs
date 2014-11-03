using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Models.Account;

namespace CC.Product.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext context)
            : base(context)
        {

        }
    }



}
