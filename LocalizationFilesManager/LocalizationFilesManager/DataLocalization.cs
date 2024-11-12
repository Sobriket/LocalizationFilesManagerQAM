using System.Collections.ObjectModel;
using System.Windows;

namespace LocalizationFilesManager
{
    partial class MainWindow : Window
    {
        public class DataLocalization //: ObservableCollection<String>
        {
            public DataLocalization() 
            {
                strings = new();
            }

            public Dictionary<string, string> strings { get; set; }

            //public List<String> strings { get; set; } = new List<String>();

            //public List<Langage> LANGAGES { get; set; } = new List<string>();
        }
    }
}
