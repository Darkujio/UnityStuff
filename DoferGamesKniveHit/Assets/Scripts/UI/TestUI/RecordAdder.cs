using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordAdder : MonoBehaviour
{
    public void AddScoreButton(){
        GameController.Instance.Record += 1;
    }
}
