using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false; //setting the game pause to false 

    public GameObject pauseMenu; //pause menu game object 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //apply functon when click on esc 
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //load the main menu
    }
}
