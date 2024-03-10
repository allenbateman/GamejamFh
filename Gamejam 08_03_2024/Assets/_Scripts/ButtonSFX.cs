using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip onHover;
    public AudioClip onClick;
    
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public void OnHover()
    {
        audioSource.clip = onHover; 
        audioSource.Play();
        animator.SetBool("Hover",true);
    }

    public void OnClick()
    {
        audioSource.clip = onClick;
        audioSource.Play();
    }

    public void OnHoverEnd()
    {
        animator.SetBool("Hover", false);
    }
}
