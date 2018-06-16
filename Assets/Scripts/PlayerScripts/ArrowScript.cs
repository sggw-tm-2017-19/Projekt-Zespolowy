using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    private float arrowSpeed;

    private List<GameObject> Enemies = new List<GameObject>();
    private PlayerStats playerStats;

    Rigidbody2D rb;

    public float ArrowSpeed
    {
        get
        {
            return arrowSpeed;
        }

        set
        {
            arrowSpeed = value;
        }
    }
    public void RemoveFromEnemies(GameObject enemy)
    {
        if (Enemies.Contains(enemy))
            Enemies.Remove(enemy);
    }

    // Use this for initialization
    void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(ArrowSpeed, 0);
        Destroy(gameObject, 0.5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            if (!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
                DealDamage(other.gameObject);
            }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") Enemies.Remove(other.gameObject);
    }

    void DealDamage(GameObject enemy)
    {
        int damage = playerStats.Damage /2;
        enemy.GetComponent<MobStats>().HealthPointsDown(damage);
        if (enemy.GetComponent<MobStats>().HealthPoints <= 0)
        {
            Enemies.Remove(enemy);
        }
    }
}
