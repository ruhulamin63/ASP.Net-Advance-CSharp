using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ProductService.GetNames();
            Console.WriteLine("Hello World");
        }
    }
}
