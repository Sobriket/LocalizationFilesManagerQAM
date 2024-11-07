using System.Windows;
using System.IO;
using System.Text.Json;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        private void LoadCSV(string _filepath)
        {
            string[] read;
            char seperators = ';';

            List<DataLocalization> Data = new List<DataLocalization>();
            // Load the CSV file to which grid data will be imported.  
            using (StreamReader sr = new StreamReader(_filepath))
            {
                string data;

                while ((data = sr.ReadLine()) != null)
                {
                    read = data.Split(seperators, StringSplitOptions.None);
                    DataLocalization dataLocalization = new DataLocalization();
                    dataLocalization.ID = read[0];
                    dataLocalization.EN = read[1];
                    dataLocalization.FR = read[2];
                    dataLocalization.ES = read[3];
                    Data.Add(dataLocalization);
                }
            }
            dataGrid.ItemsSource = Data;
        }

        private void LoadJson(string _filepath)
        {
            List<DataLocalization> Data = new List<DataLocalization>();

            string jsonString = File.ReadAllText(_filepath);
            Data = JsonSerializer.Deserialize<List<DataLocalization>>(jsonString);

            dataGrid.ItemsSource = Data;
        }

        private void LoadXML(string _filepath)
        {

        }

        private void LoadCPP(string _filepath)
        {

        }

        private void LoadCS(string _filepath)
        {

        }
    }
}