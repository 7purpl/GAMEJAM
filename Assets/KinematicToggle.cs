using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicToggle : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("salut");
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Récupère le Rigidbody de l'objet avec lequel le personnage entre en collision
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Salutt");
        // Vérifie si l'objet a un Rigidbody et si "Is Kinematic" est actif
        if (rb != null && rb.isKinematic)
        {
            // Désactive "Is Kinematic", permettant à l'objet de répondre physiquement
            rb.isKinematic = false;
        }
    }
}
