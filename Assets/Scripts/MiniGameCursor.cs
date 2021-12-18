using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCursor : MonoBehaviour
{
    MiniGameManager miniGameManager;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        miniGameManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
    }

    void Update()
    {
        // Move the cursor based off mouse movement rather than using the position.
        // This allows the game cursor to start anywhere regardless of where the mouse is
        transform.position += new Vector3(Input.GetAxis("Mouse X") * 0.1f, Input.GetAxis("Mouse Y") * 0.1f, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        miniGameManager.endMiniGame(col.gameObject.tag == "Goal");
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
