using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletState {Water, Fire, Stone};


    BulletState bulletState;
    public float speed = 10;
    public float damage = 1;
    public float destroyTime = 3;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroyTime);

    }

    // Update is called once per frame
    void Update()
    {
        //stransform.Translate(transform.forward * speed * Time.deltaTime);
        
    }

    public void destroy()
    {
        Destroy(gameObject, 0.5f);
        
    }

    public void setBulletState(BulletState bulletState)
    {
        this.bulletState = bulletState;
    }
}


