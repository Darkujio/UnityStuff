using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject MenuConf;
    private bool BoxActive = false;
    void OnMouseDown()
    {
        MenuConf.SetActive(true);
        GameObject Box1 = GameObject.Find("BoxSlot1");
        GameObject Box2 = GameObject.Find("BoxSlot2");
        GameObject Box3 = GameObject.Find("BoxSlot3");
        GameObject Box4 = GameObject.Find("BoxSlot4");
        GameObject Box5 = GameObject.Find("BoxSlot5");
        GameObject Box6 = GameObject.Find("BoxSlot6");
        GameObject Box7 = GameObject.Find("BoxSlot7");
        GameObject Box8 = GameObject.Find("BoxSlot8");
        Box1.GetComponent<BoxCollider2D>().enabled = false;
        Box2.GetComponent<BoxCollider2D>().enabled = false;
        Box3.GetComponent<BoxCollider2D>().enabled = false;
        Box4.GetComponent<BoxCollider2D>().enabled = false;
        Box5.GetComponent<BoxCollider2D>().enabled = false;
        Box6.GetComponent<BoxCollider2D>().enabled = false;
        Box7.GetComponent<BoxCollider2D>().enabled = false;
        if (Box8.GetComponent<BoxCollider2D>().enabled == true) 
        {
            BoxActive = true;
            Box8.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Reverse()
    {
        MenuConf.SetActive(false);
        GameObject Box1 = GameObject.Find("BoxSlot1");
        GameObject Box2 = GameObject.Find("BoxSlot2");
        GameObject Box3 = GameObject.Find("BoxSlot3");
        GameObject Box4 = GameObject.Find("BoxSlot4");
        GameObject Box5 = GameObject.Find("BoxSlot5");
        GameObject Box6 = GameObject.Find("BoxSlot6");
        GameObject Box7 = GameObject.Find("BoxSlot7");
        GameObject Box8 = GameObject.Find("BoxSlot8");
        Box1.GetComponent<BoxCollider2D>().enabled = true;
        Box2.GetComponent<BoxCollider2D>().enabled = true;
        Box3.GetComponent<BoxCollider2D>().enabled = true;
        Box4.GetComponent<BoxCollider2D>().enabled = true;
        Box5.GetComponent<BoxCollider2D>().enabled = true;
        Box6.GetComponent<BoxCollider2D>().enabled = true;
        Box7.GetComponent<BoxCollider2D>().enabled = true;
        if (BoxActive) 
        {
            Box8.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
