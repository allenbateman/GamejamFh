using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColisionHandler : MonoBehaviour
{
    EnemyHealthSystem EnemyhealthSystem;

    private void Start()
    {
        EnemyhealthSystem = new EnemyHealthSystem();
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

        Bullet bullet;
        if (collision.gameObject.TryGetComponent<Bullet>(out bullet))
        {
            EnemyhealthSystem.TakeDamage(bullet.damage);
        }
    }
}
