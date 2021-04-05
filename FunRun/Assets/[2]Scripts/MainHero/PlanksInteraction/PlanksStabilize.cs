using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanksStabilize : MonoBehaviour
{
    private Rigidbody RB;
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RB != null)
        {
            //RB.velocity = RB.velocity 
        }
    }
}
