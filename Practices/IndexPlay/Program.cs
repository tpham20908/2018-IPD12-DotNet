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

            for (int i = 1; i < 30; i++)
            {
                Console.WriteLine("Prime number {0} is : {1}", i, PA[i]);
            }
            Console.ReadLine();
        }
    }

    class PrimeArray
    {
        /*
        public bool this[int pos]
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

        public bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0 && i != number) return false;
            }
            return true;
        }

        public long FindPrime (int number)
        {
            int count = 0;
            int i = 0;
            long result;
            while (true)
            {
                if (IsPrime(++i)) count++;
                if (count == number)
                {
                    result = i;
                    break;
                }
            }
            return result;
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
