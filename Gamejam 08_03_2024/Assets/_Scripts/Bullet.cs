using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 1;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        //stransform.Translate(transform.forward * speed * Time.deltaTime);
        
    }

}
