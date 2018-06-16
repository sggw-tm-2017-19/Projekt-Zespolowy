using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private enum Scenes { Wioska, Elfy, Mapa }
    private enum Maps { Miasto, Mapa1_1, Mapa1, Mapa2_1, Mapa2, Mapa3_1, Mapa3}
    [SerializeField]
    private Scenes destination;
    [SerializeField]
    private Maps mapa;
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
            if (destination.ToString() != "Mapa")
            {
                GlobalControl.Instance.previousVisitedCity = destination.ToString();
                SceneManager.LoadScene(destination.ToString());
            }
            else
            {
                    SceneManager.LoadScene(mapa.ToString());
            }
        }
    }
}
