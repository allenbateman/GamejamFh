using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 1;
    Rigidbody rb;  
    float destroytime = 2;
    public PowerTypes powerType = PowerTypes.None;
    public float damageMultiplier = 1.5f;


    [SerializeField]
    GameObject vfxHit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

    }
    void Update()
    {
        destroytime -= Time.deltaTime;
        if(destroytime < 0) 
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
       Enemy enemy;
       if(collision.gameObject.TryGetComponent<Enemy>(out enemy))
       {
            if(vfxHit != null)
            {
                Instantiate(vfxHit,transform.position, Quaternion.identity);    
            }
            Destroy(gameObject);
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy;
        if (other.gameObject.TryGetComponent<Enemy>(out enemy))
        {
            if (vfxHit != null)
            {
                Instantiate(vfxHit, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
