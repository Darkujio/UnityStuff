using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enteraction : MonoBehaviour
{
    public Action Collided;
    public Action MayStart;
    public Action<GameObject> Composed;
    public Action<GameObject> Fused;
    private EffectCreator EffectCreator;
    public Move Move;
    public GameObject SuccPoint;
    private bool Moving = false;
    private void Start()
    {
        Move.StartingMovement += StartedMoving;
        EffectCreator = GameObject.FindObjectOfType<EffectCreator>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<CarIndex>()?.CarMultIndex == gameObject.GetComponent<CarIndex>()?.CarMultIndex && Moving)
        {
            EffectCreator.SpawnEffect(other.gameObject);
            Compose(other);
            Moving = false;
            MayStart?.Invoke();
        }
        else if(Moving)
        {
            Moving = false;
            Collided?.Invoke();
            MayStart?.Invoke();
        }
    }

    private void Compose(Collision other)
    {
        Composed?.Invoke(gameObject);   
        other.gameObject.GetComponent<Grow>().GrowUp();
        Destroy(gameObject);
    }

    private void StartedMoving(){
        Moving = true;
    }
}
