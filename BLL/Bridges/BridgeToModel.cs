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
using BLL.ParserObj;

namespace BLL.Bridges
{
    public class BridgeToModel : IBridgeToModel
    {
        private IUnitOfWork _db;

        public BridgeToModel()
        {
            _db = new EFUnitOfWork();
        }

        public void CheckFile(FileSystemEventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
            string[] tmp = fileName.Split('_');
            if (CheckManager(tmp[0]))
            {
                string pattern = "ddMMyyyy";
                if (DateTime.TryParseExact(tmp[1], pattern, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    int? id = GetManagerId(tmp[0]);
                    AddReport(new ReportDTO(fileName, parsedDate, (int)id));
                    ParseFile(e.FullPath, (int)id);
                }
                else throw new ValidationException("Bad data time", "");
            }
            else
            {
                if (tmp[1] != null)
                    AddManager(new ManagerDTO(tmp[0]));
                else throw new ValidationException("Bad filing name", "");
            }
        }

        private void ParseFile(string path, int id)
        {
            Parser parser = new Parser();
            AddSales(parser.ParserCSV(path, id));
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

        public void AddReport(ReportDTO report)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportDTO, Report>()
                    .ForMember(dest => dest.Manager,
                            opts => opts.MapFrom(src => _db.Managers.FindById(src.ManagerId)));
            });
            IMapper mapper = config.CreateMapper();
            _db.Reports.Create(mapper.Map<ReportDTO, Report>(report));
            _db.Save();
        }


        public void AddSale(SaleDTO sale, IMapper mapper)
        {
            if (sale != null)
            {
                _db.Sales.Create(mapper.Map<SaleDTO, Sale>(sale));
                _db.Save();
            }
        }

        public void AddSales(ICollection<SaleDTO> sales)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, Sale>()
                    .ForMember(dest => dest.Manager,
                             opts => opts.MapFrom(src => _db.Managers.FindById(src.ManagerId)));
            });
            IMapper mapper = config.CreateMapper();
            foreach (var item in sales)
            {
                AddSale(item, mapper);
            }
        }

        public int? GetManagerId(string managerLastName)
        {
            Manager manager = _db.Managers.Get(x => x.LastName == managerLastName).First();
            if (manager != null) { return manager.ManagerID; }
            else return null;
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
    }
}
