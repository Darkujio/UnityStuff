using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows;
using System;

public class CollusionHandle : MonoBehaviour
{
    public Material Material_True;
    private float FinAngle;
    private float angle;
    private bool WallTrigger = false;

    void OnTriggerEnter(Collider col){
        //Add collided car in a bundle
        if (col.gameObject.transform.parent != null && col.gameObject.transform.parent.name == "AnotherCar"){
            col.gameObject.transform.SetParent(gameObject.transform); 
            col.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            col.gameObject.GetComponent<Renderer>().material = Material_True;
        }
        //Trigger enter for wall special rotation
        if (col.gameObject.transform.name == "Trigger"){
            WallTrigger = true;
        }
    }
    //Trigger exit for wall special rotation
    void OnTriggerExit(Collider col){
        if (col.gameObject.transform.name == "Trigger"){
            WallTrigger = false;
        }
    }
    //Rotate all cars in bundle
    public void RotateCars(float CarRotation, float RotationSpeed){
        if (WallTrigger){
            foreach (Transform child in gameObject.transform){
                child.transform.rotation = Quaternion.Lerp(child.transform.rotation, Quaternion.Euler(-90, 0, 0f), Time.deltaTime*RotationSpeed);
            }
        }
        else foreach(Transform child in gameObject.transform){
            child.transform.rotation = Quaternion.Lerp(child.transform.rotation, Quaternion.Euler(-90,0,CarRotation), Time.deltaTime * RotationSpeed);
        }

    }
}
