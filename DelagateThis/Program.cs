using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelagateThis
{
    class Program
    {
        static void PrintSimple(String line)
        {
            Console.WriteLine("SIMPLE: " + line);
        }

        static void PrintFancy(String line)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!{0}!!!!!!!!!!!!!!!{1}", line, line.Length);
        }

        static void PrintToFile(String line)
        {
            File.AppendAllText(@"..\..\output.txt", line + "\n");
        }

        // declare the type of reference to a method -  the signature of the method
        delegate void PrinterMethodType(String s);

        static void Main(string[] args)
        {
            PrinterMethodType printer = null;

            // add methods to delegate
            printer = PrintSimple;
            printer += PrintFancy;
            printer += PrintToFile;

            // remove method from delegate
            printer -= PrintFancy;
            printer("Hello via delegate");
            Console.ReadLine();
        }
    }
}
