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
                // Vous pouvez d�sactiver la gravit� si n�cessaire
                // grabbedObject.useGravity = false;
            }
        }
    }

    void MoveObject()
    {
        // D�placez l'objet ici, par exemple, devant le joueur ou la cam�ra
        grabbedObject.position = transform.position + transform.forward * 2; // 2 m�tres devant le joueur
    }

    void ReleaseObject()
    {
        // R�activez la gravit� si elle a �t� d�sactiv�e
        // grabbedObject.useGravity = true;
        grabbedObject = null;
    }
}
