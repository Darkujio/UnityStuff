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
    private Vector3 EntityDestination; //Temp data holder
    private Vector3 NewEntity; //Temp data holder
    private Vector3 TempDirection; //Temp data holder
    public GameObject[,] ObjectsArrayInGame;

    private void Awake(){
        FinalData = Holder.data;
        ObjectsArrayInGame = new GameObject[8,8];
    }

    public void AssygnMainHero(GameObject Hero){
        MainHero = Hero;
    }

    //Main controller of movement
    private void SendInDirection(Vector3 Entity, Vector3 direction){
        if (CheckIfAbyss(Entity,direction)){
            //GameObject EntityObject = ObjectsArrayInGame[(int)Entity.x,(int)Entity.z];
            Rigidbody rb = ObjectsArrayInGame[(int)Entity.x,(int)Entity.z].GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(direction * speed, ForceMode.Impulse);
            rb.gameObject.SendMessage("Remove");
            //TODO if going to abyss
        }
        else{
            //Rigidbody rb = AddBody(Entity);
            Rigidbody rb = ObjectsArrayInGame[(int)Entity.x,(int)Entity.z].GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(direction * speed, ForceMode.Impulse);
            EntityDestination = CheckCollusionPoint(Entity,direction);
            rb.gameObject.SendMessage("AwaitDest",EntityDestination);
            ObjectsArrayInGame[(int)Entity.x,(int)Entity.z] = null; //fix changes in array
            ObjectsArrayInGame[(int)EntityDestination.x,(int)EntityDestination.z] = rb.gameObject; //fix changes in array
            NewEntity = (EntityDestination+direction);
            TempDirection = direction;
        }
    }
    //Collusion between targets occured
    public void ReloadSendInDirection(GameObject SenderObject){
        SendInDirection(NewEntity,TempDirection);
    }

    //Check what is the final point in movement of a entity before he pushes the Enemy
    //Return Vector3 position of a entity after collusion
    private Vector3 CheckCollusionPoint(Vector3 StartPos, Vector3 direction){
        if (direction.x == 0){
            for(float z = (StartPos.z + direction.z); (-1<z)&(z<8); z+=direction.z){
                if (FinalData.rows[(int)StartPos.x].row[(int)z]){
                    Vector3 ReturnVector = new Vector3((int)StartPos.x,0,(int)z-direction.z);
                    return ReturnVector;
                }
            }
        }
        else {
            for(float x = (StartPos.x + direction.x); (-1<x)&(x<8); x+=direction.x){
                if (FinalData.rows[(int)x].row[(int)StartPos.z]){
                    Vector3 ReturnVector = new Vector3((int)x - direction.x,0,(int)StartPos.z);
                    return ReturnVector;
                }
            }
        }
        Vector3 ReturnVectorPlug = new Vector3(0,0,0);
        return ReturnVectorPlug;
    }

    //Check if Direction of Movement sends Hero in the abyss
    //Return True if the hero goes to abyss after movement
    private bool CheckIfAbyss(Vector3 StartPos, Vector3 direction){
        if (direction.x == 0){
            for(float z = (StartPos.z + direction.z); (-1<z)&(z<8); z+=direction.z){
                if (FinalData.rows[(int)StartPos.x].row[(int)z]){
                    return false;
                }
            }
        }
        else {
            for(float x = (StartPos.x + direction.x); (-1<x)&(x<8); x+=direction.x){
                if (FinalData.rows[(int)x].row[(int)StartPos.z]){
                    return false;
                }
            }
        }
        return true;
    }

    //ButtonTriggers
    public void GoUp(){ // x:0 z:+1
        SendInDirection(MainHero.transform.position, new Vector3(0,0,1));
        TurnOffUI();
    }
    public void GoDown(){ // x:0 z:-1
        SendInDirection(MainHero.transform.position, new Vector3(0,0,-1));
        TurnOffUI();
    }
    public void GoLeft(){ //x:-1 z:0
        SendInDirection(MainHero.transform.position, new Vector3(-1,0,0));
        TurnOffUI();
    }
    public void GoRight(){ //x:=1 z:0
        SendInDirection(MainHero.transform.position, new Vector3(1,0,0));
        TurnOffUI();
    }
    public void TurnOffUI(){
        Canvas.SetActive(false);
    }
    public void TurnOnUI(){
        Canvas.SetActive(true);
    }
}