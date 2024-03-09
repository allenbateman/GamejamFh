using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerTypes
{
    None,
    Fire,
    Water,
    Earth
}
public class PlayerController : MonoBehaviour
{
    Movement playerMovement;
    PowerState currentState;
    [SerializeField]
    PowerState normalState;

    private float stateTimer;
    public void SetPower(PowerState state)
    {
        currentState = state;
        stateTimer = state.duration;
        Debug.Log("Set " + state.type.ToString());
    }
    private void Start()
    {
        SetPower(normalState);
        playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (currentState == null)
        {
            Debug.Log("NO state is set");
            return;
        }

        if(currentState.type != PowerTypes.None)
        {
            stateTimer -= Time.deltaTime;

            if(stateTimer < 0)
            {
                SetPower(normalState);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

         GameObject instantiatedBullet = Instantiate(currentState.bullet, transform.position, transform.rotation);

    }
}
