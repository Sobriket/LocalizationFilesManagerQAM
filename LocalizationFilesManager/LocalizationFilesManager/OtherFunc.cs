using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        int m_extensionUsedBefor = 0;
        string[] m_extensions =
        {
            "CSV |*.csv",
            "XML |*.xml",
            "JSON |*.json",
            "C# |*.cs",
            "CPP |.*cpp"
        };

        private string GetExtensions()
        {
            string allExtensions = m_extensions[m_extensionUsedBefor] + "|";
            int count = m_extensions.Length - 2;
            for (int i = 0; i < m_extensions.Length; i++)
            {
                if (i == m_extensionUsedBefor) continue;
                allExtensions += m_extensions[i];
                if (count != 0)
                {
                    allExtensions += "|";
                    count--;
                }
            }

            return allExtensions;
        }

        private void AddNewLangage(string _header)
        {
            string header = _header.ToUpper();

            Data.Columns.Add(header);
            dataGrid.ItemsSource = Data.AsDataView();

            /*
             * 
             * nik
            foreach (DataLocalization item in dataGrid.Items.OfType<DataLocalization>())
            {
                item.strings.Add(header);
            } 
             
            DataGridTextColumn newColumn = new DataGridTextColumn();
            newColumn.Header = header;
            newColumn.MinWidth = 160;
            //newColumn.Binding = new Binding($"[{header}]");
           
           // newColumn.ClipboardContentBinding = new Binding(header);

            dataGrid.Columns.Add(newColumn);
            // dataGrid.DataContext = newColumn;

            Binding bind = new Binding();

            bind.Source = dataGrid.Columns;
            dataGrid.SetBinding(DataGrid.ItemsSourceProperty, bind);
            */
        }

    }
}
