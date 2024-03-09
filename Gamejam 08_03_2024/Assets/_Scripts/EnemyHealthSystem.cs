using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health = 100;
    Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    public void TakeDamage(float damage)
    {
        if(health <= 0)
        {
            Debug.Log("Health: " + health);
            Debug.Log("enemy died");
            enemy.releaseEnemy();
         
        }
        health -= damage;
    }
}
