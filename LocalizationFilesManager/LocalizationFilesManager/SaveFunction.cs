using System.IO;
using System.Windows;
using System.Text.Json;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        private void SaveCSV(string _filepath)
        {
            // Create the CSV file to which grid data will be exported.  
            StreamWriter sw = new StreamWriter(new FileStream(_filepath, FileMode.Create, FileAccess.Write));
            foreach (DataLocalization item in dataGrid.Items.OfType<DataLocalization>())
            {
                sw.Write(item.ID + ";" + item.EN + ";" + item.FR + ";" + item.ES);
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void SaveJson(string _filepath)
        {
            string jsonString = JsonSerializer.Serialize(dataGrid.Items.OfType<DataLocalization>());
            File.WriteAllText(_filepath, jsonString);
        }

        private void SaveXML(string _filepath)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<DataLocalization>));
            using (StreamWriter wr = new StreamWriter(_filepath))
            {
                xmlSerializer.Serialize(wr, dataGrid.Items.OfType<DataLocalization>().ToList<DataLocalization>());
            }
        }

        private void SaveCPP(string _filepath)
        {

        }

        private void SaveCS(string _filepath)
        {

        }
    }
}