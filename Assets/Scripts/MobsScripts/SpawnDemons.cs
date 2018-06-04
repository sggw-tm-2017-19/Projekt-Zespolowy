﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemons : MonoBehaviour {

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject lesserDemonPrefab;
    public float coolDown;

    private List<Transform> spawnPoints=new List<Transform>();
    // Use this for initialization
    void Start () {
        spawnPoints.Add(spawnPoint1);
        spawnPoints.Add(spawnPoint2);
        spawnPoints.Add(spawnPoint3);
        StartCoroutine(spawnDemons());
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator spawnDemons()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolDown);
            spawnPoints.ForEach(sp => Instantiate(lesserDemonPrefab, sp.position,sp.rotation));

        }

    }
}
