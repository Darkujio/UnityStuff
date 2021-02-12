using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToScore : MonoBehaviour
{
    public void AddScoreButton(){
        GameController.Instance.Coins += 5;
    }
}
