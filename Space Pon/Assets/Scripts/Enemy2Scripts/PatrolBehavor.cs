using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolBehavor : MonoBehaviour
{
    private Rigidbody2D selfBody;
    //Patrol Variables
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;
    [SerializeField] private Enemy2Controlls controller;
    [SerializeField] private float Speed;
    const float CheckRadius = 0.01f;
    public bool Patroling = true;
    private bool MovTowardP1 = true;
    private Transform selfTrans;
    //End of Patrol Variables
    private bool NoticeHero = false;
    void Start()
    {
        selfTrans = GetComponent<Transform>();
        selfBody = GetComponent<Rigidbody2D>();
        selfBody.AddForce(new Vector2(0f,0.001f), ForceMode2D.Impulse);
    }

    public void Notice()
    {
        Patroling = false;
        NoticeHero = true;
    }

    void FixedUpdate()
    {
        if (Patroling)
        {
            if (MovTowardP1)
            {
                Vector2 MoveDir = new Vector2(Point1.position.x - selfTrans.position.x,Point1.position.y - selfTrans.position.y);
                float MoveDirLength = Convert.ToSingle(Math.Sqrt(MoveDir.x*MoveDir.x + MoveDir.y*MoveDir.y));
                Vector2 MoveDirFin = new Vector2(MoveDir.x / MoveDirLength, MoveDir.y / MoveDirLength);
                float MoveDirFinLength = Convert.ToSingle(Math.Sqrt(MoveDirFin.x*MoveDirFin.x + MoveDirFin.y*MoveDirFin.y));
                if (MoveDirLength>CheckRadius)
                {
                    controller.Move(MoveDirFin*Speed);
                }
                else MovTowardP1 = false;
            }
            if (!MovTowardP1)
            {
                Vector2 MoveDir = new Vector2(Point2.position.x - selfTrans.position.x,Point2.position.y - selfTrans.position.y);
                float MoveDirLength = Convert.ToSingle(Math.Sqrt(MoveDir.x*MoveDir.x + MoveDir.y*MoveDir.y));
                Vector2 MoveDirFin = new Vector2(MoveDir.x / MoveDirLength, MoveDir.y / MoveDirLength);
                float MoveDirFinLength = Convert.ToSingle(Math.Sqrt(MoveDirFin.x*MoveDirFin.x + MoveDirFin.y*MoveDirFin.y));
                if (MoveDirLength>CheckRadius)
                {
                    controller.Move(MoveDirFin*Speed);
                }
                else MovTowardP1 = true;
            }
        }

        if (NoticeHero)
        {
            selfBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
