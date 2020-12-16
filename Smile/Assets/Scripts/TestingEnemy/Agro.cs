using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Agro : MonoBehaviour
{
    private GameObject MainHeroObj;
    private GameObject Self;
    private float speed;
    private Rigidbody2D RBSelf;
    void Awake()
    {
        MainHeroObj = GameObject.Find("MainHeroObj");
        RBSelf = gameObject.GetComponent<Rigidbody2D>();
        Stats TestStats = GetComponent<Stats>();
        speed = TestStats.speed;
    }
    void FixedUpdate()
    {
        Vector3 SelfV = gameObject.transform.position;
        Vector3 Target = MainHeroObj.transform.position;
        Vector3 velocity = Target - SelfV;
        float VelocityLength = Convert.ToSingle(Math.Sqrt(velocity.x*velocity.x + velocity.y*velocity.y));
        velocity.x = velocity.x / VelocityLength;
        velocity.y = velocity.y / VelocityLength;
        if ((Math.Sqrt((Target.x-SelfV.x)*(Target.x-SelfV.x)+(Target.y-SelfV.y)*(Target.y-SelfV.y))<10))
        {
            RBSelf.velocity = new Vector2(velocity.x * speed, velocity.y * speed);
        }
        else
        {
            RBSelf.velocity = new Vector2( 0 , 0 );
        }
    }
}
