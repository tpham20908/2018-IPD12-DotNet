using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your name: ");
                String _name = Console.ReadLine();
                Console.WriteLine("Enter your age: ");
                String _ageStr = Console.ReadLine();
                if (Int32.TryParse(_ageStr, out int _age))
                {
                    Person p = new Person(_name, _age);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }

    class Person
    {
        public Person (String _name, int _age)
        {
            Name = _name;
            Age = _age;
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new IndexOutOfRangeException("Age must be in between 0 and 150.");
                }
                _age = value;
            }
        }

        private String _name;

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                Regex r = new Regex(@"^[A-Za-z0-9\. -]{1,20}$");
                Match m = r.Match(value);
                if (m.Success)
                {
                    _name = value;
                    // Console.WriteLine("Matched!");
                }
                else
                {
                    throw new Exception("Wrong format.");
                    // Console.WriteLine("Not matched!");
                }
            }
        }
    }
}
