﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MobStats : MonoBehaviour
{
    private decimal attackSpeed;
	private int armor, damage, healthPoints, maxHP;

    private enum Types { Melee, Ranged, Boss }
    private enum Bosses { Mob, Imp, Sukkub, Wizard }
    [SerializeField]
    private Types Mob;
    [SerializeField]
    private Bosses Boss;
    [SerializeField]
    private int level;
	[SerializeField]
	private decimal moveSpeed;
	[SerializeField]
	private int gold;
	[SerializeField]
	private int exp;
    [SerializeField]
    private bool unique;

    /// <summary>
    /// Zmiana statystyk po uderzeniu w moba
    /// </summary>
    public void HealthPointsDown(int takeDamage)
    {
        healthPoints -= Convert.ToInt32(takeDamage/Mathf.Sqrt(Armor));
        if(healthPoints<=0)
        {
            if(unique==true)
            {
                if(Boss==Bosses.Imp)
                {
                    GlobalControl.Instance.straznikl = 10;
                    GlobalControl.Instance.starszy = 10;
                }
                if(Boss ==Bosses.Sukkub)
                {
                    GlobalControl.Instance.straznike = 10;
                    GlobalControl.Instance.krolowa = 10;
                }
                if(Boss==Bosses.Wizard)
                {
                    GlobalControl.Instance.straznikl = 20;
                    GlobalControl.Instance.straznike = 20;
                    GlobalControl.Instance.starszy = 20;
                    GlobalControl.Instance.krolowa = 20;
                }
            }
            GlobalControl.Instance.Player.GetComponent<PlayerStats>().Gold += gold;
            GlobalControl.Instance.Player.GetComponent<PlayerStats>().CurrEXP += exp;
            Destroy(gameObject);
        }
    }

    public void GetStun(float time)
    {
        Stun = true;
        Invoke("UnStun", time);
    }

    public void UnStun()
    {
        Stun = false;
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

	public int Exp
	{
		get
		{
			return exp;
		}
		set
		{
			exp = value;
		}
	}

    public bool Stun { get; set; }

    // Use this for initialization
    void Start()
    {
        if(unique==true)
        {
            if (Boss == Bosses.Imp&& GlobalControl.Instance.starszy >= 10)
            {
                Destroy(gameObject);
            }
            if (Boss == Bosses.Sukkub&& GlobalControl.Instance.krolowa >= 10)
            {
                Destroy(gameObject);
            }
            if (Boss == Bosses.Wizard&& GlobalControl.Instance.krolowa >= 20)
            {
                Destroy(gameObject);
            }
        }
        Stun = false;
        switch (Mob)
        {
            case Types.Boss:
                switch (Boss)
                {
                    case Bosses.Imp:
						AttackSpeed = 10;
						Armor = 8;
						Damage = Level * 2;
						HealthPoints = Level * 50;
						MaxHP = Level * 50;
						break;
                    case Bosses.Sukkub:
						AttackSpeed = 8;
						Armor = 15;
						Damage = Level * 2;
						HealthPoints = Level * 50;
						MaxHP = Level * 50;
						break;
                    case Bosses.Wizard:
						AttackSpeed = 10;
						Armor = 20;
						Damage = Level * 2;
						HealthPoints = Level * 50;
						MaxHP = Level * 50;
						break;
                    default:
                        break;
                }

                break;
            case Types.Melee:
				AttackSpeed = 5;
				Armor = 5;
				Damage = Level * 2;
				HealthPoints = Level * 20;
				MaxHP = Level * 20;
                break;

            case Types.Ranged:
				AttackSpeed = 5;
				Armor = 5;
				Damage = Convert.ToInt16(Level * 2.2);
				HealthPoints = Level * 15;
				MaxHP = Level * 15;
				break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

