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
        currHealth.fillAmount = Player.GetComponent<Moving>().HealthPoints/Player.GetComponent<Moving>().MaxHP;
        currExp.fillAmount = Player.GetComponent<Moving>().CurrEXP / Player.GetComponent<Moving>().ExperienceToNextLvl;
    }
}
