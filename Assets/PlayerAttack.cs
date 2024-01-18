using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackForce = 500f;
    public AudioSource attackSound; // Référence à l'AudioSource pour l'effet sonore d'attaque

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 pour le clic gauche
        {
            Attack();
        }
        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Appliquer une force en avant
                rb.isKinematic = false;
                rb.AddForce(transform.forward * attackForce);

                // Jouer le son d'attaque seulement si une collision est détectée
                if (attackSound != null)
                {
                    attackSound.Play();
                }
            }
        }

        // Autres actions pour l'attaque ici si nécessaire
    }
}
