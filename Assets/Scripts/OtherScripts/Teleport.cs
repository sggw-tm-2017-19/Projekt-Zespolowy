using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private enum Scenes { Wioska, Mapa1, Mapa2 }
    [SerializeField]
    private Scenes destination;
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GlobalControl.Instance.Player.GetComponent<PlayerStats>().SaveState();
            GlobalControl.Instance.posX = posX;
            GlobalControl.Instance.posY = posY;
            GlobalControl.Instance.posZ = GlobalControl.Instance.Player.transform.position.z;
            SceneManager.LoadScene(destination.ToString());
        }
    }
}
