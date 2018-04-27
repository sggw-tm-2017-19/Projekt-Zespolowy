using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour{
    public List<TextMeshProUGUI> attributes;
    public void AddNumber(TextMeshProUGUI attr)
    {
        int value = Convert.ToInt32(attr.text);
        value++;
        attributes[attributes.IndexOf(attr)].text = value.ToString();
    }
    public void SubtractNumber(TextMeshProUGUI attr)
    {
        int value = Convert.ToInt32(attr.text);
        if(value > 0)
            value--;
        attributes[attributes.IndexOf(attr)].text = value.ToString();
    }
}
