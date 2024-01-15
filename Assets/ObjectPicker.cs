using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupDistance = 5f;
    public float throwForce = 10f;
    private GameObject pickedObject = null;
    private Vector3 lastMousePosition;

    void Update()
    {
        HandlePickup();
        HandleThrow();
    }

    void HandlePickup()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance, LayerMask.GetMask("Pickable")))
            {
                PickObject(hit.collider.gameObject);
            }
        }
    }

    void HandleThrow()
    {
        if (pickedObject != null && Input.GetMouseButtonUp(1))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            Vector3 throwDirection = playerCamera.transform.forward + mouseDelta.normalized;
            ThrowObject(throwDirection);
        }

        lastMousePosition = Input.mousePosition;
    }

    void PickObject(GameObject obj)
    {
        if (pickedObject != null) return;

        pickedObject = obj;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        obj.transform.SetParent(playerCamera.transform);
        obj.transform.localPosition = new Vector3(0, 0, 2); // Adjust as necessary
    }

    void ThrowObject(Vector3 direction)
    {
        if (pickedObject == null) return;

        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        pickedObject.transform.SetParent(null);
        rb.AddForce(direction * throwForce, ForceMode.Impulse);

        pickedObject = null;
    }
}

