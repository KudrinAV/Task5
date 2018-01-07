using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.ViewModels;
using BLL.Interfaces;
using BLL.Bridges;
using BLL.DTO;
using AutoMapper;
using System.IO;

namespace PresentationLayer.Bridge
{
    public class PL : IPL
    {
        IBLL _dbConnect;

        public PL()
        {
            _dbConnect = new BLL.Bridges.BLL();
        }
        
        public IEnumerable<SaleViewModel> GetSales()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, SaleViewModel>();
            });
            IMapper mapper = config.CreateMapper();


            return mapper.Map<IEnumerable<SaleDTO>, List<SaleViewModel>>(_dbConnect.GetSales());
        }

        public bool CheckUser(string login, string password)
        {
            return _dbConnect.CheckUser(login, password);
        }

        public void Dispose()
        {
            _dbConnect.Dispose();
        }

        public string[] GetRoles(string login)
        {
            return _dbConnect.GetRoles(login);
        }

        public bool CreateUser(string managerName, string login, string password)
        {
            return _dbConnect.CreateUser(managerName, login, password);
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserViewModel>();
            });
            IMapper mapper = config.CreateMapper();


            return mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(_dbConnect.GetUsers());
        }

        public bool EditUser(string oldLogin, string newLogin, string newPassword, string newManagerName)
        {
            return _dbConnect.EditUser(oldLogin, newLogin, newPassword, newManagerName);
        }

        public bool DeleteUser(string login)
        {
            return _dbConnect.DeleteUser(login);
        }

        public int? GetManagerId(string LastName)
        {
            return _dbConnect.GetManagerId(LastName);
        }

        public IEnumerable<ManagerViewModel> GetManagers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, ManagerViewModel>();
            });
            IMapper mapper = config.CreateMapper();


            return mapper.Map<IEnumerable<ManagerDTO>, List<ManagerViewModel>>(_dbConnect.GetManagers());
        }

        public bool CreateManager(string Name)
        {
            return _dbConnect.CreateManager(Name);
        }

        public bool EditManager(string oldName, string newName)
        {
            return _dbConnect.EditManager(oldName, newName);
        }

        public bool DeleteManager(string name)
        {
            return _dbConnect.DeleteManager(name);
        }

        public bool CreateSale(SaleViewModel sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleViewModel, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return _dbConnect.CreateSale(mapper.Map<SaleViewModel, SaleDTO>(sale));
        }

        public bool EditSale(int Id, SaleViewModel sale)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleViewModel, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return _dbConnect.EditSale(Id, mapper.Map<SaleViewModel, SaleDTO>(sale));
        }

        public bool DeleteSale(int Id)
        {
            return _dbConnect.DeleteSale(Id);
        }

        public int GetManagerIdForUser(string login)
        {
            return _dbConnect.GetManagerIdForUser(login);
        }

        public string GetManagerName(int id)
        {
            return _dbConnect.GetManagerName(id);
        }
    }
}
