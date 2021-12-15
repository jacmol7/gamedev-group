using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player; 
     
    public float speed; //speed of enemy movement 
    public float distanceToPlayer;//stopping distance from player 
    public float retreatDistance; //when enemy back away from player 

    private float timeBetweenShoot = 3; 
    public float startShootingTime; 

    public GameObject shooting;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //timeBetweenShoot = startShootingTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > distanceToPlayer)
        {//enemy moves closer to target when it's too far away 
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);   
        } 
        else if (Vector2.Distance(transform.position, player.position) < distanceToPlayer && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {//stop moving if it's too close
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBetweenShoot <= 0)
        {
            Instantiate(shooting, transform.position, Quaternion.identity);//instantiate the bullets

            //timeBetweenShoot = Time.deltaTime;
            timeBetweenShoot = startShootingTime; //prevent spamming shoots
            //Debug.Log("hi");

        } 
        else 
        {
            timeBetweenShoot -= Time.deltaTime; 
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            //Destroy(gameObject);
            Debug.Log("Destroy Enemy1, Reduce player's health");
        }

    }

}
