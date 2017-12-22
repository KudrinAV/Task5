using Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Manager Manager { get; set; }
    }
}
