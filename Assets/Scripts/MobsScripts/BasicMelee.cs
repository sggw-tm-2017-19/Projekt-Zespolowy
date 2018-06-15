using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMelee : MonoBehaviour
{


    public int Damage;
    public float Cooldown;
    public float Range;
    public string trigger;
    

    
    private float timeCounter;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private GameObject player;
    private MobStats mobStats;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        mobStats = GetComponent<MobStats>();
    }

    // Use this for initialization
    void Start()
    {
        timeCounter = Cooldown;
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= Range && timeCounter>=Cooldown && !mobStats.Stun)
        {
            Attack(player);
            timeCounter = 0;
        }
        timeCounter += Time.deltaTime;
    }

   

 

    private void Attack(GameObject gameObject)
    {
        animator.SetTrigger(trigger);
        gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }


}
