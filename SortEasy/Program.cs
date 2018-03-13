using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortEasy
{
    class Person
    {
        public String Name;
        public int Age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            // Using "Object Intializer
            list.Add(new Person() { Name = "Jerry", Age = 22 });
            list.Add(new Person() { Name = "Emily", Age = 32 });
            list.Add(new Person() { Name = "Judy", Age = 25 });
            list.Add(new Person() { Name = "Tommy", Age = 29 });
            list.Add(new Person() { Name = "Frank", Age = 43 });

            // LINQ sorting
            var listByName = from p in list orderby p.Name select p;
            // convert to List if needed
            List<Person> personListByName = listByName.ToList();

            foreach (Person p in list)
            {
                Console.WriteLine("{0} is {1} y/o", p.Name, p.Age);
            }
            Console.WriteLine("=== Order by Name ===");
            foreach (Person p in listByName)
            {
                Console.WriteLine("{0} is {1} y/o", p.Name, p.Age);
            }
            Console.ReadLine();
        }
    }
}
