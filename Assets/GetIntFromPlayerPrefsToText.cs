using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIntFromPlayerPrefsToText : MonoBehaviour
{
    [SerializeField] private string pref;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt(pref, 0).ToString();
    }
}
