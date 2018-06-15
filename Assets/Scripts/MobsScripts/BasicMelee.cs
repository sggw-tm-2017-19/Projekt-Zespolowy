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

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        timeCounter = Cooldown;
        setColliderSize();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == GlobalControl.Instance.Player.name && timeCounter >= Cooldown && !GetComponent<MobStats>().Stun)
        {
            Attack(other.gameObject);
            timeCounter = 0;
        }
    }

    void setColliderSize()
    {
        BoxCollider2D mainCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D newCollider = gameObject.AddComponent<BoxCollider2D>();
        newCollider.size = mainCollider.size + new Vector2(Range, 0);
        newCollider.offset = Vector2.left * newCollider.size.x / 2;
        newCollider.isTrigger = true;
        boxCollider = newCollider;
    }

    private void Attack(GameObject gameObject)
    {
        animator.SetTrigger(trigger);
        gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }


}
