using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false; //setting the game pause to false 

    public GameObject pauseMenu; //pause menu game object 
    private GameOver gameOverScript; //getting a GameOver varible 
    public GameObject gameOver; //game over sene game object 
    // Update is called once per frame

    void Start()
    {
        gameOverScript = gameOver.GetComponent<GameOver>(); //getting the bool from game over script 
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOverScript.GameIsOver) //apply functon when click on esc and game over is false 
        {
            if(GamePaused) //when game is paused 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        
    }

    public void Resume() //resume the game 
    {
        pauseMenu.SetActive(false); //hide the pause menu when game is resumed 
        Time.timeScale = 1.0f; //set the game to normal time scale 
        GamePaused = false; //make the game knows it's not pausing 
    }

    void Pause() //pause the game 
    {
        pauseMenu.SetActive(true); //show the pasue menu when game is paused 
        Time.timeScale = 0.0f; //stop the game from running 
        GamePaused = true; //make the game knows it's pausing 
    }

    public void LoadMenu() //button function for main menu 
    {
        SceneManager.LoadScene("Menu"); //load the main menu
    }
}
