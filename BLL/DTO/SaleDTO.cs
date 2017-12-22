using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SaleDTO
    {
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }

        public int ManagerId { get; set; }

        public SaleDTO(DateTime time, string client, string product, double price, int id)
        {
            Date = time;
            Client = client;
            Product = product;
            Price = price;
            ManagerId = id;
        }
    }
}
