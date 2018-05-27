using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelScript : MonoBehaviour {
    public Image currHealth;
    public Image currExp;
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {
        currHealth.fillAmount = (float)Player.GetComponent<PlayerStats>().HealthPoints/Player.GetComponent<PlayerStats>().MaxHP;
        currExp.fillAmount = (float)Player.GetComponent<PlayerStats>().CurrEXP / Player.GetComponent<PlayerStats>().ExperienceToNextLvl;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
