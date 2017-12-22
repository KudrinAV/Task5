using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ManagerViewModel
    {
        public string LastName { get; set; }

        public ManagerViewModel(string name)
        {
            LastName = name;
        }
    }
}
