using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    class Person
    {
        public Person(int id, string name, int age, double height)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        //private static int instanceCount;

        public int Id { get; set; }

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

        private double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 30 || value > 300)
                {
                    throw new ArgumentException("Height must be 3-300");
                }
                _height = value;
            }
        }
    }
}
