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

namespace Quiz2Passengers
{
    /// <summary>
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        private Passenger currentP;
        public InputDialog(Passenger p)
        {
            currentP = p;
            InitializeComponent();
            if (currentP == null)
            {
                btnSave.Content = "Add new";
            }
            else
            {
                lblId.Content = p.Id + "";
                tbName.Text = p.Name;
                tbPassport.Text = p.Passport;
                tbDestination.Text = p.Destination;
                dpkDepartureDate.SelectedDate = p.DepartureDateTime;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Passenger p = currentP == null ? new Passenger() : currentP;
            try
            {
                p.Name = tbName.Text;
                p.Passport = tbPassport.Text;
                p.Destination = tbDestination.Text;
                p.DepartureDateTime = (DateTime)dpkDepartureDate.SelectedDate;
                if (currentP == null)
                {
                    Global.db.AddPassenger(p);
                }
                else
                {
                    Global.db.UpdatePassenger(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Passenger p = currentP;
            if (p == null)
            {
                return;
            }
            Global.db.DeletePassenger(currentP.Id);
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
