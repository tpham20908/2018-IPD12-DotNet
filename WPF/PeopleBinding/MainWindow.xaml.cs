﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            List<Person> people = new List<Person>();
            people.Add(new Person() { ID = 1, Name = "Mario", Age = 23 });
            people.Add(new Person() { ID = 2, Name = "Lucas", Age = 22 });
            people.Add(new Person() { ID = 3, Name = "Marcus", Age = 31 });
            people.Add(new Person() { ID = 4, Name = "Stela", Age = 18 });
            
            lvPerson.ItemsSource = people;
            */
        }

        static List<Person> people = new List<Person>();
        static int Id = 0;

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String name = tbName.Text;
            String ageStr = tbAge.Text;
            try
            {
                int.TryParse(ageStr, out int age);
                Person p = new Person() { ID = ++Id , Name = name, Age = age };
                people.Add(p);
                lvPerson.Items.Add(p);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    class Person
    {
        //int _id = 0;
        int _age;
        String _name;
        /*
        public Person(String _name, int _age)
        {
            _id++;
            Name = _name;
            Age = _age;
        }
        */
        public int ID { get; set; }

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
                    throw new InvalidDataException("Age must be in between 0 and 150");
                }
                else
                {
                    _age = value;
                }
            }
        }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new InvalidDataException("Name must be 2 to 50 characters length");
                }
                else
                {
                    _name = value;
                }
            }
        }
    }
}
