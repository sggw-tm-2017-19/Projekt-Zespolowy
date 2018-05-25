using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private enum Scenes { Test1, Wioska }
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
            GameObject.Find("Player").GetComponent<Moving>().SaveState();
            GlobalControl.Instance.posX = posX;
            GlobalControl.Instance.posY = posY;
            GlobalControl.Instance.posZ = GameObject.Find("Player").transform.position.z;
            SceneManager.LoadScene(destination.ToString());
        }
    }
}
