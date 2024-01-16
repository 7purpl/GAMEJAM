using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assurez-vous d'avoir un �l�ment UI TextMeshProUGUI dans la sc�ne
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
            scoreText.text = "Croissants r�cup�r�s : " + score.ToString() + "/20";
        }
    }
}
