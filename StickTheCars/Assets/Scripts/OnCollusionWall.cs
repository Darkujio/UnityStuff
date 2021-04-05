using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollusionWall : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    //Destroy cars on collide + restart scene on main car collide
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "MainCar"){
            // Scene scene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(scene.name);
            Destroy(Instantiate(ExplosionPrefab, collider.gameObject.transform.position, Quaternion.identity), 3f);
            Destroy(collider.gameObject.transform.parent.gameObject);
        }
        else 
        if (collider.gameObject.transform.parent != null && collider.gameObject.transform.parent.gameObject.name == "MainCar")
        {
            Destroy(Instantiate(ExplosionPrefab, collider.gameObject.transform.position, Quaternion.identity), 3f);
            Destroy(collider.gameObject);
        }
    }
}
    