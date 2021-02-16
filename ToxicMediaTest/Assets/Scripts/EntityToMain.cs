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
    private GameController GameController;
    private Renderer rend;
    void Awake(){
        rend = gameObject.GetComponent<Renderer> ();
        rend.material = Enemy_Material;
    }
    void Start(){
        if (Application.isPlaying){
            GameController = GameObject.Find("GameController").GetComponent<GameController>();
            GameController.ObjectsArrayInGame[(int)gameObject.transform.position.x,(int)gameObject.transform.position.z] = gameObject;
            if (MainHero){
                GameController.AssygnMainHero(gameObject);
                gameObject.GetComponent<EntityController>().MainHero = true;
                rend.material = Hero_Material;
            }
        }
    }
    void Update(){
        if (MainHero){
            rend.material = Hero_Material;
        }
        if (!MainHero){
            rend.material = Enemy_Material;
        }
    }
}
