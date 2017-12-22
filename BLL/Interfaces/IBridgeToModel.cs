using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBridgeToModel
    {
        void AddSale(SaleDTO sale, IMapper mapper);
        void AddSales(ICollection<SaleDTO> sales);
        void AddReport(ReportDTO report);
        void AddManager(ManagerDTO manager);
        int? GetManagerId(string managerLastName);
        bool CheckManager(string managerLastName);
        void CheckFile(FileSystemEventArgs e);
        void Dispose();
    }
}
