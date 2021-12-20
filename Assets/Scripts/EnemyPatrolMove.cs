using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMove : MonoBehaviour
{
    public float speed; //the speed of the enemy 

    private bool movingRight = true; //bool that set moving right to true 

    public Transform groundDetect;  //for the enemy to detect whether there is a ground 

    public LayerMask layerMask; //a layer mask for the wall detection 

    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //set the direction to the right, making the speed as a real time 

        // Check if we are about to fall of a cliff by casting a ray downwards just infront of us and ensuring it 
        // touches the ground
        RaycastHit2D downRay = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
        // Check if we are about to run into a wall by casting a ray slightly infront
        RaycastHit2D fowardRay = Physics2D.Raycast(groundDetect.position, Vector2.up, 0.5f, LayerMask.GetMask("Ground"));
        if (!downRay.collider || fowardRay) //statement if raycast isn;t collide with anything  
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
    

