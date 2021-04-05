using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Move Move;
    public Enteraction Enteraction;
    public BoxCollider MoveCollider;
    public BoxCollider StillCollider;
    void Start()
    {
        Move.StartingMovement+=ChangeColliderToMove;
        Enteraction.Collided+=ChangeColliderToStill;
    }
    void ChangeColliderToMove()
    {
        MoveCollider.enabled = true;
        StillCollider.enabled = false;
    }
    void ChangeColliderToStill()
    {
        MoveCollider.enabled = false;
        StillCollider.enabled = true;
    }
}
