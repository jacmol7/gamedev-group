using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Transform target;
    public float speed; 
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 direction = target.position - transform.position;
        
        if(Vector2.Distance(transform.position, target.position)> 0.1 ) {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Debug.Log("hi");
        }
    }
}
