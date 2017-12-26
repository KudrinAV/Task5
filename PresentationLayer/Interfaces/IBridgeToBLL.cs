using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface IBridgeToBLL : IDisposable
    {
        IEnumerable<ManagerViewModel> GetManagers();
        IEnumerable<SaleViewModel> GetSales();
        IEnumerable<UserViewModel> GetUsers();
        int? GetManagerId(string LastName);
        bool CheckUser(string login, string password);
        bool CreateUser(string login, string password);
        string[] GetRoles(string login);
        bool EditUser(string oldLogin, string newLogin, string newPassword);
        bool DeleteUser(string login);
        bool CreateSale(SaleViewModel sale);
        bool EditSale(int Id, SaleViewModel sale );
        bool DeleteSale(int Id);
        bool CreateManager(string name);
        bool EditManager(string oldName, string newName);
        bool DeleteManager(string login);
        int GetManagerIdForUser(string login);
        IEnumerable<SaleViewModel> FilterByManager(string name);
        IEnumerable<SaleViewModel> FilterByProduct(string product);
        IEnumerable<SaleViewModel> FilterByDate(DateTime date);

    }
}
