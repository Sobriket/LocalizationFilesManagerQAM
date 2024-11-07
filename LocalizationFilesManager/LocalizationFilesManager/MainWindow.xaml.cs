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
            dataGrid.ItemsSource = Data;
        }
    }
}
