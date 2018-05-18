using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipUI : MonoBehaviour
{

    GameObject Player;
    GameObject[] stats;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        stats = new GameObject[1];
        stats[0] = GameObject.Find("GoldValue");
    }

    // Update is called once per frame
    void Update()
    {
        stats[0].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Gold.ToString();

    }
}
