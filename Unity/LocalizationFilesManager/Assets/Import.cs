using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Xml;
using System;
using System.Xml.Serialization;


public class Import : MonoBehaviour
{
    [SerializeField] string path;

    static List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    static List<string> languages = new List<string>();
    static string language = "en";

    [XmlRoot("DataLocalization")]
    public class DataLocalization
    {
        public DataLocalization()
        {
            Data = new List<List<String>>();
        }

        public List<List<String>> Data { get; set; }
    }

    private void Start()
    {
       // LoadJson(path);
        LoadXML(path);
    }

    private void LoadJson(string _filepath)
    {
        data.Clear();
        string jsonString = File.ReadAllText(_filepath);
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);



        if (data == null || data.Count == 0)
        {
            return;
        }

        foreach (var dic in data[0])
        {
            languages.Add(dic.Key);
        }

        languages = languages.GetRange(1, languages.Count - 1);

        CultureInfo culture = Thread.CurrentThread.CurrentCulture;

        int cultureID = 0;
        Debug.Log(culture);
        //if(culture == CultureTypes.)
    }

    private void LoadXML(string _filepath)
    {
        data.Clear();
        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(DataLocalization));
        DataLocalization localizationData;
        using (StreamReader wr = new StreamReader(_filepath))
        {
            localizationData = (DataLocalization)xmlSerializer.Deserialize(wr);

            for(int i =1; i < localizationData.Data[0].Count; i++)
            {
                Dictionary<string,string> tempDictionary = new Dictionary<string,string>();
                for (int j = 0; j < localizationData.Data.Count; j++)
                {
                     tempDictionary.Add(localizationData.Data[j][0], localizationData.Data[j][i]);
                }
                data.Add(tempDictionary);
            }

           // for (int i = 0; i < localizationData.Data.Count; i++)
           // {
           //     AddNewLangage(localizationData.Data[i][0]);
           // }

           // for (int i = 0; i < localizationData.Data[0].Count; i++)
           // {
           //
           //     string[] read = new string[localizationData.Data.Count];
           //
           //     for (int j = 0; j < localizationData.Data.Count; j++)
           //     {
           //         read[j] = localizationData.Data[j][i];
           //     }
           //
           //     Data.Rows.Add(read);
           // }

        }

       // dataGrid.ItemsSource = Data.DefaultView;
    }

    public static string GetText(string id)
    {
        CultureInfo culture = CultureInfo.GetCultureInfo(language);

        int languageID = 0;
        for(int i =0; i < languages.Count;i++)
        {
            if (CultureInfo.GetCultureInfo(languages[i].ToLower()) == culture)
            {
                languageID = i; 
                break;
            }
        }

        int idx = -1;
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].First().Value == id)
            {
                idx = i;
            }
        }
        if (idx == -1)
        {
            return "Text Not Found";
        }

        return data[idx][languages[languageID]];
    }


    public void SetLanguage(string _language)
    {
        language = _language;
    }
}
