using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithUI : MonoBehaviour {

    public List<Text> upgrades;
    GameObject Player;
    int[] levels;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        levels = new int[7];
        levels[0] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().Helmet - 1) * 100);
        levels[1] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().Pauldrons - 1) * 100);
        levels[2] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().Breastplate - 1) * 100);
        levels[3] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().Belt - 1) * 100);
        levels[4] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().RHand - 1) * 100);
        levels[5] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().LHand - 1) * 100);
        levels[6] = Convert.ToInt32(Mathf.Pow(2, Player.GetComponent<PlayerStats>().Boots - 1) * 100);
    }   

    // Update is called once per frame
    void Update()
    {
        upgrades[0].text = levels[0].ToString();
        upgrades[1].text = levels[1].ToString();
        upgrades[2].text = levels[2].ToString();
        upgrades[3].text = levels[3].ToString();
        upgrades[4].text = levels[4].ToString();
        upgrades[5].text = levels[5].ToString();
        upgrades[6].text = levels[6].ToString();
    }
    public void AddLvl(Text item)
    {
        if (Convert.ToInt32(item.text) <= Player.GetComponent<PlayerStats>().Gold)
        {
            switch (upgrades.IndexOf(item))
            {
                case 0: //Helmet
                    Player.GetComponent<PlayerStats>().HelmetUp(levels[0]);
                    levels[0] *= 2;
                    break;
                case 1: //Pauldron
                    Player.GetComponent<PlayerStats>().PauldronsUp(levels[1]);
                    levels[1] *= 2;
                    break;
                case 2: //Breastplate
                    Player.GetComponent<PlayerStats>().BreastplateUp(levels[2]);
                    levels[2] *= 2;
                    break;
                case 3: //Belt
                    Player.GetComponent<PlayerStats>().BeltUp(levels[3]);
                    levels[3] *= 2;
                    break;
                case 4: //RHand
                    Player.GetComponent<PlayerStats>().RHandUp(levels[4]);
                    levels[4] *= 2;
                    break;
                case 5: //LHand
                    Player.GetComponent<PlayerStats>().LHandUp(levels[5]);
                    levels[5] *= 2;
                    break;
                case 6: //Boots
                    Player.GetComponent<PlayerStats>().BootsUp(levels[6]);
                    levels[6] *= 2;
                    break;
                default:
                    break;
            }
        }
    }
}
