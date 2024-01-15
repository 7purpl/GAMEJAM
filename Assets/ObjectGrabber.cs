using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectGrabber : MonoBehaviour
{
    public float grabDistance = 5f;
    private Rigidbody grabbedObject = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (grabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (grabbedObject != null)
        {
            MoveObject();
        }
    }

    void TryGrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
        {
            if (hit.collider.GetComponent<Rigidbody>() != null)
            {
                grabbedObject = hit.collider.GetComponent<Rigidbody>();
                // Vous pouvez désactiver la gravité si nécessaire
                // grabbedObject.useGravity = false;
            }
        }
    }

    void MoveObject()
    {
        // Déplacez l'objet ici, par exemple, devant le joueur ou la caméra
        grabbedObject.position = transform.position + transform.forward * 2; // 2 mètres devant le joueur
    }

    void ReleaseObject()
    {
        // Réactivez la gravité si elle a été désactivée
        // grabbedObject.useGravity = true;
        grabbedObject = null;
    }
}
