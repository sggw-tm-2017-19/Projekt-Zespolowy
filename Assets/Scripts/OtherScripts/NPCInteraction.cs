using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour {

    GameObject Player;
    GameObject Blacksmith;
    public Text dialogueText;
    public GameObject dialogueManager;
    int straznikl;//straznik wioska ludzi dialog
    int straznike;//straznik wioska elfow dialog
    int krolowa;//krolowa elfow dialog
    int starszy;//starszy wioski dialog
    int randomnpc = 0;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        Blacksmith = GameObject.Find("BlacksmithInventory");
        straznikl = 0;
        straznike = 0;
        krolowa = 0;
        starszy = 0;
	}

    public void Test()
    {
        Player.GetComponent<Actions>().CanWalk = false;
        dialogueManager.SetActive(true);

        switch (name)
        {
            case "StraznikCzlowiek":
                switch (straznikl)
                {
                    case 0://przed pierwszym bossem
                        dialogueText.text = "Not now " + Player.name.ToString() + ", we need to fight off the demons first!";
                        straznikl = -2;
                        break;
                    case 10://po pierwszym bossie
                        dialogueText.text = "Ah, " + Player.name.ToString() + ", do you need something?";
                        break;
                    case 11:
                        dialogueText.text = "I am sorry about your brother. I hope you can find and rescue him from the demons.";
                        break;
                    case 12:
                        dialogueText.text = "You are going now? Farewell and good luck then.";
                        straznikl = 13;
                        break;
                    case 15:
                        dialogueText.text = "Show these demons what you can do!";
                        straznikl = 13;
                        break;
                    case 20://po ostatnim bossie
                        dialogueText.text = "You have saved not only your brother, but also us all.";
                        break;
                    case 21:
                        dialogueText.text = "Thank you for this, " + Player.name.ToString() + ".";
                        break;
                    case 22:
                        dialogueText.text = "I'll see you later, " + Player.name.ToString() + ".";
                        straznikl = 23;
                        break;
                    case 25:
                        dialogueText.text = "Do you need something, " + Player.name.ToString() + "?";
                        straznikl = 23;
                        break;
                    default:
                        Player.GetComponent<Actions>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        break;
                }
                straznikl++;
                break;
            case "StraznikElf":
                switch (straznike)
                {
                    case 0://dialog startowy
                        dialogueText.text = "Not now human, the city needs your help!";
                        straznike = -2;
                        break;
                    case 10://po pokonaniu drugiego bossa
                        dialogueText.text = "Thank you for your help with the demons, human.";
                        break;
                    case 11:
                        dialogueText.text = "Now excuse me, but if you need nothing more from me then I shall excuse you.";
                        break;
                    case 12:
                        dialogueText.text = "Good fortune to you.";
                        straznike = 13;
                        break;
                    case 15:
                        dialogueText.text = "Yes?";
                        straznike = 13;
                        break;
                    case 20://po pokonaniu ostatniego bossa
                        dialogueText.text = "You have saved the world as we know it human, for that you have my utmost respect.";
                        straznike = 18;
                        break;
                    default:
                        Player.GetComponent<Actions>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        break;
                }
                straznike++;
                break;
            case "Królowa":
                switch (krolowa)
                {
                    case 0://startowy dialog
                        dialogueText.text = "What is it young woman? Our city is under attack if you haven't noticed.";
                        break;
                    case 1:
                        dialogueText.text = "You seek your brother abducted by the demons? I can help you if you help us.";
                        break;
                    case 2:
                        dialogueText.text = "Slay the demons assaulting us, and I will open you a portal to their realm.";                        
                        break;
                    case 3:
                        dialogueText.text = "May fortune favour you in the upcoming battle.";
                        krolowa = 4;
                        break;
                    case 6:
                        dialogueText.text = "What are you waiting for? Go slay the demon and save my city!";
                        krolowa = 4;
                        break;
                    case 10://po pokonaniu drugiego bossa
                        dialogueText.text = "Thank you for your help, girl. As promised I opened a portal for you. It leads to the Isle of Demons.";
                        break;
                    case 11:
                        dialogueText.text = "I wish you the best of luck, although if what my men said about your battle prowess is true, you shall not need it.";
                        break;
                    case 12:
                        dialogueText.text = "Farewell.";
                        krolowa = 13;
                        break;
                    case 15:
                        dialogueText.text = "Do you need anything else?";
                        krolowa = 13;
                        break;
                    case 20://po pokonaniu ostatniego bossa
                        dialogueText.text = "I have heard that you managed to save your brother and vanquish the forces of evil.";
                        break;
                    case 21:
                        dialogueText.text = "You have impressed me and done the world a great favour. We are all indebted to you.";
                        break;
                    case 22:
                        dialogueText.text = "May fortune smile upon you in your future endeavours and may your ventures always succeed, heroine.";
                        break;
                    case 23:
                        dialogueText.text = "Farewell.";
                        krolowa = 24;
                        break;
                    case 26:
                        dialogueText.text = "May fortune smile upon you in your future endeavours and may your ventures always succeed, heroine.";
                        break;
                    case 27:
                        dialogueText.text = "Farewell.";
                        krolowa = 24;
                        break;
                    default:
                        Player.GetComponent<Actions>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        break;
                }
                krolowa++;
                break;
            case "StarszyWioski":
                switch (starszy)
                {
                    case 0://pierwszy dialog
                        dialogueText.text = "Ah, it's you " + Player.name.ToString() + "! We need your help, the village is being attacked by demons!";
                        break;
                    case 1:
                        dialogueText.text = "The guards said they have captured your brother!";
                        break;
                    case 2:
                        dialogueText.text = "Please help us defend the village and save your brother!";
                        starszy = 3;
                        break;
                    case 5:
                        dialogueText.text = "There is no time to waste! Hurry to the battlefield!";
                        starszy = 3;
                        break;
                    case 10://po pierwszym bossie
                        dialogueText.text = "You managed to drive the demons back? I am so glad.";
                        break;
                    case 11:
                        dialogueText.text = "They kidnapped your brother?! I am so sorry" + Player.name.ToString()+".";
                        break;
                    case 12:
                        dialogueText.text = "You are going after them to rescue your brother?!";
                        break;
                    case 13:
                        dialogueText.text = "You are very brave! I wish you luck on your journey, it will not be easy...";
                        break;
                    case 14:
                        dialogueText.text = "Take care of yourself!";
                        starszy = 15;
                        break;
                    case 17:
                        dialogueText.text = "Good luck, " + Player.name.ToString() + ".";
                        starszy = 15;
                        break;
                    case 20://po pokonaniu ostatniego bossa
                        dialogueText.text = "You saved your brother and us all...";
                        break;
                    case 21:
                        dialogueText.text = "We are all grateful and proud of you," + Player.name.ToString()+".";
                        break;
                    case 22:
                        dialogueText.text = "Thank you in the name of the whole village, you honour us all.";
                        starszy = 23;
                        break;
                    case 25:
                        dialogueText.text = "Thank you again, " + Player.name.ToString() + ".";
                        starszy = 23;
                        break;
                    default:
                        Player.GetComponent<Actions>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        break;
                }
                starszy++;
                break;
            case "RandomNPC":
                switch (randomnpc)
                {
                    case 0:
                        dialogueText.text = "Odczep się, nie chce z Tobą gadać";
                        break;
                    default:
                        Player.GetComponent<Actions>().CanWalk = true;
                        dialogueManager.SetActive(false);
                        break;
                }
                randomnpc++;
                break;
            case "Kowal":
                Blacksmith.SetActive(true);
                dialogueManager.SetActive(false);
                break;
            default:
                break;
        }
    }
}

