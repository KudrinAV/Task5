using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SaleModel
    {
        public string Client { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }

    public class EditSaleModel
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string ManagerName { get; set; }
    }
}