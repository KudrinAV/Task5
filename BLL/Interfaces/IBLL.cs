using AutoMapper;
using BLL.DTO;
using Model.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBLL : IDisposable
    {
        void AddSale(SaleDTO sale);
        void AddSales(ICollection<SaleDTO> sales);
        void AddManager(ManagerDTO manager);
        int? GetManagerId(string managerLastName);
        bool CheckManager(string managerLastName);
        IEnumerable<SaleDTO> GetSales();
        bool CheckUser(string login, string password);
        string[] GetRoles(string login);
        bool CreateUser(string managerName, string login, string password);
        IEnumerable<UserDTO> GetUsers();
        bool EditUser(string oldLogin, string newLogin, string newPassword, string newManagerName);
        bool DeleteUser(string login);
        IEnumerable<ManagerDTO> GetManagers();
        bool CreateManager(string Name);
        bool EditManager(string oldName, string newName);
        bool DeleteManager(string Name);
        bool CreateSale(SaleDTO sale);
        bool EditSale(int Id, SaleDTO sale);
        bool DeleteSale(int Id);
        int GetManagerIdForUser(string login);
        string GetManagerName(int id);
    }
}
