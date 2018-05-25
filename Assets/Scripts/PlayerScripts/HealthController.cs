using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {
    
    private float HP {
        get { return GetComponent<Moving>().HealthPoints; }
        set { GetComponent<Moving>().HealthPoints = value; } }
    private float Armor { get { return GetComponent<Moving>().Armor; } }

    public void Update()
    {
        if (HP <= 0) KillCharacter();
    }

    /// <summary>
    /// Zadaj obrażenia postaci i sprawdź czy jest martwa.
    /// </summary>
    /// <param name="damage">Liczba punktów obrażeń</param>
    public void TakeDamage(float damage)
    {
        float finalDamage = damage > Armor ? damage - Armor : 0;
        HP -= finalDamage;
    }

    /// <summary>
    /// Co ma się stać kiedy postać zostanie zabita
    /// </summary>
    private void KillCharacter()
    {
        HP = GetComponent<Moving>().MaxHP;
        GetComponent<Moving>().SaveState();
        SceneManager.LoadScene(GlobalControl.Instance.previousVisitedCity);
    }
}
