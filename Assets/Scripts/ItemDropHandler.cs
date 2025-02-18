using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Folosim onCollison...  verificam daca este pe ground ea ne va face activ daca itemul este daca nu va fi default
        if (collision.gameObject.CompareTag("Ground")) // trebuie sa te asiguri ca solul are Ground| Verifica daca are dar daca nu in inspector adaugal|
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // activam
            }

            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true; // activam trigerul
            }

            Debug.Log("Item sa atins de sol si acuma este activatkinematic si triger");
        }
    }
}
