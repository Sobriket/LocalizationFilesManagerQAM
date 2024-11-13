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
            Data.Columns.Clear();

            // Load the CSV file to which grid data will be imported.  
            using (StreamReader sr = new StreamReader(_filepath))
            {
                string dataReceived;
                int countLine = 0;
                
                while ((dataReceived = sr.ReadLine()) != null)
                {
                    read = dataReceived.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                    if (countLine == 0)
                    {
                        AddNewLangages(read);
                    }
                    else
                    {
                        Data.Rows.Add(read);
                    }

                    countLine++;
                }
            }

            dataGrid.ItemsSource = Data.DefaultView;
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
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<DataLocalization>));
            List<DataLocalization> data;
            using (StreamReader wr = new StreamReader(_filepath))
            {
                data = (List<DataLocalization>)xmlSerializer.Deserialize(wr);
            }

            dataGrid.ItemsSource = data;
        }

        private void LoadCPP(string _filepath)
        {

        }

        private void LoadCS(string _filepath)
        {

        }
    }
}