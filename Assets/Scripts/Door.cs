using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("open");
        }
    }

    private IEnumerator open()
    {
        while (transform.localScale.y >= 1.1f)
        {
            transform.localScale -= new Vector3(0f, 0.1f, 0f);
            transform.position += new Vector3(0f, 0.1f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
