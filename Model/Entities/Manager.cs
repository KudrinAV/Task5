using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class Manager
    {
        [Key]
        public int ManagerID { get; set; }
        public string LastName { get; set; }

       
        public ICollection<User> Users { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
