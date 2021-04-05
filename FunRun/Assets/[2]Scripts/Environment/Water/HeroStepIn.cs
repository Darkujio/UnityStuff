using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HeroStepIn : MonoBehaviour
{
    public Action StepInWater;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 10)
        {
            StepInWater?.Invoke();
        }
    }
}
