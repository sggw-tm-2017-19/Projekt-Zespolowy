using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damage;
    public float directionAngle;

    private Vector2 movementDirection;

    Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    private void Awake()
    {
        setDirectionAngle(directionAngle);
    }

    // Use this for initialization
    void Start () {
        GameObject.Destroy(gameObject, lifeTime);
        //transform.rotation = 
	}
	
	// Update is called once per frame
	void Update () {
        Position += (Vector3)movementDirection * speed * Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.name == "Player") otherObject.SendMessage("TakeDamage", damage);
        if (otherObject.tag != "Enemy") Destroy(gameObject);
        
    }

    public void setDirectionAngle(float angle)
    {
        directionAngle = Mathf.Deg2Rad * angle;
        movementDirection = new Vector2(Mathf.Cos(directionAngle), Mathf.Sin(directionAngle)).normalized;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void setDirection(Vector2 direction)
    {
        movementDirection = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.right, movementDirection);
        directionAngle = angle * Mathf.Deg2Rad;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
