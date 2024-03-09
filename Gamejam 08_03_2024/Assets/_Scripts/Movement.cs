using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    public float speed;
    public float rotationSpeed;

    Vector3 mouseWorldPoss;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0,0,1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }
    }

    void Aim()
    {

        Vector3 direction = Vector3.zero;
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos + new Vector3(0, 0, 50));
        mouseWorldPos.y = 1;

        direction = mouseWorldPos - transform.position;
        direction.y = 0;

        //
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //create a plane at  heigh 1
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0,1,0));
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            mouseWorldPoss = pointToLook;
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction.normalized * speed;
        Aim();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mouseWorldPoss, 1);
    }
}
