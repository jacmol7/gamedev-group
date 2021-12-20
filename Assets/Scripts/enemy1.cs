using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public float speed; //Speed of the enemy
    public float agroDistance; // The distance at which to start reacting to the player
    
    private Transform target; //a variable for enemy to follow the target(player)-
    private Rigidbody2D rb;
    private GroundDetector groundDetector;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//find the player object 
        rb = GetComponent<Rigidbody2D>();
        groundDetector = transform.Find("GroundDetector").GetComponent<GroundDetector>();
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing as we are far away from the player
        if (Vector2.Distance(transform.position, target.position) > agroDistance)
        {
            return;
        }

        // Rotate to face the player
        if (target.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        // We are up against a wall or about to fall so just do nothing
        if (groundDetector.isStuck())
        {
            Debug.Log("Red enemy is stuck");
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

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
