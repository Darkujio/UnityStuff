using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int Coins = 0;
    public int CurrentLevel = 0;
    public int CurrentKnife = 0;
    public int Record = 0;


    void Awake(){
	    Instance = this;
        Coins = PlayerPrefs.GetInt("Coins");
        Record = PlayerPrefs.GetInt("Record");
        CurrentKnife = PlayerPrefs.GetInt("CurrentKnife");
        SceneManager.LoadScene("Menu");
    }

    public void SaveScore(){
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.SetInt("Record", Record);
        PlayerPrefs.SetInt("CurrentKnife", CurrentKnife);
        Debug.Log("ScoreSaved");
    }
}
