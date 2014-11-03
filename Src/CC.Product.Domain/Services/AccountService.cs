using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackMamba.Framework.SubSonic;
using CC.Product.Data;
using CC.Product.Domain.Interfaces;
using CC.Product.Models;
using CC.Product.Models.Account;
using SubSonic.Repository;

namespace CC.Product.Domain.Services
{
    public class AccountService : IAccountService
    {

        #region DbContext
        public string ConnectionStringName
        {
            get { return ConnectionStringKeys.DefaultConnection; }
        }

        public IRepository DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = DbContextFactory.CreateSimpleRepository(this.ConnectionStringName);
                }
                return _dbContext;
            }
            internal set
            {
                _dbContext = value;
            }
        }  private IRepository _dbContext;
        #endregion

        public IQueryable GetAllUsers()
        {
            var a = DbContext.All<User>();
            return a;
        }

        public int ValidateUser(string userName,string password )
        {
            var user = DbContext.Single<User>(s => s.Email == userName && s.Password == password);
            if (user!=null)
            {
                return user.Id;
            }
            return -1;
        }

    }

}
