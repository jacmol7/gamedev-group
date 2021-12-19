using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            Destroy(gameObject);
            Time.timeScale = 1.0f;
            Debug.Log("Destroy Enemy1, Reduce player's health");
        }

    }
}
