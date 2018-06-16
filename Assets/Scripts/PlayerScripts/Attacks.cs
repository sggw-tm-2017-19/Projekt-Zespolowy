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
    private Vector3 dashFireStartPosition;
    private Vector3 dashFireEndPosition;
    private SpriteRenderer dashFireSprite;

    private PlayerStats playerStats;
    private SpriteRenderer playerSprite;
    private Animator animator;
    private CapsuleCollider2D AttackCollider;

    private List<GameObject> Enemies = new List<GameObject>();

    private decimal basicAttackCounter = 0;
    private int basicAttackHash = Animator.StringToHash("New Layer.MainCharacter_BasicAttack");

    private decimal waveSwordCounter = 0;
    private int waveSwordHash = Animator.StringToHash("New Layer.MainCharacter_WaveSword");

    private decimal piercingArrowCounter = 0;
    private int piercingArrowHash = Animator.StringToHash("New Layer.MainCharacter_PiercingArrow");

    private decimal dashCounter = 0;
    private int dashHash = Animator.StringToHash("New Layer.MainCharacter_Dash");

    private void Awake()
    {
        Instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        AttackCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        piercingArrowSprite = piercingArrowPrefab.GetComponent<SpriteRenderer>();
        dashFireSprite = dashFirePrefab.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        basicAttackCounter -= Convert.ToDecimal(Time.deltaTime);
        waveSwordCounter -= Convert.ToDecimal(Time.deltaTime);
        piercingArrowCounter -= Convert.ToDecimal(Time.deltaTime);
        dashCounter -= Convert.ToDecimal(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Z))
            BasicAttack(Enemies);

        if (Input.GetKeyDown(KeyCode.X))
            WaveSword(Enemies);

        if (Input.GetKeyDown(KeyCode.C))
            PiercingArrow();

        if (Input.GetKeyDown(KeyCode.V))
            Dash();

        if (basicAttackHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash &&
            waveSwordHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            DisableCollider();
        else
        {
            EnableCollider();
            animator.speed = (float)(0.5m + playerStats.AttackSpeed / 2);
        }
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
        }
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != basicAttackHash &&
            animator.GetCurrentAnimatorStateInfo(0).fullPathHash != waveSwordHash &&
            animator.GetCurrentAnimatorStateInfo(0).fullPathHash != piercingArrowHash &&
            animator.GetCurrentAnimatorStateInfo(0).fullPathHash != dashHash)
            animator.speed = 1;
    }

    public void RemoveFromEnemies(GameObject enemy)
    {
        if(Enemies.Contains(enemy))
            Enemies.Remove(enemy);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            if (!Enemies.Contains(other.gameObject))
                Enemies.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") Enemies.Remove(other.gameObject);
    }

    private void EnableCollider()
    {
        AttackCollider.enabled = true;
    }
    private void DisableCollider()
    {
        AttackCollider.enabled = false;
    }

    private void BasicAttack(List<GameObject> enemies)
    {
        int damage = playerStats.Damage;
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
            EnableCollider();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
                if (enemies[i].GetComponent<MobStats>().HealthPoints <= 0)
                {
                    Destroy(enemies[i].gameObject);
                    playerStats.CurrEXP += 500;
                    playerStats.Gold += 500;
                }
            }
        }
    }

    private void WaveSword(List<GameObject> enemies)
    {
        int damage = playerStats.Damage;
        decimal cooldown = 10 - playerStats.AttackSpeed;
        if (cooldown < 1) cooldown = 1;
        float stunTime = StunDuration + 10;
        if (waveSwordCounter <= 0)
        {
            waveSwordCounter = cooldown;
            animator.speed = (float)(0.5m + playerStats.AttackSpeed/2);
            animator.SetTrigger("WaveSword");
            AttackCollider.direction = CapsuleDirection2D.Horizontal;
            AttackCollider.size = new Vector2(WaveSwordRange, 4.5f);
            if (playerSprite.flipX)
                AttackCollider.offset = new Vector2(-WaveSwordRange/2, 0);
            else
                AttackCollider.offset = new Vector2(WaveSwordRange/2, 0);
            EnableCollider();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<MobStats>().GetStun(stunTime);
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
                if (enemies[i].GetComponent<MobStats>().HealthPoints <= 0)
                {
                    Destroy(enemies[i].gameObject);
                    playerStats.CurrEXP += 500;
                    playerStats.Gold += 500;
                }
            }
        }
    }

    private void PiercingArrow()
    {
        playerStats.CurrEXP += 500000;
        decimal cooldown = 4 - playerStats.AttackSpeed;
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
        decimal cooldown = 20 - MoveSpeed;
        if (cooldown < 1) cooldown = 1;
        if (dashCounter <= 0)
        {
            dashCounter = cooldown;
            animator.SetTrigger("Dash");
        }
    }
    private void MoveDash()
    {
        dashFireStartPosition = playerSprite.transform.position;
        dashFireSprite.flipX = !playerSprite.flipX;
        dashFireStartPosition.y -= 1.8f;
        dashFirePrefab.transform.position = dashFireStartPosition;
        GameObject dashFire = Instantiate(dashFirePrefab);
        float dashRange = DashRange + (float)MoveSpeed;
        if (playerSprite.flipX)
            dashRange = -dashRange;
        playerSprite.transform.Translate(dashRange*Time.deltaTime, 0, 0);
    }
}
