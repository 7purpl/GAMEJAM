using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    public float climbSpeed = 5f;
    public float detectionDistance = 1f; // Distance à laquelle le mur est détecté
    public LayerMask climbableLayer; // Définir les layers considérés comme escaladables

    private Rigidbody rb;
    private bool isClimbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForWall();

        if (isClimbing)
        {
            // Gestion du mouvement d'escalade
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(rb.velocity.x, verticalInput * climbSpeed, rb.velocity.z);
        }
    }

    void CheckForWall()
    {
        RaycastHit hit;
        // Tirer un raycast devant le personnage
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance, climbableLayer))
        {
            if (!isClimbing)
            {
                StartClimbing();
            }
        }
        else
        {
            if (isClimbing)
            {
                StopClimbing();
            }
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        rb.useGravity = false;
        // Autres initialisations pour l'escalade
    }

    void StopClimbing()
    {
        isClimbing = false;
        rb.useGravity = true;
        // Réinitialiser les paramètres après l'escalade
    }
}


