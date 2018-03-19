using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBinding_TeacherVersion
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            _id = ++instanceCount;
        }

        private static int instanceCount;

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException("Name must be 2-50 characters long");
                }
                _name = value;
            }
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
                if (value < 1 || value > 150)
                {
                    throw new ArgumentException("Age must be 1-150");
                }
                _age = value;
            }
        }
    }
}
