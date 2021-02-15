using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class EntityToMain : MonoBehaviour
{
    public bool MainHero = false;
    public Material Hero_Material;
    public Material Enemy_Material;
    private GameObject floor;
    private GameController GameController;
    private Renderer rend;
    private Vector3 Destination;
    private bool Stabilize = false;
    private bool Moving = false;
    private bool RemoveFlag = false;
    void Awake(){
        rend = gameObject.GetComponent<Renderer> ();
        rend.material = Enemy_Material;
        floor = GameObject.Find("Floor");
    }
    void Start(){
        if (Application.isPlaying){
            GameController = GameObject.Find("GameController").GetComponent<GameController>();
            GameController.ObjectsArrayInGame[(int)gameObject.transform.position.x,(int)gameObject.transform.position.z] = gameObject;
            if (MainHero){
                GameController.AssygnMainHero(gameObject);
                rend.material = Hero_Material;
            }
        }
    }
    void Remove(){
        RemoveFlag = true;
    }
    void Update(){
        if (MainHero){
            rend.material = Hero_Material;
        }
        if (!MainHero){
            rend.material = Enemy_Material;
        }
        if (RemoveFlag){
            if (gameObject.transform.position.y < -1 & !MainHero){
                Destroy(gameObject,3);
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
                GameController.SendMessage("ReloadSendInDirection", gameObject);
            }
        }
    }
    void FixedUpdate(){
        if (Stabilize){
            gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(Destination.x,gameObject.transform.position.y,Destination.z));
            if (Destination.x == gameObject.transform.position.x & Destination.z == gameObject.transform.position.z){
                GameController.TurnOnUI();
                Stabilize = false;
            }
        }
    }
    IEnumerator NewScene()
    {
        yield return new WaitForSecondsRealtime(3);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void AwaitDest(Vector3 destination){
        Destination = destination;
        Moving = true;
    }

    void OnDestroy(){
        if (Application.isPlaying){
            GameObject[,] ObjectsArray = GameController.ObjectsArrayInGame;
            int k = 0;
            for(int i = 0; i<8; i++){
                for(int j = 0; j<8; j++){
                    if (ObjectsArray[i,j]) k++;
                }
            }
            if (k == 2){
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
