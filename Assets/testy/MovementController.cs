using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float Speed;
    public Vector3 direction;

    private bool canMove = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (direction.magnitude != 1) direction.Normalize();
        if (canMove) transform.position += direction * Speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = false;
    }
}
