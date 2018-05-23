using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public GlobalControl globalControl;
    public bool HPEqualsMaxHP = true;
    
    private bool isDead = false;

    public float HP {
        get { return globalControl.healthPoints; }
        set { globalControl.healthPoints = value; } }
    private float MaxHP { get { return globalControl.maxHP; } }
    private float Armor { get { return globalControl.armor; } }
    private float Regeneration { get { return globalControl.healthRegen; } }




    // Use this for initialization
    void Start ()
    {
        if (HPEqualsMaxHP) HP = MaxHP;
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
        float finalDamage = damage > Armor ? damage - Armor : 0;
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
