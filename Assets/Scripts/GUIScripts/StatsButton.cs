using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsButton : MonoBehaviour {

    public GameObject plusIcon;

	// Update is called once per frame
	void Update ()
    {
		if(GlobalControl.Instance.Player.GetComponent<PlayerStats>().StatPoints!=0)
        {
            plusIcon.SetActive(true);
        }
        else
        {
            plusIcon.SetActive(false);
        }
	}
}
