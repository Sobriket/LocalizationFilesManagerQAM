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
    }
}
