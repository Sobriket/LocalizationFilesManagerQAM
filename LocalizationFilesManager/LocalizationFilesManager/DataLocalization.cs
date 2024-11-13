using System.Collections.ObjectModel;
using System.Windows;

namespace LocalizationFilesManager
{
    partial class MainWindow : Window
    {
        public class DataLocalization
        {
            public DataLocalization() 
            {
                strings = new Dictionary<string, string>();
            }

            public Dictionary<string, string> strings { get; set; }
        }
    }
}
