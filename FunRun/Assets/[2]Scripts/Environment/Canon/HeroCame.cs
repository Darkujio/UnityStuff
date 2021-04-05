using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCame : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 10)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            col.gameObject.GetComponent<Disable>()?.DisableObj();
            Destroy(FindObjectOfType<Touch>());
            Destroy(FindObjectOfType<RunForward>());
        }
    }
}
