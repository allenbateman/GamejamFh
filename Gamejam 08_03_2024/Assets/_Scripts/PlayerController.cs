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

    [SerializeField]
    private SkinnedMeshRenderer meshRenderer;
    [SerializeField]
    Transform firePoint;

    private float stateTimer;

    private void Start()
    {
        SetPower(normalState);
        playerMovement = GetComponent<Movement>();
        if(meshRenderer == null )
         meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
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
            if(stateTimer <= 0)
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

    public void SetPower(PowerState state)
    {
        currentState = state;
        stateTimer = state.duration;

        meshRenderer.material = currentState.skin;
        Debug.Log("Current state " + state.type.ToString());

        if (currentState.onPowerupParticles != null)
            Instantiate(currentState.onPowerupParticles, firePoint.position, transform.rotation);
    }
}
