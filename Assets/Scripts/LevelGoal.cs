using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public GameObject victoryScreen;

    void OnTriggerEnter2D(Collider2D col)
    {
        // Show the victory screen when the player reaches the goal
        if (col.gameObject.name == "Player")
        {
            Time.timeScale = 0f;
            victoryScreen.SetActive(true);
        }
    }
}
