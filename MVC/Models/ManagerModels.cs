using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ManagerModel
    {
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string Name { get; set; }
    }

    public class EditManagerModel
    {

        public string OldName { get; set; }

        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string NewName { get; set; }
    }
}