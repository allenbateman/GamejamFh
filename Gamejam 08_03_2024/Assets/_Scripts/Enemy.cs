using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotationSpeed = 5.0f;
    Rigidbody rb;
    public float damage;
    public float health;

    public PowerTypes power;

    private ObjectPool<Enemy> _pool;

    EnemyHealthSystem EnemyHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position; 
        Quaternion newrot = Quaternion.LookRotation(dir);
        rb.rotation = Quaternion.RotateTowards(rb.rotation, newrot, Time.deltaTime * rotationSpeed);
    }

    public void setPool(ObjectPool<Enemy> pool)
    {
        _pool = pool;
    }

    public void releaseEnemy()
    {
        _pool.Release(this);
    }


    public void TakeDamage(float damage)
    {
        if (health <= 1)
        { 
            Debug.Log("enemy died");

            releaseEnemy();

        }
        health -= damage;
        Debug.Log("Health: " + health);
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

            switch(bullet.powerType)
            {
                case PowerTypes.None:
                    TakeDamage(bullet.damage);
                    break;

                //bullet
                case PowerTypes.Fire:
                    //enemy
                    switch (power)
                    {
                        case PowerTypes.None:
                            TakeDamage(bullet.damage);
                            break;

                        case PowerTypes.Fire:
                            TakeDamage(bullet.damage);
                            break;

                        case PowerTypes.Water:
                            TakeDamage(bullet.damage * bullet.damageMultiplier);
                            break;

                        case PowerTypes.Earth:
                            //no damage
                            break;
                    }
                    break;

                //bullet
                case PowerTypes.Water:
                    //enemy
                    switch (power)
                    {
                        case PowerTypes.None:
                            TakeDamage(bullet.damage);
                            break;

                        case PowerTypes.Fire:
                            //no damage
                            break;

                        case PowerTypes.Water:
                            TakeDamage(bullet.damage);
                            break;

                        case PowerTypes.Earth:
                            TakeDamage(bullet.damage* bullet.damageMultiplier);
                            break;
                    }
                    break;
                //bullet
                case PowerTypes.Earth:

                    //enemy
                    switch (power)
                    {
                        case PowerTypes.None:
                            TakeDamage(bullet.damage);
                            break;

                        case PowerTypes.Fire:
                            TakeDamage(bullet.damage * bullet.damageMultiplier);
                            break;

                        case PowerTypes.Water:
                            //no damage
                            break;

                        case PowerTypes.Earth:
                            TakeDamage(bullet.damage);
                            break;
                    }
                    break;
            }
        }
    }


}