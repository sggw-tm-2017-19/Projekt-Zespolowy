using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileTrajectory { ConstantDirection, AimPlayer}
public class BasicRange : MonoBehaviour {
    public ProjectileTrajectory trajectory;
    public GameObject projectilePrefab;
    public float Cooldown;
    public int NumberOfProjectiles=1;
    public float Range;
    public Transform ProjectileStartPoint;
    public Vector2 direction;
    
    
    private float timeCount = 0;
    private BoxCollider2D boxCollider;
    private GameObject player;
	// Use this for initialization
	void Start () {
        setColliderSize();
        player = GameObject.Find("Player");


	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "Player" && timeCount>=Cooldown)
        {
            Attack(other);
            timeCount = 0;
        }
    }

    private void Attack(GameObject other)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = ProjectileStartPoint.position;
        if (trajectory == ProjectileTrajectory.ConstantDirection)
            projectile.SendMessage("setDirection", this.direction);
        else projectile.SendMessage("setDirection", player.transform.position - ProjectileStartPoint.position);
        
    }

    void setColliderSize()
    {
        BoxCollider2D mainCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D newCollider=gameObject.AddComponent<BoxCollider2D>();
        newCollider.size = mainCollider.size + new Vector2(Range, 0);
        newCollider.offset =  Vector2.left * newCollider.size.x / 2;
        newCollider.isTrigger = true;
        boxCollider = newCollider;
    }
}
