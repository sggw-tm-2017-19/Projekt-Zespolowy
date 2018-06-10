using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndKick : MonoBehaviour {

    public Transform pointOfPulling;
    public float damage;
    public float kickForce;
    public float pullingSpeed;
    public float CoolDown;

    private bool isLocked = false;
    private GameObject player;
    private float timeCounter = 0;

    private Vector2 PlayerPosition { get { return player.transform.position; } set { player.transform.position = value; } }
    private Vector2 POPPosition { get { return pointOfPulling.position; } }

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocked && timeCounter >= CoolDown)
        {
            timeCounter = 0;
            StartCoroutine(Pull());
            //StartCoroutine(Kick());
        }
        timeCounter += Time.deltaTime;
	}

    private IEnumerator Kick()
    {
        throw new NotImplementedException();
    }



    private IEnumerator Pull()
    {
        Debug.Log("Pulling");
        isLocked = true;
        Vector2 step = pullingSpeed == 0 ? Vector2.zero : Vector2.Lerp(PlayerPosition, POPPosition, 1 / pullingSpeed);
        yield return new WaitUntil(() => PlayerPosition == POPPosition);
        PlayerPosition += step;
    }
}
