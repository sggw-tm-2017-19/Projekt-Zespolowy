using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelScript : MonoBehaviour {
    public Image currHealth;
    public Image currExp;
    // Update is called once per frame
    void Update () {
        currHealth.fillAmount = (float)GlobalControl.Instance.Player.GetComponent<PlayerStats>().HealthPoints/ GlobalControl.Instance.Player.GetComponent<PlayerStats>().MaxHP;
        currExp.fillAmount = (float)GlobalControl.Instance.Player.GetComponent<PlayerStats>().CurrEXP / GlobalControl.Instance.Player.GetComponent<PlayerStats>().ExperienceToNextLvl;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
