using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planks_Animator : MonoBehaviour
{
    public Animator Animator;
    public int DeltaPlanks;
    public int DeltaPlanksForFall;
    private PlankHoldersData PlankHoldersData;
    private int RightPlanks;
    private int LeftPlanks;
    void Start()
    {
        PlankHoldersData = gameObject.GetComponent<PlankHoldersData>();
        foreach (WallColl WallColl in FindObjectsOfType<WallColl>())
        {
            WallColl.BumpLeft += BumpLeft;
            WallColl.BumpRight += BumpRight;
        }
        FindObjectOfType<StepInWaterReac>().OnFloor += UnFalling;
    }
    void Update()
    {
        RightPlanks = PlankHoldersData.AmountRight;
        LeftPlanks = PlankHoldersData.AmountLeft;

        float DeltaPlanksForFallFloat = DeltaPlanksForFall;
        if (LeftPlanks > RightPlanks) 
        {
            Animator.SetFloat("Blend", 0.5f + ((LeftPlanks - RightPlanks)/DeltaPlanksForFallFloat)*0.5f);
        }

        if (RightPlanks > LeftPlanks) 
        {
            Animator.SetFloat("Blend", 0.5f - ((RightPlanks - LeftPlanks)/DeltaPlanksForFallFloat)*0.5f);
        }
        if (RightPlanks == LeftPlanks)
        {
            Animator.SetFloat("Blend", 0.5f);
        }
        if (LeftPlanks > RightPlanks + DeltaPlanksForFall) Animator.SetBool("FallLeft",true);
        if (RightPlanks > LeftPlanks + DeltaPlanksForFall) Animator.SetBool("FallRight",true);

    }

    void BumpLeft()
    {
        Animator.SetBool("BumpLeft", true);
    }

    void BumpRight()
    {
        Animator.SetBool("BumpRight", true);
    }

    public void Falling()
    {
        Animator.SetBool("Falling", true);
    }

    public void UnFalling()
    {
        Animator.SetBool("Falling", false);
    }
}
