using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour {

    GameObject Player;
    int next;

// Use this for initialization
void Start ()
    {
        Player = GameObject.Find("Player");
        next = 0;
	}

    public void Test()
    {
        Player.GetComponent<Moving>().CanWalk = false;
        switch (name)
        {
            case "Królowa":
                switch (next)
                {
                    case 0:
                        Debug.Log("Nazywam się " + name.ToString() + ". Witaj " + Player.name);
                        break;
                    case 1:
                        Debug.Log("Mam dla Ciebie zadanie.");
                        break;
                    case 2:
                        Debug.Log("blabla");
                        break;
                    default:
                        Player.GetComponent<Moving>().CanWalk = true;
                        next = -1;
                        break;
                }
                break;
            case "RandomNPC":
                switch (next)
                {
                    case 0:
                        Debug.Log("Odczep się, nie chce z Tobą gadać");
                        break;
                    default:
                        Player.GetComponent<Moving>().CanWalk = true;
                        next = -1;
                        break;
                }
                break;
            default:
                break;
        }
        next++;
    }
}

