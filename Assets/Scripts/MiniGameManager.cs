using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    AsyncOperation sceneLoad;
    Scene returnScene;
    Scene curMiniGame;
    List<GameObject> objectsToReenable;
    IMiniGameTrigger initiator;
    bool inGame;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        inGame = false;

        sceneLoad = SceneManager.LoadSceneAsync("MiniGame", LoadSceneMode.Additive);
        sceneLoad.allowSceneActivation = false;
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

            sceneLoad.allowSceneActivation = true;
            sceneLoad.completed += (asyncOperation) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("MiniGame"));
                curMiniGame = SceneManager.GetSceneByName("MiniGame");

                int level = Random.Range(1, 3);
                GameObject levels = GameObject.Find("Levels");
                levels.transform.Find("Level"+level).gameObject.SetActive(true);
            };
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

        AsyncOperation unloadMiniGame = SceneManager.UnloadSceneAsync(curMiniGame);
        unloadMiniGame.completed += (asyncOperation) =>
        {
            for (int i = 0; i < objectsToReenable.Count; i++)
            {
                objectsToReenable[i].SetActive(true);
            }

            objectsToReenable.Clear();
            inGame = false;

            SceneManager.SetActiveScene(returnScene);

            initiator.onMiniGameEnd(success);
        };

        sceneLoad = SceneManager.LoadSceneAsync("MiniGame", LoadSceneMode.Additive);
        sceneLoad.allowSceneActivation = false;
    }
}