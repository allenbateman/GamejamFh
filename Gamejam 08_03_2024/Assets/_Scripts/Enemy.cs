using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotationSpeed = 5.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        Quaternion newrot = Quaternion.LookRotation(dir);
        rb.rotation = Quaternion.RotateTowards(rb.rotation, newrot, Time.deltaTime * rotationSpeed);
    }
}