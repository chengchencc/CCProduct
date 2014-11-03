using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackMamba.Framework.SubSonic;

namespace CC.Product.Domain.Interfaces
{
    public interface IAccountService : IDbContext
    {
        IQueryable GetAllUsers();
        int ValidateUser(string userName, string password);
    }
}
