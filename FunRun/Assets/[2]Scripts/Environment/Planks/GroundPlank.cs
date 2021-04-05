using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlank : MonoBehaviour
{
    public int PlanksAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        GetPlank GetPlanks = other.GetComponent<GetPlank>();
        if (GetPlanks != null)
        {
            GetPlanks.IncreasePlanks(PlanksAmount);
            Destroy(transform.parent.gameObject);
        }
    }
}
