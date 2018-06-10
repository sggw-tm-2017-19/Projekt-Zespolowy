using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMelee : MonoBehaviour
{


    public int Damage;
    public float Cooldown;
    public float Range;

    public Dictionary<float, MonoBehaviour> testDic;


    private new BoxCollider2D collider;
    private float timeCounter;
    private Animator animator;
    private const string basicAttackTrigger = "basicAttack";

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        timeCounter = Cooldown;
        SetColliderSize();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == GlobalControl.Instance.Player && timeCounter >= Cooldown)
        {
            Attack(other.gameObject);
            timeCounter = 0;
        }
    }

    private void SetColliderSize()
    {
        collider.size += new Vector2(Range / 2, 0);
        collider.offset -= new Vector2(Range / 2, 0);
    }

    private void Attack(GameObject gameObject)
    {
        animator.SetTrigger(basicAttackTrigger);
        gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }

}
