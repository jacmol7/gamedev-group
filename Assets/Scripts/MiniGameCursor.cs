using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCursor : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = new Vector3(mousePos.x, mousePos.y, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Failed");
    }
}
