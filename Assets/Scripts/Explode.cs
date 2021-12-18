using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Color color; 
    public float destroySpeed = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
       color = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(color.a,color.b,color.g,color.r -= destroySpeed * Time.deltaTime);
        if(color.a <= 0)
        {
            Destroy(gameObject);

            //Debug.Log("explosion");
        }
    }
}
