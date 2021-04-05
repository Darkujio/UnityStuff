using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlankFall : MonoBehaviour
{
    public Action Fall;
    private Planks_Animator Planks_Animator;
    private PlankHoldersData PlankHoldersData;
    private int TooMuch;
    void Start()
    {
        Planks_Animator = gameObject.GetComponent<Planks_Animator>();
        PlankHoldersData = gameObject.GetComponent<PlankHoldersData>();
        TooMuch = Planks_Animator.DeltaPlanksForFall;
    }

    void Update()
    {
        if (Math.Abs(PlankHoldersData.AmountLeft - PlankHoldersData.AmountRight)>TooMuch) 
        {
            Fall?.Invoke();
            Destroy(this);
        }
    }
}
