using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    public static Stopwatch instance;

    bool stopwatchActive = false;
    float currentTime;
    public TextMeshProUGUI currentTimeText;

    //score
    public int score = 0;
    int highscore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public float multiplier = 5;
    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscoreSW", 0);
        currentTime = 0;
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            
        }
        score =Mathf.RoundToInt( currentTime * multiplier);
        scoreText.text = score.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\fff");
        if (highscore < score)
            PlayerPrefs.SetInt("highscoreSW", score);
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;
    }
    
    public void StopTimer()
    {
        stopwatchActive = false;
    }
}
