using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordDisplay : MonoBehaviour
{
    public TextMeshProUGUI RecordDisplayText;
    void Start(){
        RecordDisplayText.text = GameController.Instance.Record.ToString();
    }
}
