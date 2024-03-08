using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
     public virtual void Interact()
     {
        BaseInteract();
     }

    public virtual void BaseInteract()
    {
        Debug.Log(gameObject.name + " interacting");
    }
}
