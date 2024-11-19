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
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            for (int i = 0; i < Data.Rows.Count; i++)
            {
                data.Add(new Dictionary<string, string>());
                for (int j = 0; j < Data.Columns.Count; j++)
                {
                    data[i].Add(Data.Columns[j].ColumnName, Data.Rows[i].ItemArray[j].ToString());
                }
            }

            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(_filepath, jsonString);
        }

        private void SaveXML(string _filepath)
        {

            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(DataLocalization));
            using (StreamWriter wr = new StreamWriter(_filepath))
            {

                DataLocalization data = new DataLocalization();

                for (int j = 0; j < Data.Columns.Count; j++)
                {
                    data.Data.Add(new List<string>());
                    data.Data[j].Add(Data.Columns[j].ColumnName);

                    for (int i = 0; i < Data.Rows.Count; i++)
                    {
                        data.Data[j].Add(Data.Rows[i].ItemArray[j].ToString());
                    }
                }

                xmlSerializer.Serialize(wr, data);
            }
        }

        private void SaveCPP(string _filepath)
        {

            string filePathCpp = _filepath.Remove(_filepath.Length - 1) + "cpp";

            StreamWriter sw = new StreamWriter(new FileStream(_filepath, FileMode.Create, FileAccess.Write));

            sw.Write("#ifndef LOCALIZATION_FILES_MANAGER_H\r\n\r\n#define LOCALIZATION_FILES_MANAGER_H\r\n#include <map>\r\n#include <string>\r\n\r\nnamespace LocalizationFilesManager\r\n{\r\n    enum class Langage\r\n    {\n");

            for (int i = 1; i < Data.Columns.Count; i++)
            {
                sw.WriteLine(dataGrid.Columns[i].Header + ",");
            }

            sw.Write("COUNT\r\n    };\r\n\r\n    class Data\r\n    {\r\n    public:\r\n        Data();\r\n        std::map<std::string, std::string>* m_files;\r\n    };\r\n\t\r\n}\r\n\r\n#endif // !LOCALIZATION_FILES_MANAGER_H");
            sw.Close();

            sw = new StreamWriter(new FileStream(filePathCpp, FileMode.Create, FileAccess.Write));

            sw.Write("#include \"" + Path.GetFileName(_filepath) + "\"\r\n\r\nusing namespace LocalizationFilesManager;\r\n\r\nLocalizationFilesManager::Data::Data()\r\n{\r\n\tm_files = new std::map<std::string, std::string>[(unsigned short)Langage::COUNT];\r\n");

            for (int i = 1; i < Data.Columns.Count; i++)
            {
                for (int j = 1; j < Data.Rows.Count; j++)
                {
                    sw.Write("m_files[(unsigned short)Langage::" + dataGrid.Columns[i].Header + "][\"" + Data.Rows[j].ItemArray[0].ToString() + "\"] = \"" + Data.Rows[j].ItemArray[i].ToString() + "\";\n");
                }
            }

            sw.Write("}");

            sw.Close();
        }

        private void SaveCS(string _filepath)
        {
            StreamWriter sw = new StreamWriter(new FileStream(_filepath, FileMode.Create, FileAccess.Write));

            sw.Write("namespace LocalizationFilesManager\n{\nenum Langage\n{\n");

            for (int i = 1; i < Data.Columns.Count; i++)
            {
                sw.WriteLine(dataGrid.Columns[i].Header + ",");
            }

            sw.Write("COUNT\n};\npublic class Data\n{\npublic static Dictionary<String,String>[] files = new Dictionary<String,String>[(ushort)Langage.COUNT];\n");
            sw.Write("public static void Init()\n{\nfor (int i = 0; i < (ushort)Langage.COUNT; i++)\r\n            {\r\n                files[i] = new Dictionary<string, string>();\r\n            }");

            for (int u = 1; u < dataGrid.Columns.Count; u++)
            {
                for (int j = 1; j < Data.Rows.Count; j++)
                {
                    sw.Write("files[(ushort)Langage." + dataGrid.Columns[u].Header + "].Add(\"" + Data.Rows[j].ItemArray[0].ToString() + "\",\"" + Data.Rows[j].ItemArray[u].ToString() + "\");\n");
                }
            }

            sw.Write("\n}\n}\n}");
            sw.Close();
        }
    }
}