using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMove : MonoBehaviour
{
    public float speed; //the speed of the enemy 
    public float distance;

    private bool movingRight = true; //bool that set moving right to true 

    public Transform groundDetect;  //for the enemy to detect whether there is a ground 

    public LayerMask layerMask; //a layer mask for the wall detection 

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //set the direction to the right, making the speed as a real time 

        RaycastHit2D ray = Physics2D.Raycast(groundDetect.position, Vector2.down, distance, LayerMask.GetMask("Ground")); //vector2 check whther if the enemy is dectected the ground 
        if (ray.collider == false)
        {
            if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                
            }
        }
    }
}
    

