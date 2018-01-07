using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Model.Interfaces;
using Model.DataModel;
using Model.DALElements;
using AutoMapper;
using Model.Entities;
using BLL.Infrastructure;
using System.IO;
using System.Data.Entity;

namespace BLL.Bridges
{
    public class BLL : IBLL
    {
        private IUnitOfWork _db;

        public BLL()
        {
            _db = new EFUnitOfWork();
        }

        public void AddManager(ManagerDTO manager)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, Manager>();
            });
            IMapper mapper = config.CreateMapper();
            _db.Managers.Create(mapper.Map<ManagerDTO, Manager>(manager));
            _db.Save();
        }
        


        public void AddSale(SaleDTO sale)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, Sale>()
                    .ForMember(dest => dest.Manager,
                             opts => opts.MapFrom(src => _db.Managers.FindById(src.ManagerId)));
            });
            IMapper mapper = config.CreateMapper();
            if (sale != null)
            {
                _db.Sales.Create(mapper.Map<SaleDTO, Sale>(sale));
                _db.Save();
            }
        }

        public void AddSales(ICollection<SaleDTO> sales)
        {
            foreach (var item in sales)
            {
                AddSale(item);
            }
        }

        public int? GetManagerId(string managerLastName)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == managerLastName).FirstOrDefault();
            if (manager != null) { return manager.ManagerID; }
            else return null;
        }

        public IEnumerable<SaleDTO> GetSales()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Sale>, List<SaleDTO>>(_db.Sales.Get());
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool CheckManager(string managerLastName)
        {
            if (_db.Managers.Get(x => x.LastName == managerLastName).Any()) return true;
            else return false;
        }

        public bool CheckUser(string login, string password)
        {
            if (_db.Users.Get(x => x.Login == login && x.Password == password).Any()) return true;
            else return false;
        }

        public string[] GetRoles(string login)
        {
            string[] result = new string[] { _db.Roles.FindById(_db.Users.Get(x => x.Login == login).FirstOrDefault().RoleId).Name };
            return result; ;
        }

        public bool CreateUser(string managerName, string login, string password)
        {
            if (_db.Users.Get(x => x.Login == login).Any()) return false;
            else
            {
                if (!_db.Managers.Get(x => x.LastName == managerName).Any())
                    AddManager(new ManagerDTO(managerName));
                _db.Users.Create(new User
                {
                    Login = login,
                    Password = password,
                    ManagerId = _db.Managers.Get(x => x.LastName == managerName).FirstOrDefault().ManagerID,
                    RoleId = 2
                });
                _db.Save();
                return true;
            }
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(_db.Users.Get());
        }

        public bool EditUser(string oldLogin, string newLogin, string newPassword, string newManagerName)
        {
            User user = _db.Users.Get(x => x.Login == oldLogin).FirstOrDefault();
            if (user != null)
            {
                if (newLogin != null) user.Login = newLogin;
                if (newPassword != null) user.Password = newPassword;
                if (newManagerName !=null)
                {
                    if (CheckManager(newManagerName))
                    {
                        user.ManagerId = _db.Managers.Get(x => x.LastName == newManagerName).FirstOrDefault().ManagerID;
                    }
                    else
                    {
                        CreateManager(newManagerName);
                        user.ManagerId = _db.Managers.Get(x => x.LastName == newManagerName).FirstOrDefault().ManagerID;
                    }
                }
                _db.Users.Update(user);
                _db.Save();
                return true;
            }
            else return false;
        }

        public bool DeleteUser(string login)
        {
            User user = _db.Users.Get(x => x.Login == login).FirstOrDefault();
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.Save();
                return true;
            }
            else return false;
        }

        public IEnumerable<ManagerDTO> GetManagers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manager, ManagerDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(_db.Managers.Get());
        }
        

        public bool CreateManager(string name)
        {
            if (CheckManager(name)) return false;
            else
            {
                AddManager(new ManagerDTO(name));
                return true;
            }
        }

        public bool EditManager(string oldName, string newName)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == oldName).FirstOrDefault();
            if (manager != null)
            {
                if (newName != null) manager.LastName = newName;
                _db.Managers.Update(manager);
                _db.Save();
                return true;
            }
            else return false;
        }

        public bool DeleteManager(string name)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == name).FirstOrDefault();
            if (manager != null)
            {
                _db.Managers.Remove(manager);
                _db.Save();
                return true;
            }
            else return false;
        }

        public bool CreateSale(SaleDTO sale)
        {
            if (sale != null)
            {
                AddSale(sale);
                return true;
            }
            else return false;
        }

        public bool EditSale(int Id, SaleDTO saleEdited)
        {
            Sale sale = _db.Sales.FindById(Id);
            if (sale != null)
            {
                sale.Date = saleEdited.Date;
                if (saleEdited.Client != null) sale.Client = saleEdited.Client;
                if (saleEdited.Product != null) sale.Product = saleEdited.Product;
                if (saleEdited.Price != 0) sale.Price = saleEdited.Price;
                if (saleEdited.ManagerId != 0) sale.Manager = _db.Managers.FindById(saleEdited.ManagerId);
                _db.Sales.Update(sale);
                _db.Save();
                return true;
            }
            else return false;
        }

        public bool DeleteSale(int Id)
        {

            Sale sale = _db.Sales.FindById(Id);
            if (sale != null)
            {
                _db.Sales.Remove(sale);
                _db.Save();
                return true;
            }
            else return false;
        }
      

        public int GetManagerIdForUser(string login)
        {
            return _db.Users.Get(x => x.Login == login).FirstOrDefault().ManagerId;
        }

        public string GetManagerName(int id)
        {
            return _db.Managers.Get(x => x.ManagerID == id).FirstOrDefault().LastName;
        }
    }
}
