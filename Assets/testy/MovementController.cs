using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float Speed;
    public Vector3 direction;
    

    private bool canMove = true;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

   

    // Update is called once per frame
    void Update () {
        SetDirection();
        if (canMove) transform.position += direction * Speed;
	}
 private void SetDirection()
    {
        int direction = Math.Sign(player.transform.position.x - transform.position.x);
        spriteRenderer.flipX = direction <= 0 ? true : false;
        this.direction = new Vector2(direction, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "Player") { StopMoving();     return; }
        if (other.name == "mapa") StartMoving();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "Player") { StartMoving(); return; }
        if (other.name == "mapa") StopMoving();
    }

    public void StopMoving()
    {
        canMove = false;
    }

    public void StartMoving()
    {
        canMove = true;
    }
}
