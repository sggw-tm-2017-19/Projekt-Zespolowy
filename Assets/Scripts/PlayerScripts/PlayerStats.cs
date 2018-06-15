using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerStats : MonoBehaviour {

    int gold, currEXP, experienceToNextLvl, healthPoints, maxHP, level, vitality, agility, strength, defense, damage, armor, statPoints, healthRegen, helmet, pauldrons, breastplate, belt, rHand, lHand, boots;
    decimal moveSpeed, attackSpeed, dodge;
    // Use this for initialization
    void Start ()
    {
        LoadState();
        Thread HPRegen = new Thread(RegenerateHealth);
        HPRegen.Start();

    }

    // Update is called once per frame
    void Update()
    {
        //sprawdzanie, czy postać nie wbiła poziomu
        if (currEXP >= experienceToNextLvl)
        {
            currEXP -= experienceToNextLvl;
            LevelUp();
        }

    }

    /// <summary>
    /// Regeneracja życia
    /// </summary>
    public void RegenerateHealth()
    {
        healthPoints += healthRegen;
        if (healthPoints > maxHP)
        {
            healthPoints = maxHP;
        }
        Thread.Sleep(1000);
        RegenerateHealth();
    }

    /// <summary>
    /// Zapisuje statystyki do GlobalControl
    /// </summary>
    public void SaveState()
    {
        GlobalControl.Instance.agility = agility;
        GlobalControl.Instance.armor = armor;
        GlobalControl.Instance.attackSpeed = attackSpeed;
        GlobalControl.Instance.belt = belt;
        GlobalControl.Instance.boots = boots;
        GlobalControl.Instance.breastplate = breastplate;
        GlobalControl.Instance.currEXP = currEXP;
        GlobalControl.Instance.damage = damage;
        GlobalControl.Instance.defense = defense;
        GlobalControl.Instance.dodge = dodge;
        GlobalControl.Instance.experienceToNextLvl = experienceToNextLvl;
        GlobalControl.Instance.gold = gold;
        GlobalControl.Instance.healthPoints = healthPoints;
        GlobalControl.Instance.healthRegen = healthRegen;
        GlobalControl.Instance.helmet = helmet;
        GlobalControl.Instance.level = level;
        GlobalControl.Instance.lHand = lHand;
        GlobalControl.Instance.maxHP = maxHP;
        GlobalControl.Instance.moveSpeed = moveSpeed;
        GlobalControl.Instance.pauldrons = pauldrons;
        GlobalControl.Instance.rHand = rHand;
        GlobalControl.Instance.statPoints = statPoints;
        GlobalControl.Instance.strength = strength;
        GlobalControl.Instance.vitality = vitality;
    }

    /// <summary>
    /// Wczytuje statystyki i położenie z GlobalControl
    /// </summary>
    public void LoadState()
    {
        agility = GlobalControl.Instance.agility;
        armor = GlobalControl.Instance.armor;
        attackSpeed = GlobalControl.Instance.attackSpeed;
        belt = GlobalControl.Instance.belt;
        boots = GlobalControl.Instance.boots;
        breastplate = GlobalControl.Instance.breastplate;
        currEXP = GlobalControl.Instance.currEXP;
        damage = GlobalControl.Instance.damage;
        defense = GlobalControl.Instance.defense;
        dodge = GlobalControl.Instance.dodge;
        experienceToNextLvl = GlobalControl.Instance.experienceToNextLvl;
        gold = GlobalControl.Instance.gold;
        healthPoints = GlobalControl.Instance.healthPoints;
        healthRegen = GlobalControl.Instance.healthRegen;
        helmet = GlobalControl.Instance.helmet;
        level = GlobalControl.Instance.level;
        lHand = GlobalControl.Instance.lHand;
        maxHP = GlobalControl.Instance.maxHP;
        moveSpeed = GlobalControl.Instance.moveSpeed;
        rHand = GlobalControl.Instance.rHand;
        pauldrons = GlobalControl.Instance.pauldrons;
        statPoints = GlobalControl.Instance.statPoints;
        strength = GlobalControl.Instance.strength;
        vitality = GlobalControl.Instance.vitality;
        transform.SetPositionAndRotation(new Vector3(GlobalControl.Instance.posX, GlobalControl.Instance.posY, GlobalControl.Instance.posZ), new Quaternion(0, 0, 0, 0));
    }

    /// <summary>
    /// Zmiana statystyk po wbiciu poziomu
    /// </summary>
    public void LevelUp()
    {
        level += 1;
        moveSpeed += decimal.Parse("0.1");
        maxHP += 10;
        healthPoints += 10;
        statPoints += 1;
        damage += 5;
        armor += 1;
        experienceToNextLvl = Convert.ToInt32(experienceToNextLvl * 3 / 2.0);
    }

    /// <summary>
    /// Zmiana statystyk po dodaniu punkty do Vitality
    /// </summary>
    public void VitalityUp()
    {
        statPoints -= 1;
        vitality += 1;
        maxHP += 50;
        healthPoints += 50;
        healthRegen += 1;
    }

    /// <summary>
    /// Zmiana statystyk po dodaniu punkty do Agility
    /// </summary>
    public void AgilityUp()
    {
        statPoints -= 1;
        agility += 1;
        moveSpeed += decimal.Parse("0.1");
        attackSpeed += decimal.Parse("0.05");
    }

    /// <summary>
    /// Zmiana statystyk po dodaniu punkty do Strength
    /// </summary>
    public void StrengthUp()
    {
        statPoints -= 1;
        strength += 1;
        damage += 10;
    }

    /// <summary>
    /// Zmiana statystyk po dodaniu punkty do Defense
    /// </summary>
    public void DefenseUp()
    {
        statPoints -= 1;
        defense += 1;
        armor += 5;
        dodge += decimal.Parse("0.2");
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu Helmet
    /// </summary>
    public void HelmetUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2,helmet-1)*100);
        helmet++;
        healthRegen += 1;
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu Breastplate
    /// </summary>
    public void BreastplateUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, breastplate - 1) * 100);
        breastplate++;
        armor += 5;
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu Pauldrons
    /// </summary>
    public void PauldronsUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, pauldrons - 1) * 100);
        pauldrons++;
        maxHP += 50;
        healthPoints += 50;
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu Belt
    /// </summary>
    public void BeltUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, belt - 1) * 100);
        belt++;
        dodge += decimal.Parse("0.2");
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu RHand
    /// </summary>
    public void RHandUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, rHand - 1) * 100);
        rHand++;
        damage += 10;
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu LHand
    /// </summary>
    public void LHandUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, lHand - 1) * 100);
        LHand++;
        attackSpeed += decimal.Parse("0.05");
    }

    /// <summary>
    /// Zmiana statystyk po zwiększeniu poziomu Boots
    /// </summary>
    public void BootsUp()
    {
        gold -= Convert.ToInt32(Math.Pow(2, boots - 1) * 100);
        boots++;
        moveSpeed += decimal.Parse("0.1");
    }

    //Getters & Setters
    public decimal MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    public int CurrEXP
    {
        get
        {
            return currEXP;
        }
        set
        {
            currEXP = value;
        }
    }

    public int ExperienceToNextLvl
    {
        get
        {
            return experienceToNextLvl;
        }
        set
        {
            experienceToNextLvl = value;
        }
    }

    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = value;
        }
    }

    public int MaxHP
    {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public int Vitality
    {
        get
        {
            return vitality;
        }
        set
        {
            vitality = value;
        }
    }

    public int Agility
    {
        get
        {
            return agility;
        }
        set
        {
            agility = value;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }
        set
        {
            strength = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }
        set
        {
            defense = value;
        }
    }

    public decimal AttackSpeed
    {
        get
        {
            return attackSpeed;
        }
        set
        {
            attackSpeed = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public int Armor
    {
        get
        {
            return armor;
        }
        set
        {
            armor = value;
        }
    }

    public decimal Dodge
    {
        get
        {
            return dodge;
        }
        set
        {
            dodge = value;
        }
    }

    public int StatPoints
    {
        get
        {
            return statPoints;
        }
        set
        {
            statPoints = value;
        }
    }

    public int HealthRegen
    {
        get
        {
            return healthRegen;
        }
        set
        {
            healthRegen = value;
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }

    public int Helmet
    {
        get
        {
            return helmet;
        }
        set
        {
            helmet = value;
        }
    }

    public int Pauldrons
    {
        get
        {
            return pauldrons;
        }
        set
        {
            pauldrons = value;
        }
    }

    public int Breastplate
    {
        get
        {
            return breastplate;
        }
        set
        {
            breastplate = value;
        }
    }

    public int Belt
    {
        get
        {
            return belt;
        }
        set
        {
            belt = value;
        }
    }

    public int RHand
    {
        get
        {
            return rHand;
        }
        set
        {
            rHand = value;
        }
    }

    public int LHand
    {
        get
        {
            return lHand;
        }
        set
        {
            lHand = value;
        }
    }

    public int Boots
    {
        get
        {
            return boots;
        }
        set
        {
            boots = value;
        }
    }
}
