using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacks : PlayerStats
{
    public float WaveSwordRange;
    public float StunDuration;

    public float ArrowRange;
    public GameObject piercingArrowPrefab;
    private Vector3 piercingArrowStartPosition;
    private SpriteRenderer piercingArrowSprite;

    private SpriteRenderer playerSprite;
    private Animator animator;
    private CapsuleCollider2D AttackCollider;
    private List<GameObject> enemies = new List<GameObject>();

    private decimal basicAttackCounter = 0;
    private int basicAttackHash = Animator.StringToHash("New Layer.MainCharacter_BasicAttack");

    private decimal waveSwordCounter = 0;
    private int waveSwordHash = Animator.StringToHash("New Layer.MainCharacter_WaveSword");

    private decimal piercingArrowCounter = 0;
    private int piercingArrowHash = Animator.StringToHash("New Layer.MainCharacter_PiercingArrow");

    private void Awake()
    {
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

        if (Input.GetKeyDown(KeyCode.Z))
            BasicAttack(enemies);

        if (Input.GetKeyDown(KeyCode.X))
            WaveSword(enemies);

        if (Input.GetKeyDown(KeyCode.C))
            PiercingArrow();

        if (basicAttackHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash &&
            waveSwordHash != animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            DisableCollider();
        else
            EnableCollider();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
            if (!enemies.Contains(other.gameObject))
                enemies.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 11) enemies.Remove(other.gameObject);
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
        int damage = Damage;
        decimal cooldown = 2 - AttackSpeed;
        if (basicAttackCounter <= 0)
        {
            Debug.Log(enemies.Count);
            basicAttackCounter = cooldown;
            animator.speed = (float)(0.8m + AttackSpeed);
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
                enemies[i].GetComponent<MobController>().Attacked(damage);
            }
        }
    }

    private void WaveSword(List<GameObject> enemies)
    {
        int damage = Damage;
        decimal cooldown = 10 - AttackSpeed;
        float stunTime = StunDuration;
        if (waveSwordCounter <= 0)
        {
            Debug.Log(enemies.Count);
            waveSwordCounter = cooldown;
            animator.speed = (float)(0.3m + AttackSpeed);
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
                enemies[i].GetComponent<MobController>().Stunned(stunTime);
                enemies[i].GetComponent<MobController>().Attacked(damage);
            }
        }
    }

    private void PiercingArrow()
    {
        int damage = Damage;
        decimal cooldown = 3 - AttackSpeed;
        if(piercingArrowCounter <= 0)
        {
            piercingArrowCounter = cooldown;
            animator.speed = (float)(0.3m + AttackSpeed);
            animator.SetTrigger("PiercingArrow");
            Invoke("CreateArrow", 0.5f);
        }
    }
    private void CreateArrow()
    {
        piercingArrowStartPosition = playerSprite.transform.position;
        piercingArrowSprite.flipX = !playerSprite.flipX;
        piercingArrowStartPosition.y += 0.2f;
        piercingArrowStartPosition.z = -0.1f;
        piercingArrowPrefab.transform.position = piercingArrowStartPosition;
        GameObject piercingArrow = Instantiate(piercingArrowPrefab);
        if (piercingArrowSprite.flipX)
        {
            piercingArrow.GetComponent<ArrowScript>().ArrowSpeed = 5f;
        }
        else
        {
            piercingArrow.GetComponent<ArrowScript>().ArrowSpeed = -5f;
        }
    }
}
