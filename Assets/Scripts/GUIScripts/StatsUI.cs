using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour{
    public List<TextMeshProUGUI> attributes;
    public TextMeshProUGUI statsPointNumber;
    GameObject Player;
    GameObject[] Stats;
    private void Start()
    {
        Player = GameObject.Find("Player");
        Stats = new GameObject[8];
        Stats[0] = GameObject.Find("HPNumber");
        Stats[1] = GameObject.Find("HPRegenNumber");
        Stats[2] = GameObject.Find("EXPNumber");
        Stats[3] = GameObject.Find("DodgeNumber");
        Stats[4] = GameObject.Find("ArmorNumber");
        Stats[5] = GameObject.Find("DmgNumber");
        Stats[6] = GameObject.Find("MSNumber");
        Stats[7] = GameObject.Find("ASNumber");
    }

    private void Update()
    {
        Stats[0].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().HealthPoints.ToString() + "/" + Player.GetComponent<Moving>().MaxHP.ToString();
        Stats[1].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().HealthRegen.ToString();
        Stats[2].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().CurrEXP.ToString() + "/" + Player.GetComponent<Moving>().ExperienceToNextLvl.ToString();
        Stats[3].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Dodge.ToString();
        Stats[4].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Armor.ToString();
        Stats[5].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Damage.ToString();
        Stats[6].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().MoveSpeed.ToString();
        Stats[7].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().AttackSpeed.ToString();
        statsPointNumber.text = Player.GetComponent<Moving>().StatPoints.ToString();
    }

    public void AddNumber(TextMeshProUGUI attr)
    {
        if (Convert.ToInt32(statsPointNumber.text) > 0)
        {
            switch (attributes.IndexOf(attr))
            {
                case 0: //Vit
                    Player.GetComponent<Moving>().VitalityUp();
                    attributes[0].text = Player.GetComponent<Moving>().Vitality.ToString();
                    break;
                case 1: //Agi
                    Player.GetComponent<Moving>().AgilityUp();
                    attributes[1].text = Player.GetComponent<Moving>().Agility.ToString();
                    break;
                case 2: //Str
                    Player.GetComponent<Moving>().StrengthUp();
                    attributes[2].text = Player.GetComponent<Moving>().Strength.ToString();
                    break;
                case 3: //Def
                    Player.GetComponent<Moving>().DefenseUp();
                    attributes[3].text = Player.GetComponent<Moving>().Defense.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
