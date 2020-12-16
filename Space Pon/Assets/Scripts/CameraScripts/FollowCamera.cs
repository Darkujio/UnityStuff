using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;  

    void Start () 
    {
        player = GameObject.Find("MainHeroObj");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {        
        transform.position = player.transform.position + offset;
    }
}
