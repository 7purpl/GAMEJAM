using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen; // R�f�rence au Panel de l'�cran de fin
    public GameObject loseScreen; // R�f�rence au Panel de l'�cran de d�faite
    public Timer gameTimer; // R�f�rence au script Timer

    public void CheckCroissants()
    {
        var allCroissants = GameObject.FindGameObjectsWithTag("Croissant");
        // V�rifiez si tous les croissants sont r�cup�r�s
        if (allCroissants.Length == 1)
        {
            winScreen.SetActive(true); // Active l'�cran de fin
            gameTimer.StopTimer(); // Arr�te le timer
        }

        Debug.Log(allCroissants.Length);
    }

    // M�thode pour afficher l'�cran de d�faite
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
