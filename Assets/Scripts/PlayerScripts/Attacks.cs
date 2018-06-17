using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacks : PlayerStats
{
    public static Attacks Instance;

    public float WaveSwordRange;
    public float StunDuration;
    
    public GameObject piercingArrowPrefab;
    private Vector3 piercingArrowStartPosition;
    private SpriteRenderer piercingArrowSprite;

    public float DashRange;
    public GameObject dashFirePrefab;
    private Vector3 dashFirePosition;
    private float dashFireWidth;

    private PlayerStats playerStats;
    private SpriteRenderer playerSprite;
    private Animator animator;
    private CapsuleCollider2D AttackCollider;

    private List<GameObject> Enemies = new List<GameObject>();

    private decimal basicAttackCounter = 0;
    private int basicAttackHash = Animator.StringToHash("New Layer.MainCharacter_BasicAttack");
    public decimal BasicAttackCounter
    {
        get
        {
            return basicAttackCounter;
        }
        set
        {
            basicAttackCounter = value;
        }
    }

    private decimal waveSwordCounter = 0;
    private int waveSwordHash = Animator.StringToHash("New Layer.MainCharacter_WaveSword");
    public decimal WaveSwordCounter
    {
        get
        {
            return waveSwordCounter;
        }
        set
        {
            waveSwordCounter = value;
        }
    }

    private decimal piercingArrowCounter = 0;
    private int piercingArrowHash = Animator.StringToHash("New Layer.MainCharacter_PiercingArrow");
    public decimal PiercingArrowCounter
    {
        get
        {
            return piercingArrowCounter;
        }
        set
        {
            piercingArrowCounter = value;
        }
    }

    private decimal dashCounter = 0;
    private int dashHash = Animator.StringToHash("New Layer.MainCharacter_Dash");
    public decimal DashCounter
    {
        get
        {
            return dashCounter;
        }
        set
        {
            dashCounter = value;
        }
    }

    private decimal healCounter = 0;
    public decimal HealCounter
    {
        get
        {
            return healCounter;
        }
        set
        {
            healCounter = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        AttackCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        piercingArrowSprite = piercingArrowPrefab.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        basicAttackCounter -= Convert.ToDecimal(Time.deltaTime);
        waveSwordCounter -= Convert.ToDecimal(Time.deltaTime);
        piercingArrowCounter -= Convert.ToDecimal(Time.deltaTime);
        dashCounter -= Convert.ToDecimal(Time.deltaTime);
        healCounter -= Convert.ToDecimal(Time.deltaTime);
        if (GetComponent<Actions>().CanWalk)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                BasicAttack();

            if (Input.GetKeyDown(KeyCode.X))
                WaveSword();

            if (Input.GetKeyDown(KeyCode.C))
                PiercingArrow();

            if (Input.GetKeyDown(KeyCode.V))
                Dash();

            if (Input.GetKeyDown(KeyCode.B))
                Heal();

            if (basicAttackHash == animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            {
                EnableCollider();
                playerSprite.transform.position = new Vector3(playerSprite.transform.position.x + 0.0001f, playerSprite.transform.position.y);
                animator.speed = (float)(0.5m + playerStats.AttackSpeed / 2);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
                    Invoke("InvokeBasicAttack", animator.GetCurrentAnimatorStateInfo(0).length / 2);
            }

            if (waveSwordHash == animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            {
                EnableCollider();
                playerSprite.transform.position = new Vector3(playerSprite.transform.position.x + 0.0001f, playerSprite.transform.position.y);
                animator.speed = (float)(0.5m + playerStats.AttackSpeed / 2);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
                    Invoke("InvokeWaveSword", animator.GetCurrentAnimatorStateInfo(0).length / 2);
            }

            if (basicAttackHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash &&
                waveSwordHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
                DisableCollider();

            if (piercingArrowHash == animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            {
                animator.speed = (float)(0.5m + playerStats.AttackSpeed / 2);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
                    Invoke("CreateArrow", animator.GetCurrentAnimatorStateInfo(0).length / 2);
            }

            if (dashHash == animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            {
                animator.speed = (float)(5m);
                MoveDash();
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
                {
                    dashFirePosition = new Vector3(playerSprite.transform.position.x, playerSprite.transform.position.y - 2.2f);
                    Invoke("InvokeCreateFire", animator.GetCurrentAnimatorStateInfo(0).length / 5);
                }
            }
            if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != basicAttackHash &&
                animator.GetCurrentAnimatorStateInfo(0).fullPathHash != waveSwordHash &&
                animator.GetCurrentAnimatorStateInfo(0).fullPathHash != piercingArrowHash &&
                animator.GetCurrentAnimatorStateInfo(0).fullPathHash != dashHash)
                animator.speed = 1;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            if (!Enemies.Contains(other.gameObject))
                Enemies.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            Enemies.Remove(other.gameObject);
    }

    private void EnableCollider()
    {
        AttackCollider.enabled = true;
    }
    private void DisableCollider()
    {
        AttackCollider.enabled = false;
    }

    private void InvokeBasicAttack()
    {
        BasicAttack(Enemies);
    }
    private void BasicAttack()
    {
        decimal cooldown = 3 - playerStats.AttackSpeed;
        if (cooldown < 0.3m) cooldown = 0.3m;
        if (basicAttackCounter <= 0)
        {
            basicAttackCounter = cooldown;
            animator.SetTrigger("BasicAttack");
            AttackCollider.direction = CapsuleDirection2D.Vertical;
            AttackCollider.size = new Vector2(2f, 5f);
            if (playerSprite.flipX)
                AttackCollider.offset = new Vector2(-1f, 0);
            else
                AttackCollider.offset = new Vector2(1f, 0);
        }
    }

    private void BasicAttack(List<GameObject> enemies)
    {
        int damage = playerStats.Damage;
        
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
            }
        }
    }

    private void InvokeWaveSword()
    {
        WaveSword(Enemies);
    }
    private void WaveSword()
    {
        decimal cooldown = 11 - playerStats.AttackSpeed;
        if (cooldown < 2) cooldown = 2;
        if (waveSwordCounter <= 0)
        {
            waveSwordCounter = cooldown;
            animator.speed = (float)(0.5m + playerStats.AttackSpeed / 2);
            animator.SetTrigger("WaveSword");
            AttackCollider.direction = CapsuleDirection2D.Horizontal;
            AttackCollider.size = new Vector2(WaveSwordRange, 4.5f);
            if (playerSprite.flipX)
                AttackCollider.offset = new Vector2(-WaveSwordRange / 2, 0);
            else
                AttackCollider.offset = new Vector2(WaveSwordRange / 2, 0);
        }
    }
    private void WaveSword(List<GameObject> enemies)
    {
        int damage = playerStats.Damage;
        float stunTime = StunDuration;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<MobStats>().GetStun(stunTime);
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
            }
        }
    }

    private void PiercingArrow()
    {
        decimal cooldown = 5 - playerStats.AttackSpeed;
        if (cooldown < 1) cooldown = 1;
        if(piercingArrowCounter <= 0)
        {
            piercingArrowCounter = cooldown;
            animator.SetTrigger("PiercingArrow");
        }
    }
    private void CreateArrow()
    {
        piercingArrowStartPosition = playerSprite.transform.position;
        piercingArrowSprite.flipX = playerSprite.flipX;
        piercingArrowStartPosition.y += 0.2f;
        piercingArrowStartPosition.z = -0.1f;
        piercingArrowPrefab.transform.position = piercingArrowStartPosition;
        GameObject piercingArrow = Instantiate(piercingArrowPrefab);
        if (piercingArrowSprite.flipX)
        {
            piercingArrow.GetComponent<ArrowScript>().ArrowSpeed = -20f;
        }
        else
        {
            piercingArrow.GetComponent<ArrowScript>().ArrowSpeed = 20f;
        }
    }

    private void Dash()
    {
        decimal cooldown = 20 - playerStats.MoveSpeed;
        if (cooldown < 5) cooldown = 5;
        if (dashCounter <= 0)
        {
            dashCounter = cooldown;
            animator.SetTrigger("Dash");
        }
    }
    private void MoveDash()
    {
        float dashRange = DashRange + (float)playerStats.MoveSpeed;
        if (playerSprite.flipX)
            dashRange = -dashRange;
        playerSprite.transform.Translate(dashRange*Time.deltaTime, 0, 0);
    }
    private void InvokeCreateFire()
    {
        GameObject dashFire = Instantiate(dashFirePrefab);
        dashFire.transform.position = new Vector3((dashFirePosition.x + playerSprite.transform.position.x) / 2, dashFirePosition.y);
        dashFireWidth = dashFirePosition.x - playerSprite.transform.position.x;
        dashFire.transform.localScale = new Vector3(dashFireWidth/12, dashFire.transform.localScale.y, 0);
    }
    private void Heal()
    {
        int healthUp = playerStats.MaxHP / 5;
        decimal cooldown = 30 - playerStats.AttackSpeed;
        if (cooldown < 5) cooldown = 5;
        if (healCounter <= 0)
        {
            healCounter = cooldown;
            playerStats.HealthPoints += healthUp;
        }
    }
}
