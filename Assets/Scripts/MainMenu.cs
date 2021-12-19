using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() //button function to play the game 
    {
        SceneManager.LoadScene("Level1"); //load the game 
        Time.timeScale = 1.0f;
    }

    public void QuitGame() //quite game button 
    {
        Application.Quit(); //quit the application 
        Debug.Log("Quit Game!"); //just to show the function is work with unity 
    }
}
