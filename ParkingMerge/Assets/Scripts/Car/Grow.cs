using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grow : MonoBehaviour
{
    public GameObject GrowCar;
    public void GrowUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GrowCar.SetActive(true);
        transform.DOScaleY(1.3f,0.2f).OnComplete(()=>{transform.DOScaleY(1f,0.2f);});
    }
}
