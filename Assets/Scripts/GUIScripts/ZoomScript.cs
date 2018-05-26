using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomScript : MonoBehaviour{

    public Camera miniMapCam;

    public void ZoomIn()
    {
        if (miniMapCam.orthographicSize >= 8)
        {
            miniMapCam.orthographicSize -= 2;
        }
    }
    public void ZoomOut()
    {
        if (miniMapCam.orthographicSize <= 30)
        {
            miniMapCam.orthographicSize += 2;
        }
    }
}
