using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCounterController : MonoBehaviour {
    Text content;
    public RigidController rigit;

	// Use this for initialization
	void Start () {
        content = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        content.text = rigit.HP>0? rigit.HP + @"/" + rigit.MaxHP: "Player is dead!";
	}
}
