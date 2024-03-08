using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        if(health <= 0)
        {
            Debug.Log("enemy died");
            return;
        }
        health -= damage;
    }
}
