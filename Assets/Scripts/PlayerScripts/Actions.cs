using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    float tempMove, jumpSpeed;
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
        jumpSpeed = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            //Walk
            if (isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    tempMove = Input.GetAxis("Horizontal") * Time.deltaTime * (float)GetComponent<PlayerStats>().MoveSpeed;
                else
                    tempMove = 0;
                if (tempMove < 0) playerSprite.flipX = true;
                if (tempMove > 0) playerSprite.flipX = false;
                anim.SetFloat("Speed", Mathf.Abs(tempMove));
                move = new Vector2(tempMove, 0);
            }
            rb.transform.Translate(move[0], 0, 0);
            anim.SetFloat("vSpeed", rb.velocity.y);
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
}
