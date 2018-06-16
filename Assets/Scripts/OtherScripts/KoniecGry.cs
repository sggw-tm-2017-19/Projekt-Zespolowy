using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoniecGry : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
                SceneManager.LoadScene("KoniecGry");
        }
    }
}
