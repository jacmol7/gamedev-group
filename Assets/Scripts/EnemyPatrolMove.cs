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

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //set the direction to the right, making the speed as a real time 

        RaycastHit2D ray = Physics2D.Raycast(groundDetect.position, Vector2.down, distance, LayerMask.GetMask("Ground")); //vector2 check whther if the enemy is dectected the ground, layer mask for the enemy to detect the ground mask layer 
        if (ray.collider == false) //statement if raycast isn;t collide with anything  
        {
            if (movingRight == false)//if enemy the enemy is moving to the left 
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //reset the y value to 0 
                movingRight = true; //enemy move to right if it hits the edge or wall 
            }
            else //if the enenmy is moving to the right 
            {
                transform.eulerAngles = new Vector3(0, -180, 0); //rotate the enemy 180 degree on y-axis 
                movingRight = false; //enemy move to left if it hits the edge or wall 
                
            }
        }
    }
}
    

