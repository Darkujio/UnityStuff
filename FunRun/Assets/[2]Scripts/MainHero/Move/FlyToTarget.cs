using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlyToTarget : MonoBehaviour
{
    public float timer;
    public Action Shoot;
    private bool TimerStarter = false;
    void Start()
    {
        //FindObjectOfType<Shot>().Loaded += TimerStart;
    }

    void Update()
    {
        if (TimerStarter) 
        {
            //print(timer);
            timer -= Time.deltaTime;
            if (timer<0)
            {
                print("TimeUp");
                Shoot?.Invoke();
                Destroy(this);
            }
        }
    }

    public void TimerStart()
    {
        print("started");
        TimerStarter = true;
    }
}
