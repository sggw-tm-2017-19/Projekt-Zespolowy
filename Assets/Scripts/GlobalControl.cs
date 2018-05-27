using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    public int gold = 0, currEXP = 0, experienceToNextLvl = 500, healthPoints = 500, maxHP = 500, level = 1, vitality = 0, agility = 0, strength = 0, defense = 0, damage = 10, armor = 5, statPoints = 0, healthRegen = 1, helmet = 1, pauldrons = 1, breastplate = 1, belt = 1, rHand = 1, lHand = 1, boots = 1;
    public float posX = 0, posY = 0, posZ = 0;
    public decimal moveSpeed = 4, attackSpeed = 1, dodge = 0;
    public string previousVisitedCity = "Wioska";

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
