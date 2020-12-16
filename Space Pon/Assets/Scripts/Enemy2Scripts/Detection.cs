using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detection : MonoBehaviour
{
    [SerializeField] private GameObject PlayerGameObj;
    [SerializeField] private PatrolBehavor Patrol;
    [SerializeField] private BoxCollider2D MainHeroCollieder1;
    [SerializeField] private PatrolBehavor MainHeroCollieder2;
    private Transform selfTrans;
    private Transform playerPos;


    void Start()
    {
        selfTrans = GetComponent<Transform>();
        playerPos = PlayerGameObj.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 Direction = new Vector2(playerPos.position.x - selfTrans.position.x , playerPos.position.y - selfTrans.position.y);
        LayerMask mask = LayerMask.GetMask("Player");
        mask += LayerMask.GetMask("StaticObjects");
        float DirectionLength = Convert.ToSingle(Math.Sqrt(Direction.x * Direction.x + Direction.y * Direction.y));
        RaycastHit2D hit = Physics2D.Raycast(selfTrans.position, Direction, Mathf.Infinity, mask);
        if ((hit.collider == MainHeroCollieder1 || hit.collider == MainHeroCollieder2) && hit.distance < 1)
        {
            print("Noticed");
            Patrol.Notice();
        }
        Debug.DrawRay(selfTrans.position, Direction, Color.green);
        Debug.DrawRay(selfTrans.position, new Vector2(Direction.x/DirectionLength , Direction.y/DirectionLength), Color.red);
    }
}
