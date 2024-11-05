using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;

namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<DataLocalization> Data = new List<DataLocalization>();
            Data.Add(new DataLocalization() { ID = "START", EN = "Start", FR = "Commencer", ES = "" });
            dataGrid.ItemsSource = Data;
        }

        private void Button_ExportCsv(object sender, RoutedEventArgs e)
        {
            var filepath = "test.csv";
            // Create the CSV file to which grid data will be exported.  
            StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write));

            foreach (DataLocalization item in dataGrid.Items.OfType<DataLocalization>())
            {
                sw.Write(item.ID +";" + item.EN + ";" + item.FR + ";" + item.ES);
                sw.Write(sw.NewLine);
            }
            sw.Close();

            
        }
    }
}
