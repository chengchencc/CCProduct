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
    public class CarPoolingService : CC.Product.Domain.Services.ICarPoolingService 
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


    }

}
