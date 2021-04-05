using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Touch : MonoBehaviour
{
    private GameObject CarToMove;
    private Vector3 TouchPos;
    private bool MovPossible = true;
    public float CameraAngle = 45f;

    void Start()
    {
        foreach (Move Move in GameObject.FindObjectsOfType<Move>())
        {
            Move.LockMove += MovePossibleFalse;
        }
        foreach (Enteraction Enteraction in GameObject.FindObjectsOfType<Enteraction>())
        {
            Enteraction.MayStart += MovePossibleTrue;
        }
        foreach (GetAway GetAway in GameObject.FindObjectsOfType<GetAway>())
        {
            GetAway.MayStart += MovePossibleTrue;
        }
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
            else if (Input.GetMouseButtonUp(0))
            {
                checkStop(Input.mousePosition);
            }
        }
    }

    private void checkTouch(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        int layerMask = 1 << 8;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask)){
            CarToMove = hit.collider.gameObject;
            TouchPos = pos;
        }
    }

    private void MovePossibleFalse()
    {
        MovPossible = false;
    }

    private void MovePossibleTrue()
    {
        MovPossible = true;
    }

    private void checkStop(Vector3 pos)
    {
        if (CarToMove != null && MovPossible)
        {
            Vector3 MoveVectorOnScreen =pos - TouchPos;
            //Debug.DrawRay(new Vector3(0,5f,0f), MoveVectorOnScreen, Color.green, 5, false);
            Vector2 MoveVector = Rotate(new Vector2(MoveVectorOnScreen.x, MoveVectorOnScreen.y), CameraAngle);
            //Debug.DrawRay(new Vector3(0,5f,0f), MoveVector, Color.red, 5, false);
            if (Math.Abs(MoveVector.x) > Math.Abs(MoveVector.y))
            {
                if (MoveVector.x < 0)
                {
                    CarToMove.GetComponent<Move>().StartMove(new Vector3(0,0,-1f));
                }
                else
                { //
                    CarToMove.GetComponent<Move>().StartMove(new Vector3(0,0,1f));
                }
            }
            else
            {
                if (MoveVector.y < 0)
                { //Down
                    CarToMove.GetComponent<Move>().StartMove(new Vector3(1f,0,0));
                }
                else
                { //Up
                    CarToMove.GetComponent<Move>().StartMove(new Vector3(-1f,0,0));
                }
            }
        }
    }

    private Vector2 Rotate(Vector2 v, float degrees) 
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
        
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
