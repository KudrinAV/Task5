﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Используйте только символы")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Имя клиента")]
        public string Client { get; set; }

        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Назватие товара")]
        public string Product { get; set; }

       
        [Range(0, 1000.0 , ErrorMessage ="Цена должна быть в диапозоне от 0 до 1000")]
        [DisplayName("Цена")]
        public double Price { get; set; }
    }

    public class EditSaleModel
    {
        public int Id { get; set; }
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новое имя клиента")]
        public string Client { get; set; }

        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новый товар")]
        public string Product { get; set; }

        [RegularExpression(@"[\d]+", ErrorMessage = "Используйте только символы и цифры")]
        [Range(0, 1000, ErrorMessage = "Цена должна быть в диапозоне от 0 до 1000")]
        [DisplayName("Новая цена")]
        public double Price { get; set; }

        [RegularExpression(@"[\w]+", ErrorMessage = "Используйте только символы и цифры")]
        [StringLength(20, ErrorMessage = "Не больше 20 символов")]
        [DisplayName("Новое имя менеджера")]
        public string ManagerName { get; set; }
    }
}