using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenuScript : MonoBehaviour
{
    public void ToMainMenuButton(){
        SceneManager.LoadScene("Menu");
    }
}
