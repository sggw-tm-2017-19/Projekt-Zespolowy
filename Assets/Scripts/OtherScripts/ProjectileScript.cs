using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damage;
    public Vector2 movementDirection;

    Vector3 Position { get { return transform.position; } set { transform.position = value; } }

	// Use this for initialization
	void Start () {
        movementDirection.Normalize();
        GameObject.Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        Position += (Vector3)movementDirection * speed * Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.name == "Player")
        {
            otherObject.SendMessage("TakeDamage", damage);
            GameObject.Destroy(gameObject);
        }
        
    }


}
