using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {
    
    private int HP {
        get { return GetComponent<PlayerStats>().HealthPoints; }
        set { GetComponent<PlayerStats>().HealthPoints = value; } }
    private int Armor { get { return GetComponent<PlayerStats>().Armor; } }

    public void Update()
    {
        if (HP <= 0)
        {
            KillCharacter();
        }
    }

    /// <summary>
    /// Zadaj obrażenia postaci i sprawdź czy jest martwa.
    /// </summary>
    /// <param name="damage">Liczba punktów obrażeń</param>
    public void TakeDamage(int damage)
    {
        int finalDamage = damage > Armor ? damage - Armor : 0;
        HP -= finalDamage;
    }

    /// <summary>
    /// Co ma się stać kiedy postać zostanie zabita
    /// </summary>
    private void KillCharacter()
    {
        GetComponent<PlayerStats>().CurrEXP -= GetComponent<PlayerStats>().ExperienceToNextLvl / 4;
        if(GetComponent<PlayerStats>().CurrEXP<0)
        {
            GetComponent<PlayerStats>().CurrEXP = 0;
        }
        GetComponent<PlayerStats>().Gold = GetComponent<PlayerStats>().Gold / 5 * 4;
        HP = GetComponent<PlayerStats>().MaxHP;
        GetComponent<PlayerStats>().SaveState();
        SceneManager.LoadScene(GlobalControl.Instance.previousVisitedCity);
    }
}
