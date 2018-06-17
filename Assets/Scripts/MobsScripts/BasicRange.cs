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
    public float minRange;
    public Transform ProjectileStartPoint;
    public Vector2 direction;
    public string trigger;
    public int damage;
    
    
    private float timeCount = 0;
    private GameObject player;
    private MobStats mobStats;
    private Animator animator;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        mobStats = GetComponent<MobStats>();
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance<=Range && distance>minRange && timeCount>=Cooldown && !mobStats.Stun)
        {
            Attack(player);
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
	}
    

    private void Attack(GameObject other)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = ProjectileStartPoint.position;
        projectile.GetComponent<ProjectileScript>().damage = damage+GetComponent<MobStats>().Damage;

        if (trajectory == ProjectileTrajectory.ConstantDirection)
            projectile.SendMessage("setDirection", this.direction);
        else
        {
            Vector2 direction = player.transform.position - ProjectileStartPoint.position;
            projectile.SendMessage("setDirection",direction );
          }
        animator.SetTrigger(trigger);
    }
    
}
