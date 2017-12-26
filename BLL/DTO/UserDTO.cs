using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int ManagerId { get; set; }
    }
}
