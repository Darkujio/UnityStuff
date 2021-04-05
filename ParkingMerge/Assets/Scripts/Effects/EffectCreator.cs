using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{    
    public Camera Camera;
    public GameObject Effect;
    public void SpawnEffect(GameObject GO)
    {
        Vector3 pos = Camera.WorldToScreenPoint(GO.transform.position);
        GameObject EffectInst = Instantiate(Effect,gameObject.transform);
        EffectInst.transform.localPosition = new Vector3(pos.x - Screen.width/2,pos.y - Screen.height/2,0f);
    }
}


