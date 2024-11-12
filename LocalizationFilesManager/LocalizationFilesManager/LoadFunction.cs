﻿using System.Windows;
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
                    //dataLocalization.strings[0] = read[0];
                    int count = 1;
                    while (read[count+1] != null)
                    {
                        //dataLocalization.strings[count] = (read[count+1]);
                        count++;
                    }
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