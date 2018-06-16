using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelScript : MonoBehaviour {
    public Image currHealth;
    public Image currExp;
    public Text lvl;
    public Text skillCd1;
    public Text skillCd2;
    public Text skillCd3;
    public Text skillCd4;
    public Text skillCd5;

    // Update is called once per frame
    void Update () {
        currHealth.fillAmount = (float)GlobalControl.Instance.Player.GetComponent<PlayerStats>().HealthPoints/ GlobalControl.Instance.Player.GetComponent<PlayerStats>().MaxHP;
        currExp.fillAmount = (float)GlobalControl.Instance.Player.GetComponent<PlayerStats>().CurrEXP / GlobalControl.Instance.Player.GetComponent<PlayerStats>().ExperienceToNextLvl;
        lvl.text = "Lvl:" + GlobalControl.Instance.Player.GetComponent<PlayerStats>().Level.ToString();
        if (GlobalControl.Instance.Player.GetComponent<Attacks>().BasicAttackCounter > 0)
        {
            skillCd1.text = GlobalControl.Instance.Player.GetComponent<Attacks>().BasicAttackCounter.ToString();
        }
        else
        {
            skillCd1.text = "";
        }
        if (GlobalControl.Instance.Player.GetComponent<Attacks>().WaveSwordCounter > 0)
        {
            skillCd2.text = GlobalControl.Instance.Player.GetComponent<Attacks>().WaveSwordCounter.ToString();
        }
        else
        {
            skillCd2.text = "";
        }
        if (GlobalControl.Instance.Player.GetComponent<Attacks>().PiercingArrowCounter > 0)
        {
            skillCd3.text = GlobalControl.Instance.Player.GetComponent<Attacks>().PiercingArrowCounter.ToString();
        }
        else
        {
            skillCd3.text = "";
        }
        if (GlobalControl.Instance.Player.GetComponent<Attacks>().DashCounter > 0)
        {
            skillCd4.text = GlobalControl.Instance.Player.GetComponent<Attacks>().DashCounter.ToString();
        }
        else
        {
            skillCd4.text = "";
        }
        if (GlobalControl.Instance.Player.GetComponent<Attacks>().HealCounter > 0)
        {
            skillCd5.text = GlobalControl.Instance.Player.GetComponent<Attacks>().HealCounter.ToString();
        }
        else
        {
            skillCd5.text = "";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
