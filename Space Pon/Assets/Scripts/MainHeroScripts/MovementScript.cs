using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float MaxDashTime;
    public float DashMoveTime = 0.25f;
    public float DashSpeed = 5f;
    public CharacterController2D controller;
    public Animator anim;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private float DashTime;
    private bool DashGo = false;

    void Update () 
    {
        //DASH
        DashTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) & (DashTime > MaxDashTime))
        {
            anim.SetBool("Dash", true);
            DashGo = true;
            DashTime = 0f;
        }
        //END OF DASH
        horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetAxisRaw("Horizontal")!=0)
        {
            anim.SetBool("Running", true);
        }
        else anim.SetBool("Running", false);
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (!CharacterController2D.m_Grounded)
        {
            anim.SetBool("Jump", true);
        }
        else anim.SetBool("Jump", false);
    } 
    void FixedUpdate ()
    {
        // Move our character
        if (!DashGo)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump, false);
            jump = false;
        }
        if (DashGo)
        {
            controller.Dash();
            if (DashTime>DashMoveTime)
            {
                DashGo = false;
            }
        }
    }
}
