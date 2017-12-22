using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ManagerDTO
    {
        public string LastName { get; set; }

        public ManagerDTO(string name)
        {
            LastName = name;
        }
    }
}
