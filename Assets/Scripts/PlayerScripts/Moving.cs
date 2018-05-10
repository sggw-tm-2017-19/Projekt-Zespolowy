using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    float tempMove, jumpSpeed = 50, moveSpeed = 8;
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
                    tempMove = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                else
                    tempMove = 0;
                if (tempMove < 0) playerSprite.flipX = true;
                if (tempMove > 0) playerSprite.flipX = false;
                anim.SetFloat("Speed", Mathf.Abs(tempMove));
                move = new Vector2(tempMove, 0);
            }
            rb.transform.Translate(move[0], 0, 0);
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

    public void SetCanWalk(bool choice)
    {
        canWalk = choice;
    }
}
