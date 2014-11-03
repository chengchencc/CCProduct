using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Data.Contexts;
using CC.Product.Data.Repositories;
using CC.Product.Models.Account;

namespace CC.Product.Data
{
    public class UnitOfWork : IDisposable
    {
        private LocalDBContext localDbContext = new LocalDBContext();

        #region Repository Properties
        //public GenericRepository<User> UserRepository
        //{
        //    get
        //    {
        //        if (_userRepository == null)
        //        {
        //            _userRepository = new GenericRepository<User>(localDbContext);
        //        }
        //        return _userRepository;
        //    }
        //} private GenericRepository<User> _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(localDbContext);
                }
                return _userRepository;
            }
        } private UserRepository _userRepository;

        public RoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(localDbContext);
                }
                return _roleRepository;
            }
        } private RoleRepository _roleRepository;

        public UserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                {
                    _userRoleRepository = new UserRoleRepository(localDbContext);
                }
                return _userRoleRepository;
            }
        } private UserRoleRepository _userRoleRepository;
        #endregion
        public void Save()
        {
            localDbContext.SaveChanges();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    localDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }


}
