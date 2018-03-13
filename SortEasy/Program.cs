using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortEasy
{
    class Person
    {
        public String name;
        public int age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            // Using "Object Intializer
            list.Add(new Person() { name = "Jerry", age = 22 });
            list.Add(new Person() { name = "Emily", age = 32 });
            list.Add(new Person() { name = "Judy", age = 25 });
            list.Add(new Person() { name = "Tommy", age = 29 });
            list.Add(new Person() { name = "Frank", age = 43 });

            foreach (Person p in list)
            {
                Console.WriteLine("{0} is {1} y/o", p.name, p.age);
            }
            Console.ReadLine();
        }
    }
}
