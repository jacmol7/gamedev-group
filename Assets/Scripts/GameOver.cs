using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject GameOverMenu;

    // Start is called before the first frame update
    public void GameEnded()
    {
        if(GameIsOver)
        {
            Restart();
        }
        else
        {
            MainMenu();
        }
        // if(GameIsOver == false)
        // {
        //     // GameIsOver = true;
        //     // Debug.Log("Game Over !!!");
        //     Restart();
        // }
    }

    void Restart()
    {
        GameOverMenu.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void MainMenu()
    {
        GameOverMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
