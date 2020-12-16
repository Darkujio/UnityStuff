using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTriggerScript : MonoBehaviour
{
    public ShootShot ShotScript;
    void TriggerShot()
    {
        ShotScript.CreateShot();
        gameObject.SetActive(false);
    }
}
