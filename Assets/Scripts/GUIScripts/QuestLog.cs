﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = GlobalControl.Instance.qLog;
	}
}
