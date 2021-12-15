using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed; 

    private Transform player; 

    private Vector2 target;

    public GameObject explode;
    float removeTime = 2.0f; 

    public LayerMask layerMask; 
     

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);//the target will spawn at the same position as player 

        //terrain = GameObject.FindGameObjectWithTag("Terrain");

        Destroy(gameObject, removeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //bullet is spawn and register the player position
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            OnDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnDestroy();
            other.GetComponent<PlayerHealth>().TakeDamage();
        }
        if(other.gameObject.tag == "Terrain")
        {
            OnDestroy();
            Debug.Log("???");
        }
        
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
        
    // }

    void OnDestroy()
    {
        Destroy(gameObject);
        Instantiate (explode, transform.position, transform.rotation);
        //Debug.Log("destroy");
    }
}
