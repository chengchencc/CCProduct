using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Models.Account;

namespace CC.Product.Data.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>
    {
        public UserRoleRepository(DbContext context)
            : base(context)
        {

        }
    }



}
