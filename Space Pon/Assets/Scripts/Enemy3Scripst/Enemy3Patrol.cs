using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy3Patrol : MonoBehaviour
{
    [Range(2, 100f)] [SerializeField] private float PatrolDirChange = 2f;
    [Range(0, 10f)] [SerializeField] private float AgroRadius = 1.5f;
    public Transform MainHeroObj;
    public Enemy3Controll controller;

    private bool Patrol = true;
    private bool Agro = false;

    //Agro
    private float AgroTimer = 10f;

    //Patrol
    private float NextPatrol;
    public float DirectionOfPatrol = 1f;


    void Start()
    {
        MainHeroObj = GameObject.Find("MainHeroObj").transform;
    }
    void Update()
    {
        //RandomPatrolTime
        NextPatrol -= Time.deltaTime;
        if (NextPatrol < 0)
        {
            //print("changed dir!");
            DirectionOfPatrol = -DirectionOfPatrol;
            NextPatrol = UnityEngine.Random.Range(2f, PatrolDirChange);
        }
        //END

        //Rayacast check for Agro
        int layer_mask = ~LayerMask.GetMask("Enemy");
        Vector2 HeroPosVec = new Vector2( MainHeroObj.position.x-transform.position.x , MainHeroObj.position.y - transform.position.y);
        RaycastHit2D HeroHit = Physics2D.Raycast(transform.position, HeroPosVec, AgroRadius, layer_mask);
        //print(HeroHit.rigidbody);
        if (Physics2D.Raycast(transform.position, HeroPosVec, AgroRadius, layer_mask))
        {
            if (HeroHit.rigidbody.gameObject.name == "MainHeroObj")
            {
                //Debug.DrawRay(transform.position,  HeroPosVec , Color.yellow);
                //Debug.DrawRay(transform.position, Vector2.right, Color.yellow);
                SetAgro();
            }
        }

        //End of AgroCheck

        AgroTimer += Time.deltaTime;
        if (AgroTimer > 1f) DisposeAgro();

    }

    void SetAgro()
    {
        AgroTimer = 0f;
        Agro = true;
        Patrol = false;
    }

    void DisposeAgro()
    {
        Agro = false;
        Patrol = true;
    }

    void FixedUpdate()
    {

        if (Patrol) controller.Move(DirectionOfPatrol);
        if (Agro) controller.Move((MainHeroObj.position.x-transform.position.x) / Math.Abs(MainHeroObj.position.x-transform.position.x));
        controller.ObeyGravity();
    }
}
