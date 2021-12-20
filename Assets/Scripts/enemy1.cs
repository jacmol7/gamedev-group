using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Transform target; //a variable for enemy to follow the target(player)
    public float speed; //Speed of the enemy

    private Rigidbody2D rb;
    
     // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//find the player object 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position)> 0.1 )//the distacne from the enemy to the player 
        {
            //enemy move towrd to the player 
            if (target.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            // We are already right up against the player, stop pushing into them
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")//find the game object with tag with player
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();//call the method from class player health to take damage
        }

    }
}
