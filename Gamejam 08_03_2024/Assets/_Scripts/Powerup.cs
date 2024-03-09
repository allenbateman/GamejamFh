using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    PowerState powerState;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController controller;
        if(other.TryGetComponent<PlayerController>(out controller))
        {
            controller.SetPower(powerState);
            Debug.Log("Powerup: " + powerState.type.ToString());
        }
    }
}
