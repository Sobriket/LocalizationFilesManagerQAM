using System.Data;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        int m_extensionUsedBefor = 0;
        string[] m_extensionsLoadSave =
        {
            "CSV |*.csv",
            "XML |*.xml",
            "JSON |*.json",
        };

        string[] m_extensionsExport =
        {
            "C# |*.cs",
            "hpp |*.hpp"
        };

        private string GetExtensionsExport()
        {
            string allExtensions = "";
            int count = m_extensionsExport.Length - 1;
            for (int i = 0; i < m_extensionsExport.Length; i++)
            {
                allExtensions += m_extensionsExport[i];
                if (count != 0)
                {
                    allExtensions += "|";
                    count--;
                }
            }

            return allExtensions;
        }

        private string GetExtensionsLoadSave()
        {
            string allExtensions = m_extensionsLoadSave[m_extensionUsedBefor] + "|";
            int count = m_extensionsLoadSave.Length - 2;
            for (int i = 0; i < m_extensionsLoadSave.Length; i++)
            {
                if (i == m_extensionUsedBefor) continue;
                allExtensions += m_extensionsLoadSave[i];
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
        }

        private void AddNewLangages(string[] _headers)
        {
            for (int i = 0; i < _headers.Length; i++)
            {
                AddNewLangage(_headers[i]);
            }
        }

        private void ClearData()
        {
            Data.Columns.Clear();
            Data.Rows.Clear();
            Data.Clear();
        }

    }
}
