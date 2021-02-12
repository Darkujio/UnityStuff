using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInPrefs : MonoBehaviour
{
    public void SaveInPrefsButton(){
        GameController.Instance.SaveScore();
    }
}
