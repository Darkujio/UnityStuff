using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpinner : MonoBehaviour
{
    public float RotationSpeed;
    public int RotationStopInterval;
    public int RotationStopLength;
    private int CurrentLevel;
    private Rigidbody2D LogBody;
    void Awake(){
        CurrentLevel = GameController.Instance.CurrentLevel;
    }
    void Start(){
        LogBody = gameObject.GetComponent<Rigidbody2D>();
        LogBody.angularDrag = 0f;
        LogBody.angularVelocity = RotationSpeed;
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.otherCollider != gameObject.GetComponent<CircleCollider2D>()){
            Debug.Log("YouDied");
            //LOSING SCRIPT GOES HERE
        }
    }
}
