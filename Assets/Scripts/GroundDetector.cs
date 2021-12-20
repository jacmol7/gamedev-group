using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isStuck()
    {
        return isAtWall() || isAtCliff();
    }

    public bool isAtWall()
    {
        // If this ray touches anything then we are about to hit a wall
        RaycastHit2D fowardRay = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, LayerMask.GetMask("Ground"));
        return fowardRay.collider;
    }

    public bool isAtCliff()
    {
        // If this ray doesn't touch anything then we are about to fall off a cliff
        RaycastHit2D downRay = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
        return !downRay.collider;
    }
}
