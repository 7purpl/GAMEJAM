using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // 60 secondes pour une minute
    public TextMeshProUGUI timerText; // Remplacez par public Text si vous utilisez le syst�me UI standard
    private bool timerIsRunning = true; // Ajout d'un contr�le pour le timer
    private GameManager gameManager; // R�f�rence au GameManager

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Trouve le GameManager dans la sc�ne
    }

    private void Update()
    {
        if (timerIsRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (timerIsRunning && timeRemaining <= 0)
        {
            timerIsRunning = false;
            gameManager.ShowLoseScreen(); // Affiche l'�cran de d�faite
        }
    }

    public void AddTime(float timeToAdd)
    {
        if (timerIsRunning)
        {
            timeRemaining += timeToAdd;
        }
    }

    public void StopTimer() // M�thode pour arr�ter le timer
    {
        timerIsRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        // Affichage du temps restant en format mm:ss
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

