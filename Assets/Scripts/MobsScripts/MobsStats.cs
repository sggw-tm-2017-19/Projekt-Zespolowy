using UnityEngine;
using System.Collections;

public class MobsStats : MonoBehaviour
{
	private decimal moveSpeed, attackSpeed;
	private int armor, damage, healthPoints, maxHP;

	private enum Types { Melee, Ranged }
	private enum Mobs { Imp, Skkub, Wizard }
	[SerializeField]
	private Types Fight;
	[SerializeField]
	private Mobs Mob;
	[SerializeField]
	private int Level;


	public void SaveState()
	{
		GlobalControl.Instance.attackSpeed = attackSpeed;
		GlobalControl.Instance.moveSpeed = moveSpeed;
		GlobalControl.Instance.armor = armor;
		GlobalControl.Instance.damage = damage;
		GlobalControl.Instance.healthPoints = healthPoints;
		GlobalControl.Instance.maxHP = maxHP;
	}

	public void LoadState()
	{
		attackSpeed = GlobalControl.Instance.attackSpeed;
		moveSpeed = GlobalControl.Instance.moveSpeed;
		armor = GlobalControl.Instance.armor;
		damage = GlobalControl.Instance.damage;
		healthPoints = GlobalControl.Instance.healthPoints;
		maxHP = GlobalControl.Instance.maxHP;


		// transform.SetPositionAndRotation(new Vector3(GlobalControl.Instance.posX, GlobalControl.Instance.posY, GlobalControl.Instance.posZ), new Quaternion(0, 0, 0, 0));
	}

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
		switch (Mobs[type]) {
		case Mobs.Imp:
			Level = 1;
			moveSpeed = 1;
			attackSpeed = 1;
			armor = 1;
			damage = 1;
			healthPoints = 1;
			maxHP = 1;
			break;

		case Mobs.Skkub:
			Level = 1;
			moveSpeed = 1;
			attackSpeed = 1;
			armor = 1;
			damage = 1;
			healthPoints = 1;
			maxHP = 1;
			break;

		case Mobs.Wizard:
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

