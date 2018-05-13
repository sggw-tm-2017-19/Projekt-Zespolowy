using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    float tempMove, jumpSpeed, moveSpeed, currEXP, experienceToNextLvl, healthPoints, maxHP, level, vitality, agility, strength, defense, attackSpeed, damage, armor, dodge, statPoints, healthRegen;
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
        moveSpeed = 4;
        currEXP = 0;
        maxHP = 500;
        healthPoints = maxHP;
        level = 1;
        vitality = 0;
        agility = 0;
        strength = 0;
        defense = 0;
        attackSpeed = 1;
        damage = 10;
        armor = 5;
        dodge = 0;
        statPoints = 0;
        healthRegen = 1;
        experienceToNextLvl = 500;
        Thread HPRegen = new Thread(RegenerateHealth);
        HPRegen.Start();
    }

    public void RegenerateHealth()
    {
        healthPoints += healthRegen;
        if(healthPoints>maxHP)
        {
            healthPoints = maxHP;
        }
        Thread.Sleep(1000);
        RegenerateHealth();
    }

    public void LevelUp()
    {
        level += 1;
        moveSpeed += 0.1f;
        maxHP += 10;
        healthPoints += 10;
        statPoints += 1;
        damage += 5;
        armor += 1;
        experienceToNextLvl *= 2;
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
        moveSpeed += 0.1f;
        attackSpeed -= 0.05f;
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
        if(currEXP>=experienceToNextLvl)
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
                    tempMove = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
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

    public float MoveSpeed
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

    public float AttackSpeed
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
}
