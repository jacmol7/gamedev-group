using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public bool GameIsOver = false; 

    public GameObject GameOverMenu; //Game over menu object 
    



    // Start is called before the first frame update
    // void Update()
    // {
    //     if(GameIsOver)
    //     {   
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

    public void PauseGame() //pause game menu when game is over 
    {
        GameOverMenu.SetActive(true); //show up the game over scene when game is over 
        Time.timeScale = 0f; //stop the game running when game is over 
        GameIsOver = true;
    }

    public void Restart() //button function to restart the game 
    {
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the game 
        Time.timeScale = 1f; //setting the game back to normal time 
    }

    public void MainMenu() //button function to go to main menu 
    {
        SceneManager.LoadScene("Menu"); //load the menu scene 
        GameIsOver = false;
        Time.timeScale = 1f;
    }
}
