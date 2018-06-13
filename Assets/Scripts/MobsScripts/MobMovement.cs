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
		player = GameObject.FindGameObjectWithTag("Player");
		if (isMoving) transform.position += direction * speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x - player.transform.position.x < 30) 
		{
			StartMoving();
		}

		if (transform.position.x - player.transform.position.x < 10) 
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

