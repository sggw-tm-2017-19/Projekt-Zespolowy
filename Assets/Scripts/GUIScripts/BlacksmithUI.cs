using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithUI : MonoBehaviour {

    public List<Text> upgrades;

    // Update is called once per frame
    void Update()
    {
        upgrades[0].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().Helmet - 1) * 100).ToString();
        upgrades[1].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().Pauldrons - 1) * 100).ToString();
        upgrades[2].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().Breastplate - 1) * 100).ToString();
        upgrades[3].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().Belt - 1) * 100).ToString();
        upgrades[4].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().RHand - 1) * 100).ToString();
        upgrades[5].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().LHand - 1) * 100).ToString();
        upgrades[6].text = Convert.ToInt32(Math.Pow(2, GlobalControl.Instance.Player.GetComponent<PlayerStats>().Boots - 1) * 100).ToString();
    }
    public void AddLvl(Text item)
    {
        if (Convert.ToInt32(item.text) <= GlobalControl.Instance.Player.GetComponent<PlayerStats>().Gold)
        {
            switch (upgrades.IndexOf(item))
            {
                case 0: //Helmet
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().HelmetUp();
                    break;
                case 1: //Pauldron
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().PauldronsUp();
                    break;
                case 2: //Breastplate
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().BreastplateUp();
                    break;
                case 3: //Belt
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().BeltUp();
                    break;
                case 4: //RHand
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().RHandUp();
                    break;
                case 5: //LHand
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().LHandUp();
                    break;
                case 6: //Boots
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().BootsUp();
                    break;
                default:
                    break;
            }
        }
    }
}
