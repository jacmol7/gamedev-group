using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The maximum ammount of time the bullet should exist for
    public float destroyTime;

    // Our particle emitter, needed to allow the particles to stay
    // after the bullet it destroyed
    private GameObject trail;

    private GameObject enemy;

    void Start()
    {
        trail = transform.Find("BulletTrail").gameObject;
        Invoke("destroy", destroyTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && transform.parent.name == "PlayerBullets")
        {
            return;
        }

        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().reduceHealth();
        }

        if (col.gameObject.tag != "Bullet")
        {
            destroy();
        }
    }

    void destroy()
    {
        // Detach the particle emitter from the bullet so it will remain.
        // The particle emitter will destroy itself once no more particles remain
        trail.transform.parent = transform.parent;
        ParticleSystem emitter = trail.GetComponent<ParticleSystem>();
        emitter.Stop();
        
        Destroy(gameObject);
    }

    void OnCollisonEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().reduceHealth();
        }
    }
}
