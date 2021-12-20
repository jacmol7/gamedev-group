using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player; //a variable for the missle to follow the player 
     
    public float speed; //speed of enemy movement 
    public float distanceToPlayer;//stopping distance from player 
    public float retreatDistance; //the distance that enemy back away from player
    public float agroDistance; // when the player is atleast this close the enemy will start to react

    private float timeBetweenShoot = 3; //the shooting time between missle launches 
    public float startShootingTime; //prevent to shoot instantly when it comes up 

    public GameObject shooting; //the missile game object 

    public AudioClip shootSound; //sound effect of shooting 

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find the Player object 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector2.Distance(transform.position, player.position);
        
        // We are a long way off screen, don't react to the player yet
        if (currentDistance > agroDistance)
        {
            timeBetweenShoot -= Time.deltaTime;
            return;
        }

        if (currentDistance > distanceToPlayer)
        {//enemy moves closer to target when it's too far away 
            if (player.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }

        if(timeBetweenShoot <= 0)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position); //play the audio clip when the enemy shoot 
            Instantiate(shooting, transform.position, Quaternion.identity);//instantiate the bullets
            timeBetweenShoot = startShootingTime; //prevent spamming shoots
        } 
        else 
        {
            timeBetweenShoot -= Time.deltaTime; //the enemy shoot slower over time 
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)//collision to the player 
    {
        if(collision.gameObject.tag == "Player")//find the game object with tag with player 
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(); //call the method from class player health to take damage
            //Debug.Log("Destroy Enemy1, Reduce player's health");
        }

    }

}
