using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CustomSanwich
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public String Bread
        {
            get
            {
                return ((ComboBoxItem)cbbxBread.SelectedItem).Content.ToString();
            }
        }

        public String Vegies
        {
            get
            {
                List<String> vegies = new List<string>();
                if (ckbxCucumbers.IsChecked == true) vegies.Add("Cucumbers");
                if (ckbxLettuce.IsChecked == true) vegies.Add("Lettuce");
                if (ckbxTomatoes.IsChecked == true) vegies.Add("Tomatoes");
                return String.Join(", ", vegies);
            }
        }

        public String Meat
        {
            get
            {
                if (rbtnBeef.IsChecked == true) return rbtnBeef.Content + "";
                else if (rbtnChicken.IsChecked == true)  return rbtnChicken.Content + "";
                else return rbtnTurkey.Content + "";
            }
        }
    }
}
