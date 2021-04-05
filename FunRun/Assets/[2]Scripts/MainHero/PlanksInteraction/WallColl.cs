using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallColl : MonoBehaviour
{
    public Action<int> DecreasePlankAmountLeft;
    public Action<int> DecreasePlankAmountRight;
    public Action BumpRight;
    public Action BumpLeft;
    public bool left;
    public void DecreasePlanks(int plankAmount)
    {
        if (left) 
        {
            BumpLeft?.Invoke();
            DecreasePlankAmountLeft?.Invoke(plankAmount);
        }
        else 
        {
            BumpRight?.Invoke();
            DecreasePlankAmountRight?.Invoke(plankAmount);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            DecreasePlanks(10);
            Destroy(other.transform.gameObject.GetComponent<BoxCollider>());
        }
    }
}
