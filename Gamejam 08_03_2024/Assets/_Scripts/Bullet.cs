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
       // Destroy(gameObject);
    }

}
