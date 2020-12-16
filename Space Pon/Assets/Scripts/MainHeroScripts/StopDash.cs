using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDash : MonoBehaviour
{
    public Animator anim;
    void StopDashing()
    {
        anim.SetBool("Dash", false);
    }
}
