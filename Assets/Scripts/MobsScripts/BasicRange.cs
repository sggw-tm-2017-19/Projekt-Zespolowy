using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRange : MonoBehaviour {
    public GameObject projectilePrefab;
    public float Cooldown;
    public int NumberOfProjectiles=1;
    public float Range;
    public Transform ProjectileStartPoint;
    
    
    private float timeCount = 0;
    private BoxCollider2D boxCollider;
	// Use this for initialization
	void Start () {
        setColliderSize();
	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "Player" && timeCount>=Cooldown && !GetComponent<MobStats>().Stun)
        {
            Attack(other);
            timeCount = 0;
        }
    }

    private void Attack(GameObject other)
    {
        Vector2 direction = GlobalControl.Instance.Player.transform.position - ProjectileStartPoint.position;
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = ProjectileStartPoint.position;
        projectile.SendMessage("setDirection", direction);
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
