using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHero : MonoBehaviour
{
    public Transform MainHero;
    private Vector3 BasePos;
    void Start()
    {
        BasePos = transform.position;
        FindObjectOfType<StepInWaterReac>().StopCamera += Stop;
    }

    void Update()
    {
        transform.position = BasePos + new Vector3(0,0,MainHero.transform.position.z);
        if (transform.position.z > 90)
        transform.position = BasePos + new Vector3(0,0,97);
    }
    void Stop()
    {
        Destroy(this);
    }


}
