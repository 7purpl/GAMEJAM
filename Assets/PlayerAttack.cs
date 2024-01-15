using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackForce = 500f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // 0 pour le clic gauche
            Attack();
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
            }
        }

        // D?clencher animation/effet ici si n?cessaire
    }
}
