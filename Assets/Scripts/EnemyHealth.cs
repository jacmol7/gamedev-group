using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health; //health of enemy 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void reduceHealth() //method to reduce enemy health 
    {
        health--; //minus one health for each hit 
        //Debug.Log("Reduce health");
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1) //if enemy health is lower than 1
        {
            Destroy(gameObject); //destroy the enemy 
        }
    }

    
}
