using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReportDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }

        public ReportDTO(string name, DateTime date, int id)
        {
            Name = name;
            Date = date;
            ManagerId = id;
        }
    }
}
