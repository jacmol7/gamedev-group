using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Color color; //color 
    public float destroySpeed = 0.2f; //destroy speed of the explosion 
    
    // Start is called before the first frame update
    void Start()
    {
       color = GetComponent<SpriteRenderer>().color;//getting the componenmt Sprite Renderer 
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(color.a,color.b,color.g,color.r -= destroySpeed * Time.deltaTime);//transform the colour when it instantiates 
        if(color.r <= 0)//when the last colour show up
        {
            Destroy(gameObject);//destroy the game object 
        }
    }
}
