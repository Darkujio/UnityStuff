using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKnife : MonoBehaviour
{
    public GameObject KnifePrefab;
    public GameObject Canvas;
    public TapLogger TapHandler;
    public GameObject LogObject;

    private GameObject NewKnifeObject;
    void OnTriggerEnter2D(){
        NewKnifeObject = Instantiate(KnifePrefab, Canvas.transform);
        TapHandler.Knife = NewKnifeObject;
        NewKnifeObject.GetComponent<KnifeController>().LogObject = LogObject;
    }
}
