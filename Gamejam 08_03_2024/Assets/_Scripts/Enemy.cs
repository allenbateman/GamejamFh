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

    [SerializeField] 
    GameObject deathVfx;

    public PowerTypes power;

    EnemySpawner spawner;

    EnemyHealthSystem EnemyHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Carrot").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        health = 10;
    }
    void Update()
    {

        if (target == null) return;

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        { 
            Destroy(gameObject);
        }
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
        CarrotSystem carrotSystem;
        if(collision.gameObject.TryGetComponent<CarrotSystem>(out carrotSystem))
        {
            Instantiate(deathVfx, transform.position + new Vector3(0,1,0),Quaternion.identity);
            Destroy(gameObject);
        }




        Bullet bullet;
        if (collision.gameObject.TryGetComponent<Bullet>(out bullet))
        {

            Debug.Log("bullet type: " + bullet.powerType);
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

                            Debug.Log("No damage");
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
                            Debug.Log("No damage");
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
                            Debug.Log("No damage");
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