using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour{
    public List<TextMeshProUGUI> attributes;
    public TextMeshProUGUI statsPointNumber;
    public void AddNumber(TextMeshProUGUI attr)
    {
        if (Convert.ToInt32(statsPointNumber.text) > 0)
        {
            int number = Convert.ToInt32(statsPointNumber.text);
            int value = Convert.ToInt32(attr.text);
            value++;
            attributes[attributes.IndexOf(attr)].text = value.ToString();
            number -= 1;
            statsPointNumber.text = number.ToString();
        }
    }
}
