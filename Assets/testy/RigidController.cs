using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidController : MonoBehaviour {
    public float MaxHP;

    private float hp;
    private bool isDead = false;

    public float HP
    {
        get { return hp; }

        set { hp = value; }
    }




    // Use this for initialization
    void Start () {
       HP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (!isDead && HP <= 0)
        {
            transform.Rotate(new Vector3(0, 0, 90));
            isDead = true;
        }
    }
}
