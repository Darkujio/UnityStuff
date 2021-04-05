using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public TouchHandler TouchHandler;
    public GameObject Confetti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        TouchHandler.MovingCamera = false;
        Confetti.SetActive(true);
    }
}
