using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float Speed;
    public Vector3 direction;

    private bool canMove = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        direction.Normalize();
        if (canMove) transform.position += direction * Speed;
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
