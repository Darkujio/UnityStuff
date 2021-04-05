using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunForward : MonoBehaviour
{
    public float ForwardSpeed;
    private Rigidbody SelfRb;
    private PlankFall PlankFall;
    void Start()
    {
        FindObjectOfType<PlankFall>().Fall += FallTime;
        SelfRb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        SelfRb.velocity = new Vector3(SelfRb.velocity.x, SelfRb.velocity.y, ForwardSpeed);
    }

    void FallTime()
    {
        ForwardSpeed = 0f;
        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(this);
    }
}
