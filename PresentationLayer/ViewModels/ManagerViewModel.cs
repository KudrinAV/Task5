using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ManagerViewModel
    {
        public int ManagerID { get; set; }
        public string LastName { get; set; }

        public ManagerViewModel()
        {

        }

        public ManagerViewModel(string name)
        {
            LastName = name;
        }
    }
}
