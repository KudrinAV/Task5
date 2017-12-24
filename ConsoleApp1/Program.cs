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
            using (IBridgeToBLL test = new BridgeToBLL())
            {
                foreach(var item in test.GetRoles("admin"))
                {
                    Console.WriteLine(item);
                }
            }
                
        }

    }
}
