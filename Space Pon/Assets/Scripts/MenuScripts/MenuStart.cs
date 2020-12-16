using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}
