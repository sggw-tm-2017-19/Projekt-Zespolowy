using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Button btn;
    // Use this for initialization
    void Start()
    {
        btn.onClick.AddListener(DoTask);
    }
    void DoTask()
    {
        GlobalControl.Instance.Player.GetComponent<PlayerStats>().Gold += 500;
        GlobalControl.Instance.Player.GetComponent<PlayerStats>().HealthPoints -= 100;
        GlobalControl.Instance.Player.GetComponent<PlayerStats>().CurrEXP += 100;
    }
}
