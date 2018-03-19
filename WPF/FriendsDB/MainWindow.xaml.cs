using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace FriendsDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");

            conn.Open();

            String name = tbName.Text;

            // insert a record
            SqlCommand insertCommand = new SqlCommand("INSERT INTO FRIENDS (Name) VALUES (@name)", conn);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.ExecuteNonQuery();

            Refresh();
        }

        private void Refresh()
        {
            lvFriends.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT Name FROM Friends", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Console.WriteLine(String.Format("{0}\t{1}", reader[0], reader[1]));
                    ListViewItem item = new ListViewItem();
                    item.Content = reader[0];
                    lvFriends.Items.Add(item);
                }
            }
            conn.Close();
            tbName.Text = "";
        }
    }
}
