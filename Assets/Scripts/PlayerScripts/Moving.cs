using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    float gold, tempMove, jumpSpeed, currEXP, experienceToNextLvl, healthPoints, maxHP, level, vitality, agility, strength, defense, damage, armor, dodge, statPoints, healthRegen;
    decimal moveSpeed, attackSpeed;
    Vector2 jump, move;
    private bool isGrounded, canWalk;
    Animator anim;
    ContactFilter2D cFilt = new ContactFilter2D();
    private Collider2D[] overlapped;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canWalk = true;
        overlapped = new Collider2D[10];
        jumpSpeed = 50;
        LoadState();
        Thread HPRegen = new Thread(RegenerateHealth);
        HPRegen.Start();
    }

    public void SaveState()
    {
        GlobalControl.Instance.agility = agility;
        GlobalControl.Instance.armor = armor;
        GlobalControl.Instance.attackSpeed = attackSpeed;
        GlobalControl.Instance.currEXP = currEXP;
        GlobalControl.Instance.damage = damage;
        GlobalControl.Instance.defense = defense;
        GlobalControl.Instance.dodge = dodge;
        GlobalControl.Instance.experienceToNextLvl = experienceToNextLvl;
        GlobalControl.Instance.gold = gold;
        GlobalControl.Instance.healthPoints = healthPoints;
        GlobalControl.Instance.healthRegen = healthRegen;
        GlobalControl.Instance.level = level;
        GlobalControl.Instance.maxHP = maxHP;
        GlobalControl.Instance.moveSpeed = moveSpeed;
        GlobalControl.Instance.statPoints = statPoints;
        GlobalControl.Instance.strength = strength;
        GlobalControl.Instance.vitality = vitality;
    }

    public void LoadState()
    {
        agility = GlobalControl.Instance.agility;
        armor = GlobalControl.Instance.armor;
        attackSpeed = GlobalControl.Instance.attackSpeed;
        currEXP = GlobalControl.Instance.currEXP;
        damage = GlobalControl.Instance.damage;
        defense = GlobalControl.Instance.defense;
        dodge = GlobalControl.Instance.dodge;
        experienceToNextLvl = GlobalControl.Instance.experienceToNextLvl;
        gold = GlobalControl.Instance.gold;
        healthPoints = GlobalControl.Instance.healthPoints;
        healthRegen = GlobalControl.Instance.healthRegen;
        level = GlobalControl.Instance.level;
        maxHP = GlobalControl.Instance.maxHP;
        moveSpeed = GlobalControl.Instance.moveSpeed;
        statPoints = GlobalControl.Instance.statPoints;
        strength = GlobalControl.Instance.strength;
        vitality = GlobalControl.Instance.vitality;
        transform.SetPositionAndRotation(new Vector3(GlobalControl.Instance.posX, GlobalControl.Instance.posY, GlobalControl.Instance.posZ), new Quaternion(0, 0, 0, 0));
    }

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

    public void LevelUp()
    {
        level += 1;
        moveSpeed += decimal.Parse("0.1");
        maxHP += 10;
        healthPoints += 10;
        statPoints += 1;
        damage += 5;
        armor += 1;
        experienceToNextLvl *= 6 / 5f;
        experienceToNextLvl = Mathf.Ceil(experienceToNextLvl);
    }

    public void VitalityUp()
    {
        statPoints -= 1;
        vitality += 1;
        maxHP += 50;
        healthPoints += 50;
        healthRegen += 1;
    }

    public void AgilityUp()
    {
        statPoints -= 1;
        agility += 1;
        moveSpeed += decimal.Parse("0.1");
        attackSpeed -= decimal.Parse("0.05");
    }

    public void StrengthUp()
    {
        statPoints -= 1;
        strength += 1;
        damage += 10;
    }

    public void DefenseUp()
    {
        statPoints -= 1;
        defense += 1;
        armor += 5;
        dodge += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currEXP >= experienceToNextLvl)
        {
            currEXP -= experienceToNextLvl;
            LevelUp();
        }
        if (canWalk)
        {
            //Walk
            if (isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    tempMove = Input.GetAxis("Horizontal") * Time.deltaTime * (float)moveSpeed;
                else
                    tempMove = 0;
                if (tempMove < 0) playerSprite.flipX = true;
                if (tempMove > 0) playerSprite.flipX = false;
                anim.SetFloat("Speed", Mathf.Abs(tempMove));
                move = new Vector2(tempMove, 0);
            }
            rb.transform.Translate(move[0], 0, 0);
            //Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                jump = new Vector2(0, jumpSpeed);
                rb.AddForce(jump, ForceMode2D.Impulse);
                rb.AddForce(move);
                isGrounded = false;
                anim.SetBool("Grounded", isGrounded);
            }
        }
        //Interaction
        if (Input.GetKeyDown(KeyCode.Space) && tempMove == 0 && isGrounded)
        {
            rb.OverlapCollider(cFilt, overlapped);
            //NPC
            if (overlapped[0].gameObject.layer == 10)
            {
                overlapped[0].gameObject.GetComponent<NPCInteraction>().Test();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Land
        if (col.gameObject.layer == 9)
        {
            isGrounded = true;
            anim.SetBool("Grounded", isGrounded);
        }
    }

    //Getters & Setters
    public bool CanWalk
    {
        get
        {
            return canWalk;
        }
        set
        {
            canWalk = value;
        }
    }

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

    public float CurrEXP
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

    public float ExperienceToNextLvl
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

    public float HealthPoints
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

    public float MaxHP
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

    public float Level
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

    public float Vitality
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

    public float Agility
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

    public float Strength
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

    public float Defense
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

    public float Damage
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

    public float Armor
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

    public float Dodge
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

    public float StatPoints
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

    public float HealthRegen
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

    public float Gold
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
}
