using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapLogger : MonoBehaviour
{
    public GameObject Knife;
    public void RegisterTap(){
        //print("TapGet");
        Knife.SendMessage("SendTheKnife");
    }
}
