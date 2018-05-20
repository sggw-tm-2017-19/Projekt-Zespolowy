using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public List<TextMeshProUGUI> attributes;
    public TextMeshProUGUI statsPointNumber;
    GameObject Player;
    GameObject[] stats;
    private void Start()
    {
        Player = GameObject.Find("Player");
        stats = new GameObject[8];
        stats[0] = GameObject.Find("HPNumber");
        stats[1] = GameObject.Find("HPRegenNumber");
        stats[2] = GameObject.Find("EXPNumber");
        stats[3] = GameObject.Find("DodgeNumber");
        stats[4] = GameObject.Find("ArmorNumber");
        stats[5] = GameObject.Find("DmgNumber");
        stats[6] = GameObject.Find("MSNumber");
        stats[7] = GameObject.Find("ASNumber");
    }

    private void Update()
    {
        stats[0].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().HealthPoints.ToString() + "/" + Player.GetComponent<Moving>().MaxHP.ToString();
        stats[1].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().HealthRegen.ToString();
        stats[2].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().CurrEXP.ToString() + "/" + Player.GetComponent<Moving>().ExperienceToNextLvl.ToString();
        stats[3].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Dodge.ToString() + "%";
        stats[4].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Armor.ToString();
        stats[5].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().Damage.ToString();
        stats[6].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Moving>().MoveSpeed.ToString();
        stats[7].GetComponent<TextMeshProUGUI>().text = Math.Round((1 / Player.GetComponent<Moving>().AttackSpeed), 3).ToString();
        statsPointNumber.text = Player.GetComponent<Moving>().StatPoints.ToString();
        attributes[0].text = Player.GetComponent<Moving>().Vitality.ToString();
        attributes[1].text = Player.GetComponent<Moving>().Agility.ToString();
        attributes[2].text = Player.GetComponent<Moving>().Strength.ToString();
        attributes[3].text = Player.GetComponent<Moving>().Defense.ToString();
    }

    public void AddNumber(TextMeshProUGUI attr)
    {
        if (Convert.ToInt32(statsPointNumber.text) > 0)
        {
            switch (attributes.IndexOf(attr))
            {
                case 0: //Vit
                    Player.GetComponent<Moving>().VitalityUp();
                    break;
                case 1: //Agi
                    Player.GetComponent<Moving>().AgilityUp();
                    break;
                case 2: //Str
                    Player.GetComponent<Moving>().StrengthUp();
                    break;
                case 3: //Def
                    Player.GetComponent<Moving>().DefenseUp();
                    break;
                default:
                    break;
            }
        }
    }
}
