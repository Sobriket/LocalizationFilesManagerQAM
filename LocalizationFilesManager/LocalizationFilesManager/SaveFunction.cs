using System.IO;
using System.Windows;
using System.Text.Json;
using System.Data;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        private void SaveCSV(string _filepath)
        {
            // Create the CSV file to which grid data will be exported.  
            StreamWriter sw = new StreamWriter(new FileStream(_filepath, FileMode.Create, FileAccess.Write));

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                sw.Write(dataGrid.Columns[i].Header + ";");
            }
            sw.Write(sw.NewLine);


            foreach (DataRow item in Data.Rows)
            {
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    sw.Write(item.ItemArray[i].ToString() + ";");
                }

                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void SaveJson(string _filepath)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 0; i < Data.Rows.Count; i++)
            {
                for (int j = 0; j < Data.Columns.Count;j++)
                {
                    data.Add(Data.Columns[j].ColumnName, Data.Rows[i].ItemArray[j].ToString());
                }
            }

            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(_filepath, jsonString);
        }

        private void SaveXML(string _filepath)
        {

            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Dictionary<string, string>));
            using (StreamWriter wr = new StreamWriter(_filepath))
            {

                Dictionary<string, string> data = new Dictionary<string, string>();

                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    for (int j = 0; j < Data.Columns.Count; j++)
                    {
                        data.Add(Data.Columns[j].ColumnName, Data.Rows[i].ItemArray[j].ToString());
                    }
                }

                xmlSerializer.Serialize(wr, data);
            }
        }

        private void SaveCPP(string _filepath)
        {

        }

        private void SaveCS(string _filepath)
        {
            StreamWriter sw = new StreamWriter(new FileStream(_filepath, FileMode.Create, FileAccess.Write));

            sw.Write("namespace LocalizationFilesManager\n{\nenum Langage\n{\n");

            for (int i = 1; i < dataGrid.Columns.Count; i++)
            {
                sw.WriteLine(dataGrid.Columns[i].Header);
            }

            sw.Write("COUNT\n};\npublic class Data\n{\npublic static Dictionary<String,String>[] files = new Dictionary<String,String>[(ushort)Langage.COUNT];\n");
            sw.Write("public static void Init()\n{\n");

            DataLocalization[] data = dataGrid.Items.OfType<DataLocalization>().ToArray<DataLocalization>();

            for (int j = 0;j < dataGrid.Items.Count;j++)
            {
                for (int i = 1; i < dataGrid.Columns.Count; i++)
                {
                    //sw.Write("files[(ushort)Langage."+dataGrid.Columns[i]+ "].Add(\"" + data[j].strings[0] + "\",\"" + data[j].strings[i] + "\");\n");
                }
            }

            sw.Write("\n}\n}\n}");

            sw.Close();
        }
    }
}