using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen; // Référence au Panel de l'écran de fin
    public GameObject loseScreen; // Référence au Panel de l'écran de défaite
    public Timer gameTimer; // Référence au script Timer

    public void CheckCroissants()
    {
        var allCroissants = GameObject.FindGameObjectsWithTag("Croissant");
        // Vérifiez si tous les croissants sont récupérés
        if (allCroissants.Length == 1)
        {
            winScreen.SetActive(true); // Active l'écran de fin
            gameTimer.StopTimer(); // Arrête le timer
        }

        Debug.Log(allCroissants.Length);
    }

    // Méthode pour afficher l'écran de défaite
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
