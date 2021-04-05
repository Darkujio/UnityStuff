using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    private PlankHoldersData PlankHoldersData;
    public Vector3 Force;
    private bool Falling = false;
    void Start()
    {
        FindObjectOfType<FlyToTarget>().Shoot += ShootToTarget;
        PlankHoldersData = FindObjectOfType<PlankHoldersData>();
    }

    void ShootToTarget()
    {
        int dispertion = PlankHoldersData.AmountRight - PlankHoldersData.AmountLeft;
        PlankHoldersData.AmountRight = 0;
        PlankHoldersData.AmountLeft = 0;
        Force.x = dispertion/2f;
        gameObject.transform.position = new Vector3(0,1.5f,gameObject.transform.position.z + 5f);
        gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse);
        Falling = true;
        print("supposetofly");

    }
    void Update()
    {
        if (Falling) gameObject.transform.GetChild(1).GetComponent<Planks_Animator>().Falling();
    }
}
