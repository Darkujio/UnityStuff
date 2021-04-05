using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurn : MonoBehaviour
{
    public float TurnSpeed = 200f;
    public float OutSpeed = 9f;
    private float Radius;
    private Vector3 TargetPos;
    private Vector3 Middle;
    private Vector3 TurnPos;
    private Quaternion Rotation;
    private bool Turn = false;
    private bool Spinning = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            TurnPos = other.transform.position;
            Middle = other.transform.GetChild(1).position;
            TargetPos = other.transform.GetChild(0).position;
            Rotation = other.transform.rotation;
            Radius = 0.65f;
            Turn = true;
            Spinning = false;
        }
    }
    private void Update()
    {
        if (Turn) 
        {
            if (Vector3.Distance(transform.position, TurnPos) < Radius)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Spinning = true;
            }
            if (Spinning)
            {
                transform.RotateAround(Middle,Vector3.up,TurnSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position , TargetPos) < 0.05f && Spinning)
            {
                transform.rotation = Rotation * Quaternion.Euler(0,90f,0);
                transform.position = TargetPos;
                Spinning = false;
                Turn = false;
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * OutSpeed;
            }
            }
        }
    }
}
