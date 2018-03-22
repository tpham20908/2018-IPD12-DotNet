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

namespace CustomSandwich
{
    /// <summary>
    /// Interaction logic for Custom.xaml
    /// </summary>
    public partial class Custom : Window
    {
        public Custom()
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
                ComboBoxItem bread = (ComboBoxItem) cbbxBread.SelectedItem;
                if (bread != null) return bread.Content.ToString();
                return "...";
            }
        }

        public String Meat
        {
            get
            {
                if (rbtnChicken.IsChecked == true) return rbtnChicken.Content.ToString();
                else if (rbtnTurkey.IsChecked == true) return rbtnTurkey.Content.ToString();
                else if (rbtnBeef.IsChecked == true) return rbtnBeef.Content.ToString();
                else return rbtnTofu.Content.ToString();
            }
        }

        public String Veggies
        {
            get
            {
                List<string> vegs = new List<string>(); ;
                if (ckbxLettuce.IsChecked == true) vegs.Add(ckbxLettuce.Content.ToString());
                if (ckbxTomatoes.IsChecked == true) vegs.Add(ckbxTomatoes.Content.ToString());
                if (ckbxCucumbers.IsChecked == true) vegs.Add(ckbxCucumbers.Content.ToString());
                return String.Join(", ", vegs);
            }
        }
        
    }
}
