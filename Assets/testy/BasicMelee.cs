using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMelee : MonoBehaviour {

    public float Damage;
    public float Cooldown;
    public float Range;

    public Dictionary<float, MonoBehaviour> testDic;
    

    private new BoxCollider2D collider;
    private GameObject player;
    private float timeCounter;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start () {
        timeCounter = Cooldown;
        SetColliderSize();
	}

    private void Update()
    {
        timeCounter+=Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject==player && timeCounter >= Cooldown)
        {
            StartCoroutine(Attack(other.gameObject));
            timeCounter %= Cooldown;
        }
    }

  



    private void SetColliderSize()
    {
        collider.size += new Vector2(Range, 0);
    }

        private IEnumerator Attack(GameObject gameObject)
    {
        transform.Rotate(new Vector3(0, 0, 15));
        gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(new Vector3(0, 0, -15));
    }

  
}
