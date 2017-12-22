using Model.DataModel;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Manager> Managers { get; }
        IGenericRepository<Sale> Sales { get; }
        IGenericRepository<Report> Reports { get; }
        void Save();
    }
}
