using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public Vector2 startPos;

    Scene returnScene;
    Scene curMiniGame;
    List<GameObject> objectsToReenable;
    IMiniGameTrigger initiator;
    bool inGame;

    private static MiniGameManager _instance;

    void Awake()
    {
        SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        inGame = false;
    }

    public void loadRandomGame(IMiniGameTrigger trigger)
    {
        if (!inGame)
        {
            inGame = true;
            initiator = trigger;

            returnScene = SceneManager.GetActiveScene();
            GameObject[] returnObjects = returnScene.GetRootGameObjects();
            objectsToReenable = new List<GameObject>();
            for (int i = 0; i < returnObjects.Length; i++)
            {
                if (returnObjects[i].activeSelf)
                {
                    returnObjects[i].SetActive(false);
                    objectsToReenable.Add(returnObjects[i]);
                }
            }


            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MiniGame"));
            curMiniGame = SceneManager.GetSceneByName("MiniGame");

            // Activate the objects needed for every mini game.
            // E.g the cursor and hud
            GameObject components = GameObject.Find("MiniGameComponents");
            for (int i = 0; i < components.transform.childCount; i++)
            {
                GameObject component = components.transform.GetChild(i).gameObject;
                component.SetActive(true);
                // Set the mouse cursor to its starting position;
                if (component.name == "MouseCursor")
                {
                    component.transform.position = new Vector3(startPos.x, startPos.y, component.transform.position.z);
                }
            }

            // Select a random minigame level
            int level = Random.Range(1, 3);
            GameObject levels = GameObject.Find("Levels");
            levels.transform.Find("Level"+level).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Already in minigame!");
        }
    }

    public void endMiniGame(bool success)
    {
        if (!inGame)
        {
            Debug.LogError("No minigame is loaded");
            return;
        }

        for (int i = 0; i < objectsToReenable.Count; i++)
        {
            objectsToReenable[i].SetActive(true);
        }

        objectsToReenable.Clear();
        inGame = false;

        GameObject components = GameObject.Find("MiniGameComponents");
        for (int i = 0; i < components.transform.childCount; i++)
        {
            components.transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject levels = GameObject.Find("Levels");
        for (int i = 0; i < levels.transform.childCount; i ++)
        {
            levels.transform.GetChild(i).gameObject.SetActive(false);
        }

        SceneManager.SetActiveScene(returnScene);

        initiator.onMiniGameEnd(success);
    }
}