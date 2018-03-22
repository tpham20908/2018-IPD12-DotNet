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

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                Global.db = new Database();
                InitializeComponent();
                refreshTodoList();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        void refreshTodoList()
        {
            lvTodos.ItemsSource = Global.db.GetAllTodos();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditTodoDialog dialog = new AddEditTodoDialog(null);
            if (dialog.ShowDialog() == true)
            {
                refreshTodoList();
            }
        }
    }
}
