using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonReader : MonoBehaviour
{
    [SerializeField] string id;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Import.GetText(id);
    }
}
