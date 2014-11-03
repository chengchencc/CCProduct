using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Data;
using CC.Product.Models.Account;

namespace CC.Product.Domain.Services
{
   public class AccountServiceEF : CC.Product.Domain.Interfaces.IAccountServiceEF
    {
        public UnitOfWork unitOfWork { get; set; }
       public AccountServiceEF()
       {
           unitOfWork = new UnitOfWork();
       }
       public IQueryable<User> AllUser()
       {
           return unitOfWork.UserRepository.Get();
       }
       public IQueryable<Role> AllRole()
       {
           return unitOfWork.RoleRepository.Get();
       }
       public IQueryable<UserRole> AllUserRole()
       {
           return unitOfWork.UserRoleRepository.Get();
       }
    }
}
