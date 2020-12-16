using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    private GameObject LogicOperand;
    void OnMouseDown()
    {
        if (gameObject.name == "BoxSlot1") SendIt(0);
        else if (gameObject.name == "BoxSlot2") SendIt(1);
        else if (gameObject.name == "BoxSlot3") SendIt(2);
        else if (gameObject.name == "BoxSlot4") SendIt(3);
        else if (gameObject.name == "BoxSlot5") SendIt(4);
        else if (gameObject.name == "BoxSlot6") SendIt(5);
        else if (gameObject.name == "BoxSlot7") SendIt(6);
        else if (gameObject.name == "BoxSlot8") SendIt(7);
    }

    private void SendIt(int Box)
    {
        LogicOperand = GameObject.Find("LogicOperator");
        LogicOperand.SendMessage("ClickHandling",Box);
    }
}
