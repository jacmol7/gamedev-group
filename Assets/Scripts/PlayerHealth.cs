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
    public GameObject gameOverScene; //game over scene game object
    public float bufferTime; //making player invulneraable in 1.0f 
    private bool invulnerable; //a bool for invulnerable 
    
    
    private GameOver gameOverScript;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOverScript = gameOverScene.GetComponent<GameOver>();
    }

    void Awake()
    {
        // The player has been created or became alive again.
        // Ensure the game is running
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScript.GameIsOver)
        {
            return;
        }

        if(health > numOfHearts) //check when health is greater than number of hearts 
        {
            health = numOfHearts; //setting health to num of hearts variable 
        }

        for(int i = 0; i < hearts.Length; i++) //for-loop when i is smaller than hearts length
        {
            if(i < health)//check if i is smaller than health
            {
                hearts[i].sprite = fullHeart; //for heart i to display a full heart d
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

        // Kill the player if they fall off the map
        if (transform.position.y < -15)
        {
            gameOverScript.PauseGame();
        }
    }

    public void TakeDamage() //reducing health 
    {
        if(!invulnerable) //when the player isn't invulnerable 
        {
            health --; //minus one health when take damage 
            StartCoroutine(BufferCoolDown()); //start the coroutine for buffer cool down 
        }
        
        if(health <= 0) //when health is zero 
        {
            gameOverScript.PauseGame();
        }
    }

    IEnumerator BufferCoolDown()  //function for coroutine 
    {
        invulnerable = true; //making the player invulnerable 
        yield return new WaitForSeconds(bufferTime);//wait for 1f until player can get hits again.
        invulnerable = false; //making the player vulnerable 
    }
}
