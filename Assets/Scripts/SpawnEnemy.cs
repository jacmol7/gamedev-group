using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed; 

    [SerializeField]
    private Vector3[] position; 

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnemyMovement()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, position[index], Time.deltaTime * speed);

        if (transform.position == position[index])
        {
            if(index == position.Length -1)
            {
                index = 0;
                Debug.Log("movement2");
            }
            else 
            {
                index++;
                Debug.Log("movement3");
            }
        }
        Debug.Log("movement");
    }
}
