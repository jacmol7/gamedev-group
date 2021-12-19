using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health; //health of the player 
    public int numOfHearts; //number of heart images 

    public Image[] hearts; //an array for the hearts 
    public Sprite fullHeart; //image of the full hearts 
    public Sprite emptyHeart; //image of the empty hearts 
    public GameObject gameOverScene;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts) //check when health is greater than number of hearts 
        {
            health = numOfHearts; //setting health to num of hearts variable 
        }

        for(int i = 0; i < hearts.Length; i++) //for-loop when i is smaller than hearts length
        {
            if(i < health)//check if i is smaller than health
            {
                hearts[i].sprite = fullHeart; //for heart i to display a full heart 
            }
            else 
            {
                hearts[i].sprite = emptyHeart;//for heart ito display an empty heart 
            }

            if(i < numOfHearts)//check if the i is smaller than number of hearts
            {
                hearts[i].enabled = true;  //making the heart visible 
            }
            else
            {
                hearts[i].enabled = false; //making the heart invisible 
            }
        }
    }

    public void TakeDamage() //reducing health 
    {
        health --; //minus one health when take damage 
        if(health <= 0) //when health is zero 
        {
            gameOverScene.GetComponent<GameOver>().PauseGame(); //call the game over scene 
        }
    }
}
