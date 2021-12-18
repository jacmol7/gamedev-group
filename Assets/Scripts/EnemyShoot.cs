using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player; //a variable for the missle to follow the player 
     
    public float speed; //speed of enemy movement 
    public float distanceToPlayer;//stopping distance from player 
    public float retreatDistance; //the distance that enemy back away from player 

    private float timeBetweenShoot = 3; //the shooting time between missle launches 
    public float startShootingTime; 

    public GameObject shooting;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find the Player object 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > distanceToPlayer)//check how far the enemy is from the player
        {//enemy moves closer to target when it's too far away 
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);  //moving toward the player 
        } 
        else if (Vector2.Distance(transform.position, player.position) < distanceToPlayer && Vector2.Distance(transform.position, player.position) > retreatDistance)//check if enemy is too close to the player, when the player distance to enemy is smaller than distance to the player and greater than the retreat distance  
        {
            transform.position = this.transform.position;//enemy stop moving to the player 
        }

        if(timeBetweenShoot <= 0)
        {
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
