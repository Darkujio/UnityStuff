using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSide : MonoBehaviour
{
    public float SideMaxSpeed;
    private Rigidbody SelfRb;
    void Start()
    {
        FindObjectOfType<PlankFall>().Fall += FallTime;
        SelfRb = gameObject.GetComponent<Rigidbody>();
    }
    public void RunToSide(float Speed)
    {
        SelfRb.velocity = new Vector3(Speed * SideMaxSpeed, SelfRb.velocity.y, SelfRb.velocity.z);
    }

    void FallTime()
    {
        SideMaxSpeed = 0f;
    }
}
