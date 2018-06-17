using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsUI : MonoBehaviour {

    public Text Sword;
    public Text StrongSword;
    public Text Bow;
    public Text Dash;
    public Text Heal;

    // Update is called once per frame
    void Update ()
    {
        int Damage = GlobalControl.Instance.Player.GetComponent<PlayerStats>().Damage;
        int MaxHP = GlobalControl.Instance.Player.GetComponent<PlayerStats>().MaxHP;
        decimal AS = GlobalControl.Instance.Player.GetComponent<PlayerStats>().AttackSpeed;
        decimal MS = GlobalControl.Instance.Player.GetComponent<PlayerStats>().MoveSpeed;
        Sword.text = "Sword Attack(Z) - Attacks with a sword to deal " + Damage + " damage. Cd:" + ((3 - AS < 0.3m) ? 0.3m : (3 - AS)) + "s";
        StrongSword.text = "Strong Attack(X) - Swings a sword to stun enemies for a brief moment and deals " + Damage*2 + " damage. Cd:" + ((11 - AS < 2m) ? 2m : (11 - AS)) + "s";
        Bow.text = "Bow Attack(C) - Shoots an arrow that goes through enemies and deals " + Damage / 3 * 2 + " damage. Cd:" + ((5 - AS < 1m) ? 1m : (5 - AS)) + "s";
        Dash.text = "Dash(V) - Dashes in faced direction and leaves a fire behind that deals " + Damage/5 + " dmg to enemies. Cd:" + ((20 - MS < 5m) ? 5m : (20 - MS)) + "s";
        Heal.text = "Heal(B) - Heals yourself for 20% of your maximum HP(" + MaxHP/5 + "). Cd:" + ((30 - AS < 5m) ? 5m : (30 - AS)) + "s";
    }
}
