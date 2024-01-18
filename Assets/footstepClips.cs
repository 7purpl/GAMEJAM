using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepSound;
    public AudioClip[] footstepClips; // Tableau de clips audio pour les pas
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.clip = footstepClips[Random.Range(0, footstepClips.Length)];
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}
