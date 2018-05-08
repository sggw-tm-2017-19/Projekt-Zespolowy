using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
	private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    float tempMove, jumpSpeed = 50, moveSpeed = 8;
	Vector2 jump, move;
	private bool isGrounded;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                tempMove = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            else
                tempMove = 0;
            if (tempMove < 0) playerSprite.flipX = true;
            if (tempMove > 0) playerSprite.flipX = false;
            move = new Vector2(tempMove, 0);
        }
        rb.transform.Translate(move[0], 0, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
		{
			jump = new Vector2(0, jumpSpeed);
			rb.AddForce(jump, ForceMode2D.Impulse);
            rb.AddForce(move);
			isGrounded = false;
        }
    }

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.layer == 9)
			isGrounded = true;
	}
}
