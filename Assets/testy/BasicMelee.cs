using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMelee : MonoBehaviour {

    const int idleState = 0;
    const int moveState = 1;
    const int basicAttackState = 2;
    const int strongAttackState = 3;
    const string animationParameterName = "State";

    public float Damage;
    public float Cooldown;
    public float Range;

    public Dictionary<float, MonoBehaviour> testDic;
    

    private new BoxCollider2D collider;
    private GameObject player;
    private float timeCounter;
    private Animator animator;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        timeCounter = Cooldown;
        SetColliderSize();
	}

    private void Update()
    {
        timeCounter+=Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject==player && timeCounter >= Cooldown)
        {
            Attack(other.gameObject);
            timeCounter %= Cooldown;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetInteger(animationParameterName, idleState);
    }
    



    private void SetColliderSize()
    {
        collider.size += new Vector2(Range / 2, 0);
        collider.offset -= new Vector2(Range / 2, 0);
    }

        private void Attack(GameObject gameObject)
    {
        animator.SetInteger(animationParameterName, basicAttackState);
        gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }

 

   
}
