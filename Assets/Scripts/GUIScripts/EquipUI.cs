using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipUI : MonoBehaviour
{

    public List<Text> eq;
    public TextMeshProUGUI gold;
    
    // Update is called once per frame
    void Update()
    {
        eq[0].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Helmet.ToString();
        eq[1].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Pauldrons.ToString();
        eq[2].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Breastplate.ToString();
        eq[3].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Belt.ToString();
        eq[4].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().RHand.ToString();
        eq[5].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().LHand.ToString();
        eq[6].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Boots.ToString();
        gold.text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Gold.ToString();
    }
}
