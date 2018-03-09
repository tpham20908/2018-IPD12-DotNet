using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            if (name == "Santa")
            {
                Console.WriteLine("Cant believe it's Santa");
            }
            else
            {
                Console.WriteLine("Hello {0}, nice to meet you {0}!", name);
            }
            Console.ReadLine();
        }
    }
}
