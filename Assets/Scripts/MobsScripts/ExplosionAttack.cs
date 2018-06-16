using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ExplosionAttack : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public float Range;
    public float MinRange;
    public float Cooldown;
    public float MinDistanceFromPlayer;
    public float MaxDistanceFromPlayer;
    public string Trigger;

    private GameObject player;
    private Vector3 pointOfExplosion;
    private Animator animator;
    private float timeCount=0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance>=MinRange && distance <= Range && timeCount>=Cooldown)
        {
            Actions player = this.player.GetComponent<Actions>();
            if (player.IsGrounded)
            {
            setPointOfExplosion();
            Attack();
            }
            timeCount = 0;

        }
        timeCount += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger(Trigger);
        float distanceFromPlayer = Random.Range(MinDistanceFromPlayer, MaxDistanceFromPlayer);
        float side = Mathf.Round(Random.value) == 0 ? -1 : 1;
        pointOfExplosion += distanceFromPlayer * side * Vector3.right;
        GameObject explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = pointOfExplosion;
    }

    private void setPointOfExplosion()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 feetColliderOffset = player.GetComponent<CircleCollider2D>().offset;
        pointOfExplosion = (Vector3)(playerPosition + feetColliderOffset) + Vector3.back;
    }
}
