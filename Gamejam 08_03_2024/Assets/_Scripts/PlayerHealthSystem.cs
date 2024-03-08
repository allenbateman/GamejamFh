using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        if(health <= 0)
        {
            Debug.Log("game over");
            return;
        }
        health -= damage;
    }
}
