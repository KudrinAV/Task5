using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(@"[\w]+", ErrorMessage ="Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage ="Не больше 20 символов")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string Password { get; set; }
    }

    public class CreateUserModel
    {
        [Required]
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string ManagerName { get; set; }

        [Required]
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        public string Password { get; set; }
    }


}