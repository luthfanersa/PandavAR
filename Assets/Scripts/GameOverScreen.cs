using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
   public void Setup(int scoreText)
    {
        gameObject.SetActive(true);
        pointsText.text = scoreText.ToString()+" P";
    }
}
