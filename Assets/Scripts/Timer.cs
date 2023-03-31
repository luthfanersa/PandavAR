using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public TextMeshProUGUI currentTimeText;
    // Start is called before the first frame update
    public void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.instance.score);
    }
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                GameOver();
                timerActive = false;
                Time.timeScale = 0f;
                //Start();
                Debug.Log("Timer finished.");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
