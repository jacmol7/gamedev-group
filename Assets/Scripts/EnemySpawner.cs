using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnEnemy; //enemy prefab
    public float spawnTime = 1.0f; //Spawn time
    public float downForce = -2; //down force
    public float minX; //min X spawn location
    public float maxX;//max X spawn location
    public float spawnY; //Y spawn location

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn"); //Start the spawn update
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime); 

        GameObject prefab = spawnEnemy; 

        GameObject go = Instantiate(prefab,new Vector3(Random.Range(minX,maxX+1),transform.position.y,0f),Quaternion.Euler(0,0,Random.Range(-90F,90F))) as GameObject;

        if (go.transform.position.x > 3)
        {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(downForce, transform.position.y));
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
