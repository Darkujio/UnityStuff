using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSelfCast : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }

}
