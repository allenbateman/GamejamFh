using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    public float fireDelay = 1;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {

        Debug.Log("shoot");
        GameObject instantiatedBullet = Instantiate(bullet, transform.position, transform.rotation);      

        yield return new WaitForSeconds(fireDelay);
    }
}
