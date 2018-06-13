using UnityEngine;
using System.Collections;

public class MobsStats : MonoBehaviour
{
	private decimal moveSpeed, attackSpeed;
	private int armor, damage, healthPoints, maxHP;

	private enum Types { Melee, Ranged, Boss }
	private enum Bosses { Imp, Skkub, Wizard }
	[SerializeField]
	private Types Mob;
	[SerializeField]
	private Bosses Boss;
	[SerializeField]
	private int Level;

	/// <summary>
	/// Zmiana statystyk po uderzeniu w moba
	/// </summary>
	public void HealthPointsDown()
	{
		healthPoints -= 25;
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

	// Use this for initialization
	void Start ()
	{
		switch (Mob) {
		case Types.Boss:
			switch (Boss) {
			case Bosses.Imp:
				Level = 8;
				moveSpeed = 10;
				attackSpeed = 10;
				armor = 8;
				damage = Level * 2;
				healthPoints = Level * 50;
				maxHP = Level * 50;
				break;
			case Bosses.Skkub:
				Level = 12;
				moveSpeed = 8;
				attackSpeed = 8;
				armor = 15;
				damage = Level * 2;
				healthPoints = Level * 50;
				maxHP = Level * 50;
				break;
			case Bosses.Wizard:
				Level = 20;
				moveSpeed = 5;
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
			Level = 5;
			moveSpeed = 15;
			attackSpeed = 5;
			armor = 5;
			damage = Level * 2;
			healthPoints = Level * 20;
			maxHP = Level * 20;
			break;

		case Types.Ranged:
			Level = 4;
			moveSpeed = 15;
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
	void Update ()
	{
	
	}
}

