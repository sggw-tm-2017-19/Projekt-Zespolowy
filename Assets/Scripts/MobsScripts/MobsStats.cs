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

	// Use this for initialization
	void Start ()
	{
		switch (Mob) {
		case Types.Boss:
			switch (Boss) {
			case Bosses.Imp:
				Level = 1;
				moveSpeed = 1;
				attackSpeed = 1;
				armor = 1;
				damage = 1;
				healthPoints = 1;
				maxHP = 1;
				break;
			case Bosses.Skkub:
				Level = 1;
				moveSpeed = 1;
				attackSpeed = 1;
				armor = 1;
				damage = 1;
				healthPoints = 1;
				maxHP = 1;
				break;
			case Bosses.Wizard:
				Level = 1;
				moveSpeed = 1;
				attackSpeed = 1;
				armor = 1;
				damage = 1;
				healthPoints = 1;
				maxHP = 1;
				break;
				
			default:
				break;
			}

		case Types.Melee:
			Level = 1;
			moveSpeed = 1;
			attackSpeed = 1;
			armor = 1;
			damage = 1;
			healthPoints = 1;
			maxHP = 1;
			break;

		case Types.Ranged:
			Level = 1;
			moveSpeed = 1;
			attackSpeed = 1;
			armor = 1;
			damage = 1;
			healthPoints = 1;
			maxHP = 1;
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

