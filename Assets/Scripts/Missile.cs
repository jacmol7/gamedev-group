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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);//the target will spawn at the same position as player 

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
        if(other.gameObject.tag == "Player" && other.gameObject.tag == "Terrain")
        {
            OnDestroy();
        }

        // if(other.gameObject.tag == "Terrain")
        // {
        //     OnDestroy();
        // }
    }

    void OnDestroy()
    {
        Destroy(gameObject);
        Instantiate (explode, transform.position, transform.rotation);
        Debug.Log("destroy");
    }
}
