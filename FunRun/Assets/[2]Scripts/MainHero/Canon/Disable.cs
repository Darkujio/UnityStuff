using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public void DisableObj()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}
