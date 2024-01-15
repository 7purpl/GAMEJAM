using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallClimber : MonoBehaviour
{
    public float climbSpeed = 5f;
    public string climbableTag = "climbableTag"; // Tag des murs escaladables

    private bool isClimbing = false;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckForClimbableWall();

        if (isClimbing)
        {
            Climb();
        }
    }

    void CheckForClimbableWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag(climbableTag) && Input.GetKeyDown(KeyCode.Space))
            {
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }
    }

    void Climb()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 climbDirection = new Vector3(0, verticalInput, 0);
        characterController.Move(climbDirection * climbSpeed * Time.deltaTime);

        // Pour arrêter l'escalade
        if (verticalInput == 0 || !characterController.isGrounded)
        {
            isClimbing = false;
        }
    }
}

