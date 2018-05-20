using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    public float gold = 0, posX = 0, posY = 0, posZ = 0, currEXP = 0, experienceToNextLvl = 500, healthPoints = 500, maxHP = 500, level = 1, vitality = 0, agility = 0, strength = 0, defense = 0, damage = 10, armor = 5, dodge = 0, statPoints = 0, healthRegen = 1;
    public decimal moveSpeed = 4, attackSpeed = 1;

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
