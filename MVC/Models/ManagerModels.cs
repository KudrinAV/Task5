using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ManagerModel
    {
        public string Name { get; set; }
    }

    public class EditManagerModel
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}