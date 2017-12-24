using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EditUserModel
    {
        public string OldLogin { get; set; }

        public string NewLogin { get; set; }
        public string NewPassword { get; set; }
    }
}