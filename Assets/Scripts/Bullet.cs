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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && transform.parent.name == "PlayerBullets")
        {
            return;
        }

        if (col.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
