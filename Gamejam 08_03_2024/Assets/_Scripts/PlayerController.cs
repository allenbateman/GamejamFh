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

    private AudioSource audioSource;

    [SerializeField]
    private SkinnedMeshRenderer meshRenderer;
    [SerializeField]
    Transform firePoint;

    private float stateTimer;

    [SerializeField]
    private Animator animator;

    bool canShoot;
    public float fireRate = 0.2f;
    private float shootTimer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        canShoot = true;
        
        SetPower(normalState);
        
        playerMovement = GetComponent<Movement>();

        if(meshRenderer == null )
         meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        
        if(animator == null)
            animator = GetComponent<Animator>();
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

        shootTimer -= Time.deltaTime;   
        if(shootTimer <= 0)
        {
            shootTimer = 0;
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                Shoot();
                shootTimer = fireRate;
            }
        }

    }

    void Shoot()
    {
        GameObject instantiatedBullet = Instantiate(currentState.bullet, firePoint.position, transform.rotation);
        animator.SetTrigger("Attack");
        audioSource.clip = currentState.bulletSound;
        audioSource.Play(); 
    }

    public void SetPower(PowerState state)
    {
        currentState = state;
        Debug.Log("Current state " + state.type.ToString());
        canShoot = false;
        animator.SetTrigger("Jump");
    }
    public void Transition()
    {
        canShoot = true;
        meshRenderer.material = currentState.skin;
        stateTimer = currentState.duration;
        if (currentState.onPowerupParticles != null)
            Instantiate(currentState.onPowerupParticles, firePoint.position, transform.rotation);
    }
}
