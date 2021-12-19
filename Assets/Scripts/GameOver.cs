using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public bool GameIsOver = false;

    public GameObject GameOverMenu;

    // Start is called before the first frame update
    // public void GameEnded()
    // {
    //     if(GameIsOver)
    //     {   
    //         //Restart();
    //         PauseGame();
    //         Debug.Log("Game Ended");
    //     } 
        
        
    //     // if(GameIsOver == false)
    //     // {
    //     //     // GameIsOver = true;
    //     //     // Debug.Log("Game Over !!!");
    //     //     Restart();
    //     // }
    // }

    public void PauseGame()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        //Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
