using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public void ShowScoreButton(){
        print("Coins:" + GameController.Instance.Coins.ToString());
        print("Coins:" + GameController.Instance.Record.ToString());
    }
}
