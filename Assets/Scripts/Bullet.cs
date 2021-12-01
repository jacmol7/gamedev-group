using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The maximum ammount of time the bullet should exist for
    public float destroyTime;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
