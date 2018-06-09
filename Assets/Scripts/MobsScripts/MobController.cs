using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MobController : MonoBehaviour {
    private int HP
    {
        get { return GetComponent<MobStats>().HealthPoints; }
        set { GetComponent<MobStats>().HealthPoints = value; }
    }

    private bool Stun
    {
        get { return GetComponent<MobStats>().Stun; }
        set { GetComponent<MobStats>().Stun = value; }
    }

    //Update is called once per frame
    void Update()
    {
        if (HP <= 0) Destroy(GetComponent<Rigidbody2D>());
    }

    public void Attacked(int damage)
    {
        HP -= damage;
        if (HP <= 0) Destroy(gameObject);
    }
    public void Stuned(float time)
    {
        Stun = true;
        Invoke("UnStun", time);
    }
    private void UnStun()
    {
        Stun = false;
    }
}
