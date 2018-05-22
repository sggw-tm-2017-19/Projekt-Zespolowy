using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public GlobalControl globalControl;

    private float hp;
    private float armor;
    private float regeneration;
    private float maxHP;

    private bool isDead = false;

    public float HP
    {
        get { return hp; }

        set { hp = value; }
    }




    // Use this for initialization
    void Start () {
        maxHP = globalControl.maxHP;
        HP = maxHP;
        armor = globalControl.armor;
        regeneration = globalControl.healthRegen;
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Zadaj obrażenia postaci i sprawdź czy jest martwa.
    /// </summary>
    /// <param name="damage">Liczba punktów obrażeń</param>
    public void TakeDamage(float damage)
    {
        float finalDamage = damage > armor ? damage - armor : 0;
        HP -= finalDamage;
        if (!isDead && HP <= 0) KillCharacter();

        Debug.Log(HP);
        
    }

    /// <summary>
    /// Co ma się stać kiedy postać zostanie zabita
    /// </summary>
    private void KillCharacter()
    {
        Debug.Log(gameObject.name + " został zabity!");
        transform.Rotate(0, 0, 90);
    }
}
