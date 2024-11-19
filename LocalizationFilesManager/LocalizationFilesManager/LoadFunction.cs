using System.Windows;
using System.IO;
using System.Text.Json;
using System.Data;

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
            string jsonString = File.ReadAllText(_filepath);
            List<Dictionary<string,string>> data = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);
            
            if (data == null || data.Count == 0)
            {
                return;
            }

            Data.Columns.Clear();
            Data.Rows.Clear();
            foreach (KeyValuePair<string,string> item in data[0])
            {
                AddNewLangage(item.Key);
            }

            for (int i = 0; i < data.Count; i++)
            {
                string[] read = new string[data[i].Count];
                int index = 0;
                //DataRow newRow = new DataRow(Data[i])

                foreach (KeyValuePair<string,string> item in data[i])
                {
                    read[index] = item.Value;
                    index++;
                }
                Data.Rows.Add(read);
            }

            dataGrid.ItemsSource = Data.DefaultView;
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