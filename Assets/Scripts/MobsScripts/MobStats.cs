using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobStats : MonoBehaviour
{
    private decimal attackSpeed;
    private int armor, damage, healthPoints, maxHP;

    private enum Types { Melee, Ranged, Boss }
    private enum Bosses { Imp, Skkub, Wizard }
    [SerializeField]
    private Types Mob;
    [SerializeField]
    private Bosses Boss;
    [SerializeField]
    private int Level;
	[SerializeField]
	private decimal moveSpeed;

    /// <summary>
    /// Zmiana statystyk po uderzeniu w moba
    /// </summary>
    public void HealthPointsDown()
    {
        healthPoints -= 1;
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

    public bool Stun { get; set; }

    // Use this for initialization
    void Start()
    {
        Stun = false;
        switch (Mob)
        {
            case Types.Boss:
                switch (Boss)
                {
                    case Bosses.Imp:
						attackSpeed = 10;
						armor = 8;
						damage = Level * 2;
						healthPoints = Level * 50;
						maxHP = Level * 50;
						break;
                    case Bosses.Skkub:
						attackSpeed = 8;
						armor = 15;
						damage = Level * 2;
						healthPoints = Level * 50;
						maxHP = Level * 50;
						break;
                    case Bosses.Wizard:
						attackSpeed = 10;
						armor = 20;
						damage = Level * 2;
						healthPoints = Level * 50;
						maxHP = Level * 50;
						break;
                    default:
                        break;
                }

                break;
            case Types.Melee:
				attackSpeed = 5;
				armor = 5;
				damage = Level * 2;
				healthPoints = Level * 20;
				maxHP = Level * 20;
                break;

            case Types.Ranged:
				attackSpeed = 5;
				armor = 5;
				damage = Level * 2;
				healthPoints = Level * 20;
				maxHP = Level * 20;
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

