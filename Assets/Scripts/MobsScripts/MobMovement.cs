using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MobMovement : MonoBehaviour
{
	public float speed;
	private bool isMoving = false;
	public Vector3 direction = new Vector2(-1, 0);
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		if (isMoving) transform.position += direction * speed;
        player = GlobalControl.Instance.Player;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x - player.transform.position.x < 30 && !GetComponent<MobStats>().Stun) 
		{
			StartMoving();
		}

		if (transform.position.x - player.transform.position.x < 10 || GetComponent<MobStats>().Stun) 
		{
			StopMoving();
		} 

		if (isMoving) transform.position += direction * speed;
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

