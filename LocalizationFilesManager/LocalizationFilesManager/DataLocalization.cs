using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Serialization;

namespace LocalizationFilesManager
{
    partial class MainWindow : Window
    {
        [XmlRoot("DataLocalization")]
        public class DataLocalization
        {
            public DataLocalization() 
            {
                Data = new List<List<String>>();
            }

            public List<List<String>> Data { get; set; }
        }
    }
}
