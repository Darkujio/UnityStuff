using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    public void OnAnimEnd()
    {
        Destroy(gameObject);
    }
}