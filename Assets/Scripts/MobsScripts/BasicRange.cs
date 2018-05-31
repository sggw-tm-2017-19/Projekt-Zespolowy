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

    private BoxCollider2D boxCollider;
    private float timeCount = 0;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        setColliderSize();

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
        Vector2 direction = player.transform.position - ProjectileStartPoint.position;
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = ProjectileStartPoint.position;
        projectile.SendMessage("setDirection", direction);
    }

    void setColliderSize()
    {
        boxCollider.size += new Vector2(Range / 2, 0);
        boxCollider.offset -= new Vector2(Range / 2, 0);
    }
}
