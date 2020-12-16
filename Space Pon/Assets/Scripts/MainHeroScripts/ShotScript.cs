using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", 5f);
        }
    }
}
