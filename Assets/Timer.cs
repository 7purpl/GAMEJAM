using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro
// Utilisez UnityEngine.UI; si vous utilisez le système UI standard de Unity

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // 60 secondes pour une minute
    public TextMeshProUGUI timerText; // Remplacez par public Text si vous utilisez le système UI standard

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Le temps est écoulé
            // Ajoutez ici la logique à exécuter lorsque le temps est écoulé
        }
    }

    public void AddTime(float timeToAdd)
    {
        timeRemaining += timeToAdd;
    }

    private void UpdateTimerDisplay()
    {
        // Affichage du temps restant en format mm:ss
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
