using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataModel;
using Model.Repositories;
using Model.Entities;

namespace Model.DALElements
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StoreAccountingContext _context;
        private IGenericRepository<Manager> _managers;
        private IGenericRepository<Sale> _sales;
        private IGenericRepository<User> _users;
        private IGenericRepository<Role> _roles;

        public EFUnitOfWork()
        {
            _context = new StoreAccountingContext();
        }

        public IGenericRepository<Role> Roles
        {
            get
            {
                return _roles ?? new EFGenericRepository<Role>(_context);
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return _users ?? new EFGenericRepository<User>(_context);
            }
        }

       
        public IGenericRepository<Manager> Managers
        {
            get
            {
                return _managers ?? new EFGenericRepository<Manager>(_context);
            }
        }

        public IGenericRepository<Sale> Sales
        {
            get
            {
                return _sales ?? new EFGenericRepository<Sale>(_context);
            }
        }


        ~EFUnitOfWork()
        {
            Dispose(false);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
