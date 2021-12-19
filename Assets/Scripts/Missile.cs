using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed; //speed of the missile 
    private Transform player; //transform variable for the player 
    private Vector2 target; //vector2 variable for target 
    public GameObject explode; //explode game object 
    float removeTime = 2.0f; 
     
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find the Player game object 
        target = new Vector2(player.position.x, player.position.y);//the missile will spawn at the same position as player
        Destroy(gameObject, removeTime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);//bullet is spawn, register the player position and move toward the player position 
        
        if(transform.position.x == target.x && transform.position.y == target.y) //check if the missiles hit the target
        {
            OnDestroy(); //destroy the missiles when missiles hit the player 
        }
    }

    void OnTriggerEnter2D(Collider2D other) //method when missile collide with other game objects 
    {
        if(other.gameObject.tag == "Player") //find the player game object 
        {
            OnDestroy(); //OnDestroy function when hit the player 
            other.GetComponent<PlayerHealth>().TakeDamage(); //minus one health to the player when missile hits the player 
        }
        if(other.gameObject.tag == "Terrain") //finnd the terrain game object 
        {
            OnDestroy(); //OnDestroy function  when hit the terrain 
        }   
    }

    void OnDestroy()
    {
        Destroy(gameObject); //destroy the missile game object 
        Instantiate (explode, transform.position, transform.rotation); //adding the explosion effect when explode 
    }
}
