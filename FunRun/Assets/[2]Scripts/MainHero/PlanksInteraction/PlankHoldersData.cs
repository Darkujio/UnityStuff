using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlankHoldersData : MonoBehaviour
{
    public int AmountLeft;
    public int AmountRight;
    public Action ChangedAmount;
    private void Start()
    {
        GetPlank[] GetPlank = FindObjectsOfType<GetPlank>();
        WallColl[] WallColl = FindObjectsOfType<WallColl>();
        foreach (GetPlank Plank in GetPlank)
        {
            Plank.IncreasePlankAmountLeft += AddLeftPlanks;
            Plank.IncreasePlankAmountRight += AddRightPlanks;
        }
        foreach (WallColl Wall in WallColl)
        {
            Wall.DecreasePlankAmountLeft += SubstractLeftPlanks;
            Wall.DecreasePlankAmountRight += SubstractRightPlanks;
        }
    }

    protected void AddLeftPlanks(int Amount)
    {
        AmountLeft += Amount;
        ChangedAmount?.Invoke();
    }
    protected void AddRightPlanks(int Amount)
    {
        AmountRight += Amount;
        ChangedAmount?.Invoke();
    }

    public void SubstractRightPlanks(int Amount)
    {
        AmountRight -= Amount;
        if (AmountRight < 0) AmountRight = 0;
        ChangedAmount?.Invoke();
    }

    public void SubstractLeftPlanks(int Amount)
    {
        AmountLeft -= Amount;
        if (AmountLeft < 0) AmountLeft = 0;
        ChangedAmount?.Invoke();
    }
}
