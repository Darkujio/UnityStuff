using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetPlank : MonoBehaviour
{
    public Action<int> IncreasePlankAmountLeft;
    public Action<int> IncreasePlankAmountRight;
    public bool left;
    public void IncreasePlanks(int plankAmount)
    {
        if (left) IncreasePlankAmountLeft?.Invoke(plankAmount);
        else IncreasePlankAmountRight?.Invoke(plankAmount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            IncreasePlanks(1);
            Destroy(other.transform.parent.gameObject);
        }
    }
}
