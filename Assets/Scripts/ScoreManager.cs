using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score = 0;
    int highscore = 0;
  

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " P";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

  public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " P";
        if(highscore<score)
            PlayerPrefs.SetInt("highscore", score);
    }


}
