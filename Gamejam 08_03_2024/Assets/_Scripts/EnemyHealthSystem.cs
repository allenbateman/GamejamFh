using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;
    Enemy enemy;
    private void OnEnable()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    public void TakeDamage(float damage)
    {
        if(health <= 0)
        {
            Debug.Log("Health: " + health);
            Debug.Log("enemy died");

            if(enemy != null)
                 enemy.releaseEnemy();
         
        }
        health -= damage;
        Debug.Log("Health: " + health);
    }
}
