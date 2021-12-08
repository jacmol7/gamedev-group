using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMove : MonoBehaviour
{
    public float speed;

    public Transform groundCheck;

    [HideInInspector]
    public bool patrol;
    [HideInInspector]
    public bool mustFlip;

    public Rigidbody2D rb;

    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(patrol)
        {
            Movement();
        }
    }

    private void FixedUpdate()
    {
        if(patrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Movement()
    {
        if(patrol)
        {
            TurnAround();
        }
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    void TurnAround()
    {
        patrol = false;
        transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        speed *= -1; //multiply by -1, switiching the value between positive and negative
        patrol = true;
    }
}
