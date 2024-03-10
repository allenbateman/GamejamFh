using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CarrotSystem : MonoBehaviour
{
    public int Health = 100;

    [SerializeField]
    Slider healthBar;
    void Start()
    {
        healthBar.value = Health * .01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        Enemy enemy;
        if (collision.gameObject.TryGetComponent<Enemy>(out enemy))
        {
            Health -= (int)enemy.damage;
            healthBar.value = Health * .01f;
            if (Health <=0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
