using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    public int GateIndex;
    private int AmountOfCars = 0;
    void Start()
    {
        foreach ( Enteraction Enteraction in GameObject.FindObjectsOfType<Enteraction>())
        {
            Enteraction.Composed += CheckIndex;
        }
        foreach ( CarIndex CarIndex in GameObject.FindObjectsOfType<CarIndex>())
        {
            if (CarIndex.CarMultIndex == GateIndex) AmountOfCars++;
        }
    }
    protected void CheckIndex(GameObject GO)
    {
        if (GO.GetComponent<CarIndex>().CarMultIndex == GateIndex)
        {
            Counter();
        }
    }
    void Counter()
    {
        AmountOfCars -= 1;
        if (AmountOfCars == 1)
        {
            OpenUp();
        }
    }
    void OpenUp()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("OutReady",true);
    }
}
