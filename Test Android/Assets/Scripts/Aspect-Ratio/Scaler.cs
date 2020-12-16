using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    void Start()
    {
        float targetaspect = 800f / 480f;

        float windowaspect = (float)900f / (float)1600f;
        //float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;
    }
}
