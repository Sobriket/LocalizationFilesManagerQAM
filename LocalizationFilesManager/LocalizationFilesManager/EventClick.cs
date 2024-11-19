using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        private void MenuItemNewClick(object sender, RoutedEventArgs e)
        {
            ClearData();
            dataGrid.ItemsSource = Data.DefaultView;
        }

        private void MenuItemOpenClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog(); //configure open file dialog box
            dialog.FileName = "Load";
            dialog.Filter = GetExtensionsLoadSave();

            if (dialog.ShowDialog() == true)
            {
                //Get the path of specified file
                string filename = dialog.FileName;
                //Read the contents of the file into a stream
                var fileStream = dialog.OpenFile();

                try
                {
                    switch (Path.GetExtension(dialog.FileName))
                    {
                        case ".csv":
                            m_extensionUsedBefor = 0;
                            LoadCSV(filename);
                            break;
                        case ".xml":
                            m_extensionUsedBefor = 1;
                            LoadXML(filename);
                            break;
                        case ".json":
                            m_extensionUsedBefor = 2;
                            LoadJson(filename);
                            break;
                        default:
                            MessageBox.Show("Extension non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                catch (Exception _e)
                {
                    MessageBox.Show(_e.Message);
                    throw;
                }
            }
        }

        private void MenuItemSaveClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Save"; // Default file name

            dialog.Filter = GetExtensionsLoadSave(); // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;

                switch (Path.GetExtension(dialog.FileName))
                {
                    case ".csv":
                        m_extensionUsedBefor = 0;
                        SaveCSV(filename);
                        break;
                    case ".xml":
                        m_extensionUsedBefor = 1;
                        SaveXML(filename);
                        break;
                    case ".json":
                        m_extensionUsedBefor = 2;
                        SaveJson(filename);
                        break;
                    case ".cs":
                        m_extensionUsedBefor = 3;
                        SaveCS(filename);
                        break;
                    case ".hpp":
                        m_extensionUsedBefor = 4;
                        SaveHpp(filename);
                        break;
                    default:
                        MessageBox.Show("Extension non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
        }

        private void MenuItemExportClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Export"; // Default file name

            dialog.Filter = GetExtensionsExport(); // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;

                switch (Path.GetExtension(dialog.FileName))
                {
                    case ".cs":
                        SaveCS(filename);
                        break;
                    case ".hpp":
                        SaveHpp(filename);
                        break;
                    default:
                        MessageBox.Show("Extension non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
        }

        private void MenuItemExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}