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

namespace TreeViews
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get entry logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // create new item for it
                var item = new TreeViewItem();
                // set the header and path
                item.Header = drive;
                // full path
                item.Tag = drive;
                // add a dummy item in item
                item.Items.Add(null);
                // listen out for item expanded
                item.Expanded += Folder_Expanded;
                // add it to the main menu
                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            // if the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null) return;
            // clear dummy data
            item.Items.Clear();
            // get full path
            var fullPath = (string)item.Tag;
            // create a blank list for directories
            var directories = new List<string>();
            // try and get directories from the folder
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }
            directories.ForEach(directories.Path => {

            }
        }
    }
}
