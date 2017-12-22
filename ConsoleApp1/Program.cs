using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IBridgeToBLL test = new BridgeToBLL();

            foreach(var item in test.GetSales()){
                Console.WriteLine(item.Price);
            }

            Console.ReadLine();
        }

    }
}
