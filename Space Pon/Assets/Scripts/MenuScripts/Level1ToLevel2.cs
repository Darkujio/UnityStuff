using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1ToLevel2 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Level2Scene");
    }
}
