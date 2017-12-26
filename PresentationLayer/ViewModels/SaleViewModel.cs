using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class SaleViewModel
    {
        public int SaleId { get; private set; }
        public DateTime Date { get; private set; }
        public string Client { get; private set; }
        public string Product { get; private set; }
        public double Price { get; private set; }

        public int ManagerId { get; private set; }

        public SaleViewModel()
        {

        }

        public SaleViewModel(DateTime time, string client, string product, double price, int id)
        {
            Date = time;
            Client = client;
            Product = product;
            Price = price;
            ManagerId = id;
        }
    }
}
