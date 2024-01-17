using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerCroissant : MonoBehaviour
{
    private ScoreManager scoreManager;
    public Timer gameTimer; // R�f�rence au script Timer
    public GameManager gameManager; // R�f�rence au script GameManager

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Trouve le ScoreManager dans la sc�ne
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Croissant"))
        {
            Destroy(other.gameObject); // D�truit le croissant
            if (scoreManager != null)
            {
                scoreManager.AddPoint(); // Ajoute un point au score
            }

            if (gameTimer != null)
            {
                gameTimer.AddTime(15.0f); // Ajoute 15 secondes au timer
            }

            if (gameManager != null)
            {
                gameManager.CheckCroissants(); // Appelle la m�thode CheckCroissants du GameManager
            }
        }
    }
}
