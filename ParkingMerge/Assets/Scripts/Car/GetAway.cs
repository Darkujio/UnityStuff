using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetAway : MonoBehaviour
{
    public float TurnSpeed = 2f;
    public float OutSpeed = 5f;
    public float TurnDistance = 0.5f;
    public Action MayStart;
    public Action CarAway;

    private bool LeftForward = false;
    private bool LeftBackWards = false;
    private bool RightForward = false;
    private bool RightBackWards = false;
    private bool UpForward = false;
    private bool UpBackWards = false;
    private bool DownForward = false;
    private bool DownBackWards = false;

    private Vector3 TargetPos;
    private Vector3 ContactPoint;
    private float Radius;
    private Vector3 Middle;
    private Vector3 EndPoint;
    private bool UnTurning = true;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            CarAway?.Invoke();
            MayStart?.Invoke();
            float DistancePointer = Vector3.Distance(col.gameObject.transform.position , gameObject.transform.GetChild(2).transform.position);
            float DistanceSelf = Vector3.Distance(col.gameObject.transform.position , gameObject.transform.position);
            Vector3 MoveVector = gameObject.transform.GetChild(2).transform.position - gameObject.transform.position;

            if (DistancePointer < DistanceSelf) //Forward
            {
                if (Math.Abs(MoveVector.x) < Math.Abs(MoveVector.z)) //Horizontal
                {
                    if (MoveVector.z < 0) //Left
                    {
                        TargetPos = new Vector3(transform.position.x,transform.position.y,col.gameObject.transform.GetChild(0).transform.position.z);
                        LeftForward = true;
                    }
                    else //Right
                    {
                        TargetPos = new Vector3(transform.position.x,transform.position.y,col.gameObject.transform.GetChild(0).transform.position.z);
                        RightForward = true;
                    }
                }
                else //Vertical
                {
                    if (MoveVector.x < 0) //Up
                    {
                        TargetPos = new Vector3(col.gameObject.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z);
                        UpForward = true;
                    }
                    else //Down
                    {
                        TargetPos = new Vector3(col.gameObject.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z);
                        DownForward = true;
                    }
                }

            }
            else //Backwards
            {
                if (Math.Abs(MoveVector.x) < Math.Abs(MoveVector.z)) //Horizontal
                {
                    if (MoveVector.z > 0) //Left
                    {
                        TargetPos = new Vector3(transform.position.x,transform.position.y,col.gameObject.transform.GetChild(0).transform.position.z);
                        LeftBackWards = true;
                    }
                    else //Right
                    {
                        TargetPos = new Vector3(transform.position.x,transform.position.y,col.gameObject.transform.GetChild(0).transform.position.z);
                        RightBackWards = true;
                    }
                }
                else //Vertical
                {
                    if (MoveVector.x > 0) //Up
                    {
                        TargetPos = new Vector3(col.gameObject.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z);
                        UpBackWards = true;
                    }
                    else //Down
                    {
                        TargetPos = new Vector3(col.gameObject.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z);
                        DownForward = true;
                    }
                }
            }
        }
    }
    void Update()
    {
        if (LeftForward) LeftForwardMethod();
        if (LeftBackWards) LeftBackWardsMethod();

        if (UpForward) UpForwardMethod();
        if (UpBackWards) UpBackWardsMethod();

        if (RightForward) RightForwardMethod();
        if (RightBackWards) RightBackWardsMethod();

        if (DownForward) DownForwardMethod();
        if (DownBackWards) DownBackWardsMethod();
        
    }
    private void LeftForwardMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x - Radius, pos.y, pos.z);
            EndPoint = Middle + new Vector3(0f,0f,-Radius);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,270f,0f);
                UnTurning = true;
                LeftForward = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }
    private void LeftBackWardsMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x + Radius, pos.y, pos.z);
            EndPoint = Middle + new Vector3(0f,0f,-Radius);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,-TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,270f,0f);
                UnTurning = true;
                LeftBackWards = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }

    private void UpBackWardsMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x, pos.y, pos.z - Radius);
            EndPoint = Middle + new Vector3(-Radius,0f,0f);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,-TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                UnTurning = true;
                UpBackWards = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }
    private void UpForwardMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x, pos.y, pos.z + Radius);
            EndPoint = Middle + new Vector3(-Radius,0f,0f);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                UnTurning = true;
                UpForward = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }

    private void RightForwardMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x + Radius, pos.y, pos.z);
            EndPoint = Middle + new Vector3(0f,0f,+Radius);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,90f,0f);
                UnTurning = true;
                RightForward = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }
    private void RightBackWardsMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x - Radius, pos.y, pos.z);
            EndPoint = Middle + new Vector3(0f,0f,+Radius);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,-TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,90f,0f);
                UnTurning = true;
                RightBackWards = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }

    private void DownBackWardsMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x, pos.y, pos.z + Radius);
            EndPoint = Middle + new Vector3(+Radius,0f,0f);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,-TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,180f,0f);
                UnTurning = true;
                DownBackWards = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }
    private void DownForwardMethod()
    {
        if (Vector3.Distance(transform.position,TargetPos) < TurnDistance && UnTurning)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 pos = transform.position;
            float Radius = Vector3.Distance(pos,TargetPos);

            Middle = new Vector3(pos.x, pos.y, pos.z - Radius);
            EndPoint = Middle + new Vector3(+Radius,0f,0f);

            UnTurning = false;
        }
        if (!UnTurning)
        {
            transform.RotateAround(Middle,Vector3.up,TurnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position , EndPoint) < 0.02f)
            {
                transform.rotation = Quaternion.Euler(0f,180f,0f);
                UnTurning = true;
                DownForward = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
        }
    }
}
