using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
    [SerializeField] private GameObject pausePanel;
    void Awake()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape)) 
        {
            if (!pausePanel.activeInHierarchy) 
            {
                PauseGame();
            }
            else
            {
                ContinueGame();   
            }
        } 
     }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}