using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public float Speed;
    public Enteraction Enteraction;
    public GameObject FixDir;
    public Action StartingMovement;
    public Action LockMove;
    private bool Moving;
    private Rigidbody rb;
    private Vector3 Direction;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Enteraction.Collided+=Stop;
    }
    public void StartMove(Vector3 OutDirection)
    {
        if (!Moving)
        {
            if (Math.Abs((FixDir.transform.position-transform.position).x) > 0.01f && Math.Abs(OutDirection.z) < 0.01f)
            {
                MoveInDir(OutDirection);
            }
            if (Math.Abs((FixDir.transform.position-transform.position).z) > 0.01f && Math.Abs(OutDirection.x) < 0.01f)
            {
                MoveInDir(OutDirection);
            }
        }
    }
    private void MoveInDir(Vector3 OutDirection)
    {
        StartingMovement?.Invoke();
        rb.isKinematic = false;
        Moving = true;
        LockMove?.Invoke();
        Direction = OutDirection;
        rb.velocity = Direction * Speed;
    }
    void Stop()
    {
        Moving = false;
        rb.isKinematic = true;
        rb.position = rb.position - Direction*0.05f;
        rb.velocity = Vector3.zero;
    }
}
