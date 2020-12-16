using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingFoodSample : MonoBehaviour
{
    [SerializeField]
    private Sprite Sprite1hhd;
    [SerializeField]
    private Sprite Sprite2hhd;
    [SerializeField]
    private Sprite Sprite3hhd;
    [SerializeField]
    private Sprite Sprite4hhd;
    [SerializeField]
    private Sprite Sprite5hhd;
    [SerializeField]
    private Sprite Sprite6hhd;

    public void ChangeFruit(int fruit)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (fruit == 0)
        {
            sr.sprite = null;
        }
        if (fruit == 1)
        {
            sr.sprite = Sprite1hhd;
        }
        if (fruit == 2)
        {
            sr.sprite = Sprite2hhd;
        }
        if (fruit == 3)
        {
            sr.sprite = Sprite3hhd;
        }
        if (fruit == 4)
        {
            sr.sprite = Sprite4hhd;
        }
        if (fruit == 5)
        {
            sr.sprite = Sprite5hhd;
        }
        if (fruit == 6)
        {
            sr.sprite = Sprite6hhd;
        }
    }
}
