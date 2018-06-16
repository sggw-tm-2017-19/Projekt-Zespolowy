﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum RotationMode { Rotate, FlipOnly, None}
public class ProjectileScript : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damage;
    public float directionAngle;
    public RotationMode rotationMode;
    public bool destroyOnObstacles = true;

    private Vector2 movementDirection;
    private bool playerHit = false;
    private int[] ingoreObjects = { 0, 11 };

    Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    private void Awake()
    {
        setDirectionAngle(directionAngle);
    }

    // Use this for initialization
    void Start() {
        GameObject.Destroy(gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update() {
        Position += (Vector3)movementDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.name == "Player" && !playerHit)
        {
            otherObject.SendMessage("TakeDamage", damage);
            playerHit = true;
        }
        if (destroyOnObstacles && !ingoreObjects.Contains(otherObject.layer))
            Destroy(gameObject);
    }

    public void setDirectionAngle(float angle)
    {
        directionAngle = Mathf.Deg2Rad * angle;
        movementDirection = new Vector2(Mathf.Cos(directionAngle), Mathf.Sin(directionAngle)).normalized;
        Rotate(angle);
    }

    public void setDirection(Vector2 direction)
    {
        movementDirection = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.right, movementDirection);
        directionAngle = angle * Mathf.Deg2Rad;
        Rotate(angle);
    }

    private void Rotate(float angle)
    {
        switch (rotationMode)
        {
            case RotationMode.Rotate:
                transform.rotation = Quaternion.Euler(0, 0, angle);
                break;
            case RotationMode.FlipOnly:
                float newRotation = transform.rotation.eulerAngles.z * Mathf.Rad2Deg + angle;
                if (newRotation > 90 && newRotation <= 270)
                {
                    transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                    GetComponent<SpriteRenderer>().flipY = true;
                }
                else
                {
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    GetComponent<SpriteRenderer>().flipY = false;
                }
                break;
            case RotationMode.None:
                break;
            default:
                break;
        }
    }
}


