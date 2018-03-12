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
        static List<Person> PeopleList = new List<Person>();

        static void Main(string[] args)
        {
            try
            {
                String[] lines = File.ReadAllLines(@"../../people.txt");
                foreach (String line in lines)
                {
                    if (!line.Equals(""))
                    {
                        String type = line.Split(':')[0];
                        String detail = line.Split(':')[1];
                        addList(type, detail);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found." + ex.Message);
            }

            foreach (Person p in PeopleList)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadLine();
            /*
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
                Console.WriteLine("Enter your subject: ");
                String _subject = Console.ReadLine();
                Console.WriteLine("Enter your experience: ");
                String _experienceStr = Console.ReadLine();
                Person p, s, t;
                if (int.TryParse(_ageStr, out int _age))
                {
                    p = new Person(_name, _age);
                }
                else
                {
                    throw new InvalidDataException("Wrong input for age");
                }
                if (Double.TryParse(_gpaStr, out Double _gpa))
                {
                    s = new Student(_name, _age, _gpa, _program);
                }
                else
                {
                    throw new InvalidDataException("Wrong input for GPA");
                }
                if (int.TryParse(_experienceStr, out int _experience))
                {
                    t = new Teacher(_name, _age, _subject, _experience);
                }
                else
                {
                    throw new InvalidDataException("Wrong input for GPA");
                }
                Console.WriteLine(p.ToString());
                Console.WriteLine(s.ToString());
                Console.WriteLine(t.ToString());
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

        }

        static void addList(String type, String detail)
        {
            String[] info = detail.Split(',');
            String name = info[0];
            int age;
            switch (type)
            {
                case "Person":
                    if (int.TryParse(info[1], out age)) {
                        PeopleList.Add(new Person(name, age));
                    }
                    else
                    {
                        throw new InvalidDataException("Wrong input for age");
                    }
                    break;
                case "Student":
                    String program = info[3];
                    if (int.TryParse(info[1], out age) &&
                        double.TryParse(info[2], out double gpa))
                    {
                        PeopleList.Add(new Student(name, age, gpa, program));
                    }
                    else
                    {
                        throw new InvalidDataException("Wrong input for age or gpa");
                    }
                    break;
                case "Teacher":
                    String subject = info[2];
                    if (int.TryParse(info[1], out age) && 
                        int.TryParse(info[3], out int experience))
                    {
                        PeopleList.Add(new Teacher(name, age, subject, experience));
                    }
                    else
                    {
                        throw new InvalidDataException("Wrong input for age or experience");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    class Teacher : Person
    {
        public Teacher (String _name, int _age, String _subject, int _experience) : base (_name, _age)
        {
            Subject = _subject;
            Experience = _experience;
        }

        private String _subject;
        public String Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (value.Length == 0 ||value.Length > 20)
                {
                    throw new InvalidDataException("Subject must be in between 1 and 20 characters");
                }
                _subject = value;
            }
        }

        private int _experience;
        public int Experience
        {
            get
            {
                return _experience;                     
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new InvalidDataException("Experience must be in between 0 and 100.");
                }
                _experience = value;
            }
        }

        public override string ToString()
        {
            return "Teacher " + base.ToString() 
                + String.Format(", subject {0}, {1} year(s) experience", _subject, _experience);
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
                if (value.Length == 0 || value.Length > 20)
                {
                    throw new InvalidDataException("Name of Program cannot exceed 20 characters long.");
                }
                _program = value;
            }
        }

        public override string ToString()
        {
            return "Student " + base.ToString() + String.Format(", GPA {0}, program {1}", _gpa, _program);
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
