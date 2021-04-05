using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int MachineCount = 0;
    public GameObject WinConfetti;
    void Start()
    {
        foreach(GetAway GetAway in GameObject.FindObjectsOfType<GetAway>())
        {
            GetAway.gameObject.GetComponent<Enteraction>().Composed += Counter;
            GetAway.CarAway += Counter;
            MachineCount++;
        }

    }
    protected void Counter()
    {
        Count();
    }
    protected void Counter(GameObject gameObject)
    {
        Count();
    }
    protected void Count()
    {
        MachineCount -= 1;
        if (MachineCount == 0)
        {
            WinConfetti.SetActive(true);
        }
    }

}
