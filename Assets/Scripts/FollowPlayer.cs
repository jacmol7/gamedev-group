using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D playerRB;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector3(playerRB.position.x, playerRB.position.y, transform.position.z);
    }
}
