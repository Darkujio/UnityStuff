using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public int KnifeSpeed;
    public GameObject LogObject;
    public GameObject LoseZoePrefab;
    private Rigidbody2D LogRigidBody2D;
    private int KnifeSkin;
    private Rigidbody2D KnifeBody;
    private FixedJoint2D joint;
    void Awake(){
        KnifeSkin = GameController.Instance.CurrentKnife;
    }

    void Start(){
        KnifeBody = gameObject.GetComponent<Rigidbody2D>();
        joint = gameObject.GetComponent<FixedJoint2D>();
        LogRigidBody2D = LogObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject == LogObject){
            Instantiate(LoseZoePrefab, gameObject.transform.position, Quaternion.identity, LogObject.transform);
            Destroy(gameObject);
        }
        else Debug.Log(col);
    }

    public void SendTheKnife(){
        KnifeBody.AddForce(transform.up * KnifeSpeed, ForceMode2D.Impulse);
    }
    
}
