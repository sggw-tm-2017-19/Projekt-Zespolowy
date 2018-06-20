using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcus : MonoBehaviour {

    public GameObject MiniMap;
    public GameObject IngameMenu;
    public GameObject Stats;
    public GameObject Questlog;
    public GameObject Inventory;
    public GameObject Spells;
    public GameObject Profile;

	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
        {
            if(MiniMap.activeSelf)
            {
                MiniMap.SetActive(false);
            }
            else
            {
                MiniMap.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Questlog.activeSelf)
            {
                Questlog.SetActive(false);
            }
            else
            {
                Questlog.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IngameMenu.activeSelf)
            {
                IngameMenu.SetActive(false);
            }
            else
            {
                IngameMenu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Stats.activeSelf && Inventory.activeSelf)
            {
                Stats.SetActive(false);
            }
            else
            {
                Stats.SetActive(true);
            }
            if(!Inventory.activeSelf)
            {
                Spells.SetActive(false);
                Profile.SetActive(false);
                Inventory.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Stats.activeSelf && Profile.activeSelf)
            {
                Stats.SetActive(false);
            }
            else
            {
                Stats.SetActive(true);
            }
            if (!Profile.activeSelf)
            {
                Spells.SetActive(false);
                Inventory.SetActive(false);
                Profile.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Stats.activeSelf && Spells.activeSelf)
            {
                Stats.SetActive(false);
            }
            else
            {
                Stats.SetActive(true);
            }
            if (!Spells.activeSelf)
            {
                Inventory.SetActive(false);
                Profile.SetActive(false);
                Spells.SetActive(true);
            }
        }
    }
}
