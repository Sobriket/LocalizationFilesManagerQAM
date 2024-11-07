using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        private void MenuItemNewClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenClick(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItemSaveClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Export"; // Default file name
            //dialog.DefaultExt = ".csv"; // Default file extension
            dialog.Filter = "CSV |*.csv|XML |*.xml|JSON |*.json|C# |*.cs|CPP |.*cpp"; // Filter files by extension

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
                        SaveCSV(filename);
                        break;
                    default:
                        MessageBox.Show("Extension non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
        }

        private void MenuItemExitClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
