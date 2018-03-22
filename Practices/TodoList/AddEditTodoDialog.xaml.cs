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

namespace TodoList
{
    /// <summary>
    /// Interaction logic for AddEditTodoDialog.xaml
    /// </summary>
    public partial class AddEditTodoDialog : Window
    {
        private Todo currentItem;
        public AddEditTodoDialog(Todo item)
        {
            currentItem = item;
            InitializeComponent();
            if (currentItem == null)
            {
                btnSave.Content = "Add new Todo";
            }
            else
            {
                lblId.Content = item.Id + "";
                tbTask.Text = item.Task;
                dtpkDueDate.SelectedDate = item.DueDate;
                ckbxDone.IsChecked = item.IsDone;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Todo todo = currentItem == null ? new Todo() : currentItem;
            todo.Task = tbTask.Text;
            todo.DueDate = (DateTime) dtpkDueDate.SelectedDate;
            todo.IsDone = (bool) ckbxDone.IsChecked;
            if (currentItem == null)
            {
                Global.db.AddTodo(todo);
            }
            else
            {
                Global.db.UpdateTodo(todo);
            }
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }      
    }
}
