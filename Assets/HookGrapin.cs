using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;
    public float hookTravelSpeed;
    public float playerTravelSpeed;
    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    void Update()
    {
        // Tirer le grappin
        if (Input.GetMouseButtonDown(0) && !fired)
        {
            fired = true;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hook.transform.position = hit.point;
                hookedObj = hit.collider.gameObject;
                hooked = true;
            }
        }

        // Le grappin se déplace vers l'avant
        if (fired && !hooked)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
        }

        // Joueur se déplace vers le grappin
        if (hooked)
        {
            hookHolder.transform.position = Vector3.MoveTowards(hookHolder.transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            if (distanceToHook < 1)
            {
                if (!Physics.Raycast(transform.position, Vector3.down, 3f))
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 150f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 19.6f);
                }
            }
        }

        // Relâcher le grappin
        if (Input.GetMouseButtonDown(1))
        {
            fired = false;
            hooked = false;
        }
    }
}
