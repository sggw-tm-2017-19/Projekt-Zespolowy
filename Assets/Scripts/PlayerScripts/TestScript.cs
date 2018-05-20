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
        Player.GetComponent<Moving>().Gold += 500;
        Player.GetComponent<Moving>().HealthPoints -= 100;
        Player.GetComponent<Moving>().CurrEXP += 100;
    }
}
