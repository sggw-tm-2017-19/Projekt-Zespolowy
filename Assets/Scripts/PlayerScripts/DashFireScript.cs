using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFireScript : MonoBehaviour {

    public float FireDuration;

    private List<GameObject> Enemies = new List<GameObject>();
    private PlayerStats playerStats;
    
    // Use this for initialization
    void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        StartCoroutine("DealDamage", Enemies);
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, FireDuration);
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            if (!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
            }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") Enemies.Remove(other.gameObject);
    }

    IEnumerator DealDamage(List<GameObject> enemies)
    {
        yield return new WaitForSeconds(0.9f);
        int damage = playerStats.Damage / 5;
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
                if (enemies[i].GetComponent<MobStats>().HealthPoints <= 0)
                {
                    Enemies.Remove(enemies[i]);
                }
            }
        }
    }
}
