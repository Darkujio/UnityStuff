using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float speed;
    public float health;

    void Awake()
    {
        speed = 1f;
        health = 15f;
    }

    void FixedUpdate()
    {
        if (health <= 0) Destroy(gameObject);
    }

    public void ApplyDamage(float damage)
    {
        health = health - damage;
    }
}
