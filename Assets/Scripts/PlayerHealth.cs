using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)//check if i is smaller than health
            {
                hearts[i].sprite = fullHeart; 
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
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

    public void TakeDamage()
    {
        health --;
        if(health <= 0)
        {
            FindObjectOfType<GameOver>().GameEnded();
        }
    }
}
