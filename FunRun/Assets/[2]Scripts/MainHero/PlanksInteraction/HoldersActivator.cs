using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldersActivator : MonoBehaviour
{
    private GameObject[] Planks;
    private PlankHoldersData PlankHoldersData;
    public bool left;
    void Start()
    {
        Planks = new GameObject[transform.childCount];
        for (int i =0; i<transform.childCount; i++)
        {
            Planks[i] = transform.GetChild(i).gameObject;
            Planks[i].SetActive(false);
        }
        PlankHoldersData = FindObjectOfType<PlankHoldersData>();
        PlankHoldersData.ChangedAmount += ReDraw;
        FindObjectOfType<PlankFall>().Fall += Fall;
    }
    void ReDraw()
    {
        if (left)
        {
            for (int i = 0; i < PlankHoldersData.AmountLeft; i++)
            {
                Planks[i].SetActive(true);
            }
            for (int i = PlankHoldersData.AmountLeft; i < Planks.Length; i++)
            {
                Planks[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < PlankHoldersData.AmountRight; i++)
            {
                Planks[i].SetActive(true);
            }
            for (int i = PlankHoldersData.AmountRight; i < Planks.Length; i++)
            {
                Planks[i].SetActive(false);
            }
        }
    }

    void Fall()
    {
        Destroy(gameObject.GetComponent<HingeJoint>());
        gameObject.AddComponent<BoxCollider>();
        //Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
