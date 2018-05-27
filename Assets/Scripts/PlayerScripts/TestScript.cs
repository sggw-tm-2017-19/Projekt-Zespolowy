using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    GameObject Player;
    public Button btn;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        btn.onClick.AddListener(DoTask);
    }
    void DoTask()
    {
        Player.GetComponent<PlayerStats>().Gold += 500;
        Player.GetComponent<PlayerStats>().HealthPoints -= 100;
        Player.GetComponent<PlayerStats>().CurrEXP += 100;
    }
}
