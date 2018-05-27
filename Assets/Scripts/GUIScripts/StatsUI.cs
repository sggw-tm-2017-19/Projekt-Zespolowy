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
    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        statsPointNumber.text = Player.GetComponent<PlayerStats>().StatPoints.ToString();
        attributes[0].text = Player.GetComponent<PlayerStats>().Vitality.ToString();
        attributes[1].text = Player.GetComponent<PlayerStats>().Agility.ToString();
        attributes[2].text = Player.GetComponent<PlayerStats>().Strength.ToString();
        attributes[3].text = Player.GetComponent<PlayerStats>().Defense.ToString();
        attributes[4].text = Player.GetComponent<PlayerStats>().HealthPoints.ToString() + "/" + Player.GetComponent<PlayerStats>().MaxHP.ToString();
        attributes[5].text = Player.GetComponent<PlayerStats>().HealthRegen.ToString();
        attributes[6].text = Player.GetComponent<PlayerStats>().MoveSpeed.ToString();
        attributes[7].text = Math.Round((1 / Player.GetComponent<PlayerStats>().AttackSpeed), 3).ToString();
        attributes[8].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerStats>().CurrEXP.ToString() + "/" + Player.GetComponent<PlayerStats>().ExperienceToNextLvl.ToString();
        attributes[9].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerStats>().Dodge.ToString() + "%";
        attributes[10].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerStats>().Armor.ToString();
        attributes[11].GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerStats>().Damage.ToString();
    }

    public void AddNumber(TextMeshProUGUI attr)
    {
        if (Convert.ToInt32(statsPointNumber.text) > 0)
        {
            switch (attributes.IndexOf(attr))
            {
                case 0: //Vit
                    Player.GetComponent<PlayerStats>().VitalityUp();
                    break;
                case 1: //Agi
                    Player.GetComponent<PlayerStats>().AgilityUp();
                    break;
                case 2: //Str
                    Player.GetComponent<PlayerStats>().StrengthUp();
                    break;
                case 3: //Def
                    Player.GetComponent<PlayerStats>().DefenseUp();
                    break;
                default:
                    break;
            }
        }
    }
}
