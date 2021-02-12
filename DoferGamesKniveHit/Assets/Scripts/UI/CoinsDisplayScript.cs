using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI RecordDisplayText;
    void Start(){
        RecordDisplayText.text = GameController.Instance.Coins.ToString();
    }
}
