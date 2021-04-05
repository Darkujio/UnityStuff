using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccPoint : MonoBehaviour
{   
    public float SuccSpeed;
    void Update()
    {
        transform.localScale = transform.localScale*SuccSpeed;
        if (transform.localScale.x < 0.01) 
        {
            gameObject.transform.parent.GetComponent<Grow>().GrowUp();
            Destroy(gameObject);
        }
    }
}
