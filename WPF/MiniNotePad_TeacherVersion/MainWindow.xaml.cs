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

namespace MiniNotePad_TeacherVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool unsavedChanges = false;
        private string openFilePath = null;

        public MainWindow()
        {
            InitializeComponent();
            updateStatus();
        }

        private void updateStatus()
        {
            Title = (openFilePath == null ? "new file" : System.IO.Path.GetFileName(openFilePath))
                + (unsavedChanges ? " (unsaved changes)" : "");
            lblOpenFilePath.Text = openFilePath == null ? "new file" : openFilePath;
        }

        private void tbContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            unsavedChanges = true;
            updateStatus();
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            if (unsavedChanges)
            {
                MessageBoxResult result = MessageBox.Show("Save unsaved changes?", "Unsaved changes",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        if (openFilePath == null)
                        {
                            MenuFileSaveAs_Click(null, null);
                        }
                        else
                        {
                            MenuFileSave_Click(null, null);
                        }
                        break;
                }
            }
            //
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    openFilePath = openFileDialog.FileName;
                    tbContent.Text = File.ReadAllText(openFilePath);
                    unsavedChanges = false;
                    updateStatus();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(this, "Error reading file " + ex.Message);
            }
        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    // FIXME: make sure we have file extension even if user did not provide it
                    openFilePath = saveFileDialog.FileName;
                    File.WriteAllText(openFilePath, tbContent.Text);
                    unsavedChanges = false;
                    updateStatus();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(this, "Error writing file " + ex.Message);
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
            if (openFilePath == null)
            {
                MenuFileSaveAs_Click(sender, e);
            }
            else
            {
                try
                {
                    File.WriteAllText(openFilePath, tbContent.Text);
                    unsavedChanges = false;
                    updateStatus();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show(this, "Error reading file " + ex.Message);
                }

            }
        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (unsavedChanges)
            {
                MessageBoxResult result = MessageBox.Show("Save unsaved changes?", "Unsaved changes",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.Yes:
                        if (openFilePath == null)
                        {
                            e.Cancel = true;
                            MenuFileSaveAs_Click(null, null);
                        }
                        else
                        {
                            MenuFileSave_Click(null, null);
                        }
                        break;
                }
            }
        }
    }
}
