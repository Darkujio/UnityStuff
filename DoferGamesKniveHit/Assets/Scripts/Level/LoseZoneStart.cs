using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZoneStart : MonoBehaviour
{
    public GameObject LogObject;

    private float TargetX = 0f;
    private float TargetY = -6f;
    void Start(){
        float angle = (Mathf.Atan2(0f - TargetY, 0f - TargetX ) * Mathf.Rad2Deg) - 90;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = targetRotation;
    }
}