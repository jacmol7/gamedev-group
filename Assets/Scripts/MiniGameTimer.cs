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

    void Awake()
    {
        timeRemaining = timerLength;
        timerSlider.maxValue = timerLength;
        timerSlider.value = timerLength;
        StartCoroutine("Timer");
    }

    void Start()
    {
        miniGameManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
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
