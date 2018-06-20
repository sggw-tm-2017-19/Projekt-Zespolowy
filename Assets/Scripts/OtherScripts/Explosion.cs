using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private const float forceFactor = 10;

    public float Damage;
    public float Force;

    private GameObject player;
    private bool playerHit = false;
    private Animator animator;

    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        float delay = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if(!playerHit && other.name == "Player")
        {
            player.SendMessage("TakeDamage", Damage);
            Rigidbody2D playerRigitbody = player.GetComponent<Rigidbody2D>();
            //Vector2 pushDirection = (player.transform.position - transform.position).normalized;
            //playerRigitbody.AddForce(pushDirection * Force * forceFactor, ForceMode2D.Impulse);
            playerHit = true;
        }
    }


}
