using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameTimer : MonoBehaviour
{
    public float timerLength;
    public Slider timerSlider;

    private MiniGameManager miniGameManager;
    private float timeRemaining;

    void Start()
    {
        miniGameManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
    }

    void OnEnable()
    {
        // Start the timer as soon as this is enabled as this will be enabled
        // only as the mini game is started
        timeRemaining = timerLength;
        timerSlider.maxValue = timerLength;
        timerSlider.value = timerLength;
        StartCoroutine("Timer");
    }

    private IEnumerator Timer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= 0.1f;
            timerSlider.value = timeRemaining;
            yield return new WaitForSeconds(0.1f);
        }
            
        timerSlider.value = 0;
        miniGameManager.endMiniGame(false);
    }
}
