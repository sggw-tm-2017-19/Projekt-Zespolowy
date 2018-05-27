using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipUI : MonoBehaviour
{

    public List<Text> eq;
    public TextMeshProUGUI gold;
    GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        eq[0].text = Player.GetComponent<PlayerStats>().Helmet.ToString();
        eq[1].text = Player.GetComponent<PlayerStats>().Pauldrons.ToString();
        eq[2].text = Player.GetComponent<PlayerStats>().Breastplate.ToString();
        eq[3].text = Player.GetComponent<PlayerStats>().Belt.ToString();
        eq[4].text = Player.GetComponent<PlayerStats>().RHand.ToString();
        eq[5].text = Player.GetComponent<PlayerStats>().LHand.ToString();
        eq[6].text = Player.GetComponent<PlayerStats>().Boots.ToString();
        gold.text = Player.GetComponent<PlayerStats>().Gold.ToString();
    }
}
