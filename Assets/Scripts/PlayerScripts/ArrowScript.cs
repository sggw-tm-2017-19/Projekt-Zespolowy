using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    private float arrowSpeed;
    private CapsuleCollider2D AttackCollider;

    private List<GameObject> enemies = new List<GameObject>();
    private GameObject player;

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

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        AttackCollider = GetComponent<CapsuleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(ArrowSpeed, 0);
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
                Damage(other.gameObject);
            }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 11) enemies.Remove(other.gameObject);
    }

    void Damage(GameObject enemy)
    {
        enemy.GetComponent<MobController>().Attacked(player.GetComponent<PlayerStats>().Damage);
        Debug.Log(enemy.GetComponent<MobStats>().HealthPoints);
    }
}
