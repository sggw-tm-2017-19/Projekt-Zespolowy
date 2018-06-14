using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFireScript : MonoBehaviour {

    public float FireDuration;

    private List<GameObject> enemies = new List<GameObject>();
    private PlayerStats playerStats;
    
    // Use this for initialization
    void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        StartCoroutine("DealDamage", enemies);
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, FireDuration);
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
            }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") enemies.Remove(other.gameObject);
    }

    IEnumerator DealDamage(List<GameObject> enemies)
    {
        yield return new WaitForSeconds(1);
        int damage = playerStats.Damage / 25;
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<MobStats>().HealthPointsDown(damage);
                if (enemies[i].GetComponent<MobStats>().HealthPoints <= 0)
                {
                    Destroy(enemies[i].gameObject);
                    enemies.Remove(enemies[i]);
                    Attacks.Instance.RemoveFromEnemies(enemies[i]);
                    playerStats.CurrEXP += 100;
                    playerStats.Gold += 500;
                }
            }
        }
    }
}
