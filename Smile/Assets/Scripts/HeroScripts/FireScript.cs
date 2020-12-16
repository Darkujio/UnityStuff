using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireScript : MonoBehaviour
{
    public GameObject ShotPrefab;
    public float ShotSpeed;
    public float FireRate;
    private bool FireReady;
    private float prevFire;
    private GameObject MainHeroObj;
    void Awake()
    {
        MainHeroObj = GameObject.Find("MainHeroObj");
        FireReady = true;
        prevFire = 0f;
    }
    void FixedUpdate()
    {
        Vector3 CurrentPos = MainHeroObj.transform.position;
        float Fire = Input.GetAxisRaw("Fire1");
        prevFire = prevFire + Time.deltaTime;
        if (prevFire >= FireRate) FireReady = true;
        if (Fire!=0)
            {
                if (FireReady)
                {
                    Vector3 Target =Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Target = Target - CurrentPos;
                    float TargetLength = Convert.ToSingle(Math.Sqrt(Target.x*Target.x + Target.y*Target.y));
                    Target.x = Target.x / TargetLength;
                    Target.y = Target.y / TargetLength;
                    GameObject Shot = Instantiate(ShotPrefab, CurrentPos, Quaternion.identity);
                    Rigidbody2D ShotBody = Shot.GetComponent<Rigidbody2D>();
                    ShotBody.AddForce(Target * ShotSpeed,ForceMode2D.Impulse);
                    Destroy(Shot, 2);
                    FireReady = false;
                    prevFire = 0f;
                }
            }
    }
}
