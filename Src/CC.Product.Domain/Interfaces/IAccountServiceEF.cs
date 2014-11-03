using System;
using System.Collections.Generic;
using System.Linq;
using CC.Product.Models.Account;
namespace CC.Product.Domain.Interfaces
{
    public interface IAccountServiceEF
    {
        CC.Product.Data.UnitOfWork unitOfWork { get; set; }
        IQueryable<User> AllUser();
    }
}
