using System;
using System.Collections.Generic;
using System.IO;
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
                String[] lines = File.ReadAllLines(@"..\..\people.txt");
                foreach (String line in lines)
                {
                    if (!line.Equals(""))
                    {
                        String type = line.Split(':')[0];
                        String details = line.Split(':')[1];
                        AddToList(type, details);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach(Person p in PeopleList)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadLine();
        }

        static void AddToList (String type, String details)
        {
            String[] detailsArr = details.Split(',');
            String name = detailsArr[0];
            int age;
            switch (type)
            {
                case "Person":
                    if (!int.TryParse(detailsArr[1], out age))
                    {
                        Console.WriteLine("Age must be an integer.");
                    }
                    else
                    {
                        PeopleList.Add(new Person(name, age));
                    }
                    break;
                case "Student":
                    String gpaStr = detailsArr[2];
                    String program = detailsArr[3];
                    if (!int.TryParse(detailsArr[1], out age))
                    {
                        Console.WriteLine("Age must be an integer.");
                    }
                    if (!double.TryParse(gpaStr, out double gpa))
                    {
                        Console.WriteLine("Wrong type of GPA.");
                    }
                    PeopleList.Add(new Student(name, age, gpa, program));
                    break;
                case "Teacher":
                    String subject = detailsArr[2];
                    String experienceStr = detailsArr[3];
                    if (!int.TryParse(detailsArr[1], out age))
                    {
                        Console.WriteLine("Wrong type of age.");
                    }
                    if (!int.TryParse(experienceStr, out int experience))
                    {
                        Console.WriteLine("Wrong type of experience.");
                    }
                    PeopleList.Add(new Teacher(name, age, subject, experience));
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
        private int _experience;

        public String Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (value.Length < 1 || value.Length > 20)
                {
                    Console.WriteLine("Subject must be in between 1 and 20 characters.");
                }
                else
                {
                    _subject = value;
                }
            }
        }

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
                    Console.WriteLine("Experience must be in between 0 and 100.");
                }
                else
                {
                    _experience = value;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", subject {0}, experience {1} years", Subject, Experience);
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
        private String _program;

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
                    Console.WriteLine("GPA must be in 0 and 4.3");
                }
                else
                {
                    _gpa = value;
                }
            }
        }

        public String Program
        {
            get
            {
                return _program;
            }
            set
            {
                if (value.Length < 1 || value.Length > 20)
                {
                    Console.WriteLine("Program name must be in between 1 and 20 characters");
                }
                else
                {
                    _program = value;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", GPA {0}, program {1}", GPA, Program);
        }
    }

    class Person
    {
        private String _name;
        private int _age;

        public Person (String _name, int _age)
        {
            Name = _name;
            Age = _age;
        }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                Regex r = new Regex(@"^[a-zA-Z0-9\. -]{1,20}$");
                Match m = r.Match(value);
                if (m.Success)
                {
                    _name = value;
                }
                else
                {
                    throw new InvalidDataException("Name is not matched.");
                }
            }
        }

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
                    Console.WriteLine("Age must be greater than 0 and less than 150.");
                }
                _age = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} years old", Name, Age);
        }
    }
}
