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
            /*
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
            */

            PrimeArray PA = new PrimeArray();
            Console.WriteLine(PA[1]);
            Console.WriteLine(PA[2]);
            Console.WriteLine(PA[3]);
            Console.WriteLine(PA[4]);
            Console.WriteLine(PA[5]);
            Console.WriteLine(PA[6]);
            Console.WriteLine(PA[7]);
            Console.WriteLine(PA[8]);
            Console.WriteLine(PA[9]);
            Console.WriteLine(PA[10]);
            Console.WriteLine(PA[11]);
            Console.WriteLine(PA[541]);
            Console.WriteLine(PA[542]);
            Console.WriteLine(PA[543]);

            Console.ReadLine();
        }
    }

    class PrimeArray
    {
        /*
        public Boolean this[int pos]
        {
            get
            {
                return IsPrime(pos);
            }
        }
        */
        
        public long this[int pos]
        {
            get
            {
                return FindPrime(pos);
            }
        }
        
        static Boolean IsPrime(int number)
        {
            if (number == 1) return true;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static long FindPrime(int number)
        {
            int count = 0;
            long result = 0;
            int index = 0;
            while (true)
            {
                if (IsPrime(++index)) count++;
                if (count == number)
                {
                    result = index;
                    break;
                }
            }
            /*
            for (int i = 0; i < Math.Pow(2, 64); i++)
            {
                if (IsPrime(i)) count++;
                if (count == number)
                {
                    result = i;
                    break;
                }
            }
            */
            return result;
        }
    }

    class String10Storage
    {
        private String[] data = new String[10];

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
