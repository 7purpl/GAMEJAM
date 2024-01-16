using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerCroissant : MonoBehaviour
{
    private ScoreManager scoreManager;
    public Timer gameTimer; // Référence au script Timer

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Trouve le ScoreManager dans la scène
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Croissant"))
        {
            Destroy(other.gameObject); // Détruit le croissant
            if (scoreManager != null)
            {
                scoreManager.AddPoint(); // Ajoute un point au score
            }

            if (gameTimer != null)
            {
                gameTimer.AddTime(5.0f); // Ajoute 5 secondes au timer
            }
        }
    }
}
