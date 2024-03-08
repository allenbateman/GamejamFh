using System.Collections;
using System.Collections.Generic;
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
