using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    Vector3 aimDirection;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(
            new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        );

        aimDirection = mousePos - this.transform.position;
        aimDirection.Normalize();

        Debug.DrawRay(this.transform.position, aimDirection * 3, Color.red);
    }
}
