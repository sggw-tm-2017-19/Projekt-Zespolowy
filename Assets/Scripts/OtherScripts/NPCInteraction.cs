using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour {

    GameObject Player;
    public Text dialogueText;
    public GameObject dialogueManager;
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
        dialogueManager.SetActive(true);

        switch (name)
        {
            case "Królowa":
                switch (next)
                {
                    case 0:
                        dialogueText.text = "Nazywam się " + name.ToString() + ". Witaj " + Player.name;
                        break;
                    case 1:
                        dialogueText.text = "Mam dla Ciebie zadanie.";
                        break;
                    case 2:
                        dialogueText.text = "blabla";
                        break;
                    default:
                        Player.GetComponent<Moving>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        next = -1;
                        break;
                }
                break;
            case "RandomNPC":
                switch (next)
                {
                    case 0:
                        dialogueText.text = "Odczep się, nie chce z Tobą gadać";
                        break;
                    default:
                        Player.GetComponent<Moving>().CanWalk = true;
                        dialogueManager.SetActive(false);
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

