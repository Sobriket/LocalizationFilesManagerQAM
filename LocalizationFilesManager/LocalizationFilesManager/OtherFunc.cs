using System.Windows;

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
    }
}
