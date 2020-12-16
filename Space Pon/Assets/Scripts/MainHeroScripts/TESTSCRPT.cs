using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSCRPT : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxisRaw("Jump")!=0)
        {
            print(Input.GetAxisRaw("Jump"));
        }
    }
}
