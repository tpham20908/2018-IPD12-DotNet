using System;
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

namespace RegisterPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            String name;
            Object gender = null;
            String pets = "";
            int age = 0;
            if (tbName.Text.Equals(""))
            {
                MessageBox.Show("Name cannot be empty", "Wrong name input");
            }
            name = tbName.Text;
            
            if (!int.TryParse(tbAge.Text, out int ageInput))
            {
                MessageBox.Show("Age must be an integer", "Wrong age input");
            }
            else
            {
                if (ageInput <= 0) MessageBox.Show("Age must be positive", "Wrong age input");
                else age = ageInput;
            }

            if (rbtnF.IsChecked == true) gender = rbtnF.Content;
            if (rbtnM.IsChecked == true) gender = rbtnM.Content;
            if (rbtnOther.IsChecked == true) gender = rbtnOther.Content;

            if ((bool)ckbxTiger.IsChecked) pets += ckbxTiger.Content;
            if ((bool)ckbxLion.IsChecked) pets += ckbxLion.Content;
            if ((bool)ckbxBear.IsChecked) pets += ckbxBear.Content;

            String continent = cbbxContinent.Text;

            String data = String.Format(@"{0};{1};{2};{3};{4}", name, age, gender, pets, continent) + Environment.NewLine;
            File.AppendAllText(@"..\..\people.txt", data);
        }
    }
}
