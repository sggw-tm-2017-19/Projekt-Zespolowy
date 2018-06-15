using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Image>().fillAmount = (float)GetComponentInParent<MobStats>().HealthPoints / GetComponentInParent<MobStats>().MaxHP;
    }
}
