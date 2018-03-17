using Microsoft.Win32;
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

namespace MiniNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("Starting app");
            InitializeComponent();
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    tbDocument.Text = File.ReadAllText(openFileDialog.FileName);
                    tbStatus.Text = openFileDialog.FileName;
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error opening file: " + ex.Message, "File open error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
                
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = tbStatus.Text;
            try
            {
                File.WriteAllText(saveFileDialog.FileName, tbDocument.Text);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error saving file: " + ex.Message, "File saving error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, tbDocument.Text);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error saving file: " + ex.Message, "File saving error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
