using Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
