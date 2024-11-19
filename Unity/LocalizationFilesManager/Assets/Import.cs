using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using System.Linq;


public class Import : MonoBehaviour
{
    [SerializeField] string path;

    static List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    static List<string> languages = new List<string>();
    static string language = "en";

    private void Start()
    {
        LoadJson(path);
    }

    private void LoadJson(string _filepath)
    {
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
