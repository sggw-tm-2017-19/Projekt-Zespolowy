using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MobMovement : MonoBehaviour
{
    [SerializeField]
	private float speed;
	private bool isMoving = false;
    [SerializeField]
	private Vector3 direction;
	private GameObject player;
    [SerializeField]
    private float minDistance;

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

		if (Math.Abs(transform.position.x - player.transform.position.x) < minDistance || GetComponent<MobStats>().Stun) 
		{
			StopMoving();
		} 

		if (isMoving) transform.position += direction * speed;
	}

	private void SetDirection()
	{
		int direction = Math.Sign(player.transform.position.x - transform.position.x);
		spriteRenderer.flipX = direction <= 0 ? true : false;
        if(spriteRenderer.flipX)
        {
            if (GetComponent<BasicRange>() != null)
            {
                Vector3 localPosition = GetComponent<BasicRange>().ProjectileStartPoint.localPosition;
                if (localPosition.x > 0)
                {
                    Vector3 relativePosition = transform.TransformPoint(new Vector3(- localPosition.x, localPosition.y, localPosition.z));
                    GetComponent<BasicRange>().ProjectileStartPoint.SetPositionAndRotation(relativePosition, new Quaternion(0,0,0,0));
                    GetComponent<BasicRange>().direction = new Vector2(-1, 0);
                }
            }
        }
        else
        {
            if (GetComponent<BasicRange>() != null)
            {
                Vector3 localPosition = GetComponent<BasicRange>().ProjectileStartPoint.localPosition;
                if (localPosition.x < 0)
                {
                    Vector3 relativePosition = transform.TransformPoint(new Vector3(-localPosition.x, localPosition.y, localPosition.z));
                    GetComponent<BasicRange>().ProjectileStartPoint.SetPositionAndRotation(relativePosition, new Quaternion(0, 0, 0, 0));
                    GetComponent<BasicRange>().direction = new Vector2(1, 0);
                }
            }
        }
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

