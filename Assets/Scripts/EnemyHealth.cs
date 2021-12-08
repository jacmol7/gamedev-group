using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("enemy1");
    }

    public void reduceHealth()
    {
        health--;
        Debug.Log("Reduce health");
    }

    // Update is called once per frame
    void Update()
    {
        //health--;
        if(health < 1)
        {
            Destroy(gameObject);
            //enemy.GetComponent<enemy1>().OnDestroy();
    
        }
    }

    
}
