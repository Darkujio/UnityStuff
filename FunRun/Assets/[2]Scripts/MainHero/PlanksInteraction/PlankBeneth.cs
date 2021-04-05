using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankBeneth : MonoBehaviour
{
    public float PlatformHight = 1.45f;
    public GameObject PlankPrefab;
    public GameObject PlankObject;
    private Planks_Animator Planks_Animator;
    private PlankHoldersData PlankHoldersData;
    void Start()
    {
        PlankHoldersData = FindObjectOfType<PlankHoldersData>();
        Planks_Animator = FindObjectOfType<Planks_Animator>();
    }
    void Update()
    {
        if (transform.position.y < PlatformHight )
        {
            int PlanksLeft = PlankHoldersData.AmountLeft;
            int PlanksRight = PlankHoldersData.AmountRight;
            if (PlanksLeft != 0 || PlanksRight != 0)
            {
                transform.position = transform.position + new Vector3(0f,0.1f,0f);
                Instantiate(PlankPrefab, new Vector3(transform.position.x, 0 ,transform.position.z + 0.5f), Quaternion.identity, PlankObject.transform);
                if (PlanksLeft > PlanksRight)
                {
                    PlankHoldersData.SubstractLeftPlanks(1);
                }
                else
                {
                    PlankHoldersData.SubstractRightPlanks(1);
                }
            }
            else
            {
                Planks_Animator.Falling();
            }
        }
    }
}