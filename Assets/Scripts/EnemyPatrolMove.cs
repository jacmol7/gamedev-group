using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMove : MonoBehaviour
{
    public float speed; //the speed of the enemy 

    private bool movingRight = true; //bool that set moving right to true 

    private GroundDetector groundDetector;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7, true);
        groundDetector = transform.Find("GroundDetector").GetComponent<GroundDetector>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //set the direction to the right, making the speed as a real time 

        // Turn around if we are either about to fall of a cliff or run into a wall.
        // The rotation must be done in this way to ensure the child used for ground detection
        // is always facing in the correct direction
        if (groundDetector.isStuck())
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            movingRight = !movingRight;
        }
    }
}
    

