using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandeler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.collider);
    }
    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }
    void HandleCollision(Collider collision)
    {
        Interactable interactor;
        if (collision.gameObject.TryGetComponent<Interactable>(out interactor))
        {
            interactor.Interact();
        }
    }
}
