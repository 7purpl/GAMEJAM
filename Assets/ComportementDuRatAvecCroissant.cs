using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assurez-vous d'avoir un élément UI TextMeshProUGUI dans la scène
    private int score = 0;

    public void AddPoint()
    {
        score++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Croissants récupérés : " + score.ToString() + "/20";
        }
    }
}
