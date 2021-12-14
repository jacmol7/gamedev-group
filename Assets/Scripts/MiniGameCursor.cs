using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCursor : MonoBehaviour
{
    MiniGameManager miniGameManager;

    void Start()
    {
        miniGameManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = new Vector3(mousePos.x, mousePos.y, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        miniGameManager.endMiniGame(col.gameObject.tag == "Goal");
    }
}
