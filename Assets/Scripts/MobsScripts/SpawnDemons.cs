using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemons : MonoBehaviour {

    const string trigger = "SummonDemons";

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject lesserDemonPrefab;
    public float coolDown;
    public float Range;
    
    private List<Transform> spawnPoints=new List<Transform>();
    private GameObject player;
    private Animator animator;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
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
            float distance = (player.transform.position - gameObject.transform.position).magnitude;
            if (distance <= Range)
            {
                animator.SetTrigger(trigger);
                spawnPoints.ForEach(sp => Instantiate(lesserDemonPrefab, sp.position, sp.rotation));
            }
        }

    }
}
