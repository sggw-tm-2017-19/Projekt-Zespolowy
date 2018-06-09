using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour {

    public int MaxHP;
    // Use this for initialization
    void Start()
    {
        HealthPoints = MaxHP;
        Stun = false;
    }

    public int HealthPoints { get; set; }

    public bool Stun { get; set; }
}
