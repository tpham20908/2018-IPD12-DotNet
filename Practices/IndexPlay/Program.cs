using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            String10Storage strs = new String10Storage();
            strs[2] = "This index is stored by a string.";
            strs[3] = "This index is stored by another string.";
            strs[5] = "This index is also stored by a string.";
            strs[7] = "This index is also stored by another string.";
            strs[8] = "This index is stored by one more string.";
            strs[9] = "This index is stored by another more string.";

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(strs[i]);
            }

            Console.ReadLine();
        }
    }

    class String10Storage
    {
        String[] data = new String[10];

        public String10Storage()
        {
            for (int i = 0; i < 10; i++)
            {
                data[i] = "empty string";
            }
        }

        public String this[int pos]
        {
            get
            {
                return data[pos];
            }
            set
            {
                data[pos] = value;
            }
        }
    }
}
