using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StepInWaterReac : MonoBehaviour
{
    private HeroStepIn[] HeroStepIns;
    public float JumpStrength;
    private bool SecondStep = false;
    public Action StopCamera;
    public Action OnFloor;
    void Start()
    {
        HeroStepIns = FindObjectsOfType<HeroStepIn>();
        foreach (HeroStepIn HeroStep in HeroStepIns)
        {
            HeroStep.StepInWater += Stepped;
        }
    }
    void Stepped()
    {
        if (SecondStep)
        {
            StopCamera?.Invoke();
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,JumpStrength,0), ForceMode.Impulse);
            SecondStep = true;
        }
    }
    void OnCollisionEnter()
    {
        SecondStep = false;
        OnFloor?.Invoke();
    }
}
