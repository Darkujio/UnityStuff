using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameController : MonoBehaviour
{
    public float speed = 1f;
    public DataHolder Holder;
    public GameObject Canvas;
    private ArrayLayout FinalData;
    private GameObject MainHero;
    private bool Imput = true;
    public GameObject[,] ObjectsArrayInGame;

    private void Awake(){
        FinalData = Holder.data;
        ObjectsArrayInGame = new GameObject[8,8];
    }

    public void AssygnMainHero(GameObject Hero){
        MainHero = Hero;
    }

    //ButtonTriggers
    public void GoUp(){ // x:0 z:+1
        if (Imput){
        MainHero.SendMessage("Move", new Vector3(0,0,1));
        TurnOffUI();
        }
    }
    public void GoDown(){ // x:0 z:-1
        if (Imput){
        MainHero.SendMessage("Move", new Vector3(0,0,-1));
        TurnOffUI();
        }
    }
    public void GoLeft(){ //x:-1 z:0
        if (Imput){
        MainHero.SendMessage("Move", new Vector3(-1,0,0));
        TurnOffUI();
        }
    }
    public void GoRight(){ //x:=1 z:0
        if (Imput){
        MainHero.SendMessage("Move", new Vector3(1,0,0));
        TurnOffUI();
        }
    }
    public void TurnOffUI(){
        Canvas.SetActive(false);
        Imput = false;
    }
    public void TurnOnUI(){
        Imput = true;
        Canvas.SetActive(true);
    }
}