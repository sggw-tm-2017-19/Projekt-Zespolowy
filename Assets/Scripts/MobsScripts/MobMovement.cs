using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MobMovement : MonoBehaviour
{
	public float speed;
	private bool isMoving = false;
	public Vector3 direction;
	private GameObject player;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
	{
		if (isMoving) transform.position += direction * speed;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        player = GlobalControl.Instance.Player;

		SetDirection ();
			
		if (Math.Abs(transform.position.x - player.transform.position.x ) < 30 && !GetComponent<MobStats>().Stun) 
		{
			StartMoving();
		}

		if (Math.Abs(transform.position.x - player.transform.position.x) < 5 || GetComponent<MobStats>().Stun) 
		{
			StopMoving();
		} 

		if (isMoving) transform.position += direction * speed;
	}

	private void SetDirection()
	{
		int direction = Math.Sign(player.transform.position.x - transform.position.x);
		spriteRenderer.flipX = direction <= 0 ? true : false;
		this.direction = new Vector2(direction, 0);
	}

	public void StopMoving()
	{
		isMoving = false;
	}

	public void StartMoving()
	{
		isMoving = true;
	}
}

