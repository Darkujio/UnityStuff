using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDoButtonScript : MonoBehaviour
{
    private GameObject LogicOperand;
    void OnMouseDown()
    {
        LogicOperand = GameObject.Find("LogicOperator");
        LogicOperand.SendMessage("UnDo");
    }
}
