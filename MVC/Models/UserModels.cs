using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EditUserModel
    {
        public string OldLogin { get; set; }


        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новый логин")]
        public string NewLogin { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новый пароль")]
        public string NewPassword { get; set; }

        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Используйте только символы")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новое имя менеджера")]
        public string NewManagerName { get; set; }
    }
    
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ManagerName { get; set; }
    }


}