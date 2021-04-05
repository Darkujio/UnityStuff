using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private float TouchPoint;
    private RunSide RunSide;
    private void Start()
    {
        RunSide = FindObjectOfType<RunSide>();  
    }
    void Update(){
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    checkMove(Input.GetTouch(0).position);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    checkStop(Input.GetTouch(0).position);
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                checkMove(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                checkStop(Input.mousePosition);
            }
        }
    }

    private void checkTouch(Vector3 Pos)
    {
        TouchPoint = Pos.x;
    }
    private void checkMove(Vector3 Pos)
    {
        float MovePower = Pos.x - TouchPoint;
        if (MovePower > Screen.width/4) MovePower = Screen.width/4;
        if (MovePower < -Screen.width/4) MovePower = -Screen.width/4;
        float MovePowerNormalized = ((MovePower - Screen.width/4)/(Screen.width/4)) + 1f;
        if (Math.Abs(MovePowerNormalized)< 0.2f) MovePowerNormalized = 0;
        RunSide.RunToSide(MovePowerNormalized);
    }
    private void checkStop(Vector3 Pos)
    {
        RunSide.RunToSide(0f);
    }
}
