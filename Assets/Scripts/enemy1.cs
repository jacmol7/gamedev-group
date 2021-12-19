using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Transform target; //a variable for enemy to follow the target(player)
    public float speed; //Speed of the enemy
    
     // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//find the player object 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position)> 0.1 )//the distacne from the enemy to the player 
        {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //enemy move towrd to the player 
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")//find the game object with tag with player
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();//call the method from class player health to take damage
            //Debug.Log("Destroy Enemy1, Reduce player's health");
        }

    }
}
