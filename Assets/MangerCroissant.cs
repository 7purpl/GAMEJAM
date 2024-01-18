using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerCroissant : MonoBehaviour
{
    private ScoreManager scoreManager;
    public Timer gameTimer; // R�f�rence au script Timer
    public GameManager gameManager; // R�f�rence au script GameManager
    public AudioSource eatSound; // R�f�rence � l'AudioSource pour l'effet sonore

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Trouve le ScoreManager dans la sc�ne
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Croissant"))
        {
            Destroy(other.gameObject); // D�truit le croissant

            // Jouer le son de manger un croissant
            if (eatSound != null)
            {
                eatSound.Play();
            }

            if (scoreManager != null)
            {
                scoreManager.AddPoint(); // Ajoute un point au score
            }

            if (gameTimer != null)
            {
                gameTimer.AddTime(30.0f); // Ajoute 30 secondes au timer
            }

            if (gameManager != null)
            {
                gameManager.CheckCroissants(); // Appelle la m�thode CheckCroissants du GameManager
            }
        }
    }
}
