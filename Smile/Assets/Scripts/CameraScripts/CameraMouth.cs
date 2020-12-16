using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMouth : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3F;
    
    private GameObject MainHeroObj;
    void Awake()
    {
        MainHeroObj = GameObject.Find("MainHeroObj");
    }
    void FixedUpdate()
    {
        Vector3 Target =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 CurrentPos = MainHeroObj.transform.position;
        Vector3 FinalTarget = Vector3.zero;
        FinalTarget.x = (Target.x + CurrentPos.x)/2.5f;
        FinalTarget.y = (Target.y + CurrentPos.y)/2.5f;
        FinalTarget.z = -10;
        CurrentPos.z = -10;
        if ((Math.Sqrt((Target.x-CurrentPos.x)*(Target.x-CurrentPos.x)+(Target.y-CurrentPos.y)*(Target.y-CurrentPos.y))>3))
        {  
            transform.position = Vector3.SmoothDamp(transform.position, FinalTarget, ref velocity, smoothTime);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, CurrentPos, ref velocity, smoothTime);
        }
    }
}
