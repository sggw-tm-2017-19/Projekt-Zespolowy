using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public List<TextMeshProUGUI> attributes;
    public TextMeshProUGUI statsPointNumber;

    private void Update()
    {
        statsPointNumber.text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().StatPoints.ToString();
        attributes[0].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Vitality.ToString();
        attributes[1].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Agility.ToString();
        attributes[2].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Strength.ToString();
        attributes[3].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Defense.ToString();
        attributes[4].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().HealthPoints.ToString() + "/" + GlobalControl.Instance.Player.GetComponent<PlayerStats>().MaxHP.ToString();
        attributes[5].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().HealthRegen.ToString();
        attributes[6].text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().MoveSpeed.ToString();
        attributes[7].text = (GlobalControl.Instance.Player.GetComponent<PlayerStats>().AttackSpeed).ToString();
        attributes[8].GetComponent<TextMeshProUGUI>().text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().CurrEXP.ToString() + "/" + GlobalControl.Instance.Player.GetComponent<PlayerStats>().ExperienceToNextLvl.ToString();
        attributes[9].GetComponent<TextMeshProUGUI>().text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Dodge.ToString() + "%";
        attributes[10].GetComponent<TextMeshProUGUI>().text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Armor.ToString();
        attributes[11].GetComponent<TextMeshProUGUI>().text = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Damage.ToString();
    }

    public void AddNumber(TextMeshProUGUI attr)
    {
        if (Convert.ToInt32(statsPointNumber.text) > 0)
        {
            switch (attributes.IndexOf(attr))
            {
                case 0: //Vit
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().VitalityUp();
                    break;
                case 1: //Agi
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().AgilityUp();
                    break;
                case 2: //Str
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().StrengthUp();
                    break;
                case 3: //Def
                    GlobalControl.Instance.Player.GetComponent<PlayerStats>().DefenseUp();
                    break;
                default:
                    break;
            }
        }
    }
}
