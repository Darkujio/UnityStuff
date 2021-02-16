using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityController : MonoBehaviour
{
    public bool MainHero = false;
    public DataHolder Holder;

    private bool Stabilize = false;
    private bool Moving = false;
    private bool RemoveFlag = false;
    private Vector3 CurPos;
    private Vector3 Destination;
    private Vector3 CollusionEntity;
    private Vector3 TempDir;
    private ArrayLayout FinalData;
    private GameController GameController;
    private float speed;

    void Start(){
        CurPos = new Vector3((int)gameObject.transform.position.x, 0, (int)gameObject.transform.position.z);
        Holder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
        speed = GameController.speed;
    }

    void Update(){
        if (RemoveFlag){
            if (gameObject.transform.position.y < -1 & !MainHero){
                RemoveFlag = false;
                Destroy(gameObject,3);
                GameObject[,] ObjectsArray = GameController.ObjectsArrayInGame;
                int k = 0;
                for(int i = 0; i<8; i++){
                    for(int j = 0; j<8; j++){
                        if (ObjectsArray[i,j]) k++;
                    }
                }
                if (k == 1){
                    StartCoroutine(NewScene());
                }
            }
            else if (gameObject.transform.position.y < -1 & MainHero){
                StartCoroutine(NewScene());
            }
        }
        if (Moving){
            if (gameObject.transform.position.x + 0.1f > Destination.x & gameObject.transform.position.x - 0.1f < Destination.x &
            gameObject.transform.position.z + 0.1f > Destination.z & gameObject.transform.position.z - 0.1f < Destination.z ){
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Moving = false;
                Stabilize = true;
                GameController.ObjectsArrayInGame[(int)CollusionEntity.x,(int)CollusionEntity.z].SendMessage("Move",TempDir);
            }
        }
    }

    void FixedUpdate(){
        if (Stabilize){
            gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(Destination.x,gameObject.transform.position.y,Destination.z));
            if (Destination.x == gameObject.transform.position.x & Destination.z == gameObject.transform.position.z){
                if (MainHero) GameController.TurnOnUI();
                Stabilize = false;
            }
        }
    }


    //Message Box
    private void Move(Vector3 direction){
        RemoveFlag = false;
        Stabilize = false;
        Moving = false;
        CurPos = new Vector3((int)gameObject.transform.position.x, 0, (int)gameObject.transform.position.z);
        if (CheckIfAbyss(direction)){
            GameController.ObjectsArrayInGame[(int)gameObject.transform.position.x,(int)gameObject.transform.position.z] = null;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(direction * speed, ForceMode.Impulse);
            RemoveFlag = true;
        }
        else{
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Destination = CheckCollusionPoint(direction);
            CollusionEntity = Destination + direction;
            TempDir = direction;
            if (Destination == CurPos){
                GameController.ObjectsArrayInGame[(int)CollusionEntity.x,(int)CollusionEntity.z].SendMessage("Move",TempDir);
                if (MainHero) StartCoroutine(TurnOnUIdelay());
            }
            else{
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(direction * speed, ForceMode.Impulse);
                GameController.ObjectsArrayInGame[(int)gameObject.transform.position.x,(int)gameObject.transform.position.z] = null;
                GameController.ObjectsArrayInGame[(int)Destination.x,(int)Destination.z] = gameObject;
                Moving = true;
            }
        }
    }

    //Check what is the final point in movement of a entity before he pushes the Enemy
    //Return Vector3 position of a entity after collusion
    private Vector3 CheckCollusionPoint(Vector3 direction){
        GameObject[,] ObjectsArray = GameController.ObjectsArrayInGame;
        if (direction.x == 0){
            for(float z = (CurPos.z + direction.z); (-1<z)&(z<8); z+=direction.z){
                if (ObjectsArray[(int)CurPos.x,(int)z] != null){
                    Vector3 ReturnVector = new Vector3((int)CurPos.x,0,(int)z-direction.z);
                    return ReturnVector;
                }
            }
        }
        else {
            for(float x = (CurPos.x + direction.x); (-1<x)&(x<8); x+=direction.x){
                if (ObjectsArray[(int)x,(int)CurPos.z] != null){
                    Vector3 ReturnVector = new Vector3((int)x - direction.x,0,(int)CurPos.z);
                    return ReturnVector;
                }
            }
        }
        Vector3 ReturnVectorPlug = new Vector3(0,0,0);
        return ReturnVectorPlug;
    }

    //Check if Direction of Movement sends entity in the abyss
    //Return True if the entity goes to abyss after movement
    private bool CheckIfAbyss(Vector3 direction){
        GameObject[,] ObjectsArray = GameController.ObjectsArrayInGame;
        if (direction.x == 0){
            for(float z = (CurPos.z + direction.z); (-1<z)&(z<8); z+=direction.z){
                if (ObjectsArray[(int)CurPos.x,(int)z] != null){
                    return false;
                }
            }
        }
        else {
            for(float x = (CurPos.x + direction.x); (-1<x)&(x<8); x+=direction.x){
                if (ObjectsArray[(int)x,(int)CurPos.z] != null){
                    return false;
                }
            }
        }
        return true;
    }

    // void OnDestroy(){
    //     GameObject[,] ObjectsArray = GameController.ObjectsArrayInGame;
    //     int k = 0;
    //     for(int i = 0; i<8; i++){
    //         for(int j = 0; j<8; j++){
    //             if (ObjectsArray[i,j]) k++;
    //         }
    //     }
    //     if (k == 1){
    //         Scene scene = SceneManager.GetActiveScene();
    //         SceneManager.LoadScene(scene.name);
    //     }
    // }

    //Courotine for new scene (3sec timer)
    IEnumerator NewScene()
    {
        yield return new WaitForSecondsRealtime(3);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator TurnOnUIdelay()
    {
        yield return new WaitForSecondsRealtime(1);
        GameController.TurnOnUI();
    }
}
