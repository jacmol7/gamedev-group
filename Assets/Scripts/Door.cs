using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IMiniGameTrigger
{
    public GameObject gameOverScreen;

    bool triggered;
    MiniGameManager miniGameManager;

    void Start()
    {
        triggered = false;
        miniGameManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if (!triggered && col.gameObject.tag == "Player")
        {
            triggered = true;
            miniGameManager.loadRandomGame(this);
        }
    }

    public void onMiniGameEnd(bool success)
    {
        if (success)
        {
            StartCoroutine("open");
        }
        else
        {
            gameOverScreen.GetComponent<GameOver>().PauseGame();
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
