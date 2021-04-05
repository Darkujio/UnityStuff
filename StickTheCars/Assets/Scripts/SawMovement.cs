using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SawMovement : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float SawSpeed = 2f;
    private Vector3 CurrentDir;
    private Vector3 targetPosition;
    private Vector3 desiredVelocity;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = pos2.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionalVector = (targetPosition - gameObject.GetComponent<Transform>().position).normalized * SawSpeed;
        if (Math.Abs(targetPosition.z - gameObject.GetComponent<Transform>().position.z) < 0.1f){
            if (targetPosition == pos2.position){
            targetPosition = pos1.position;
            }
            else
            targetPosition = pos2.position;
            desiredVelocity = Vector3.zero;
        }
        else {
            desiredVelocity = directionalVector;
        }
    }
    void FixedUpdate() 
    {
        gameObject.GetComponent<Rigidbody>().velocity = desiredVelocity;
    }
}
