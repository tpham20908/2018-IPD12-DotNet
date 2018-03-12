using System;
using System.IO;
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
                Console.WriteLine("Enter your GPA: ");
                String _gpaStr = Console.ReadLine();
                Console.WriteLine("Enter your program: ");
                String _program = Console.ReadLine();
                Person p;
                Student s;
                if (Int32.TryParse(_ageStr, out int _age))
                {
                    p = new Person(_name, _age);
                }
                else
                {
                    throw new InvalidDataException("Wrong input for age");
                }
                if (Int32.TryParse(_gpaStr, out int _gpa))
                {
                    s = new Student(_name, _age, _gpa, _program);
                }
                else
                {
                    throw new InvalidDataException("Wrong input for GPA");
                }
                Console.WriteLine(p.ToString());
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }

    class Student : Person
    {
        public Student (String _name, int _age, double _gpa, String _program) : base (_name, _age)
        {
            GPA = _gpa;
            Program = _program;
        }

        private double _gpa;
        public double GPA
        {
            get
            {
                return _gpa;
            }
            set
            {
                if (value < 0 || value > 4.3)
                {
                    throw new InvalidDataException("GPA must be in between 0 and 4.3");
                }
                _gpa = value;
            }
        }

        private String _program;
        public String Program
        {
            get
            {
                return _program;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new InvalidDataException("Name of Program cannot exceed 20 characters long.");
                }
                _program = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", GPA {0}, program {1}", _gpa, _program);
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
                    throw new InvalidDataException("Name is wrong formatted");
                    // Console.WriteLine("Not matched!");
                }
            }
        }

        override public String ToString()
        {
            return String.Format("{0} {1} years old", Name, Age);
        }
    }
}
