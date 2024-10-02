using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE Ball ingerit all the atributes from Projectile class
// Code in this class will add extra upward force
public class Baloon : Projectile
{
    public float upwardForce = 10f;

    // Update is called once per frame
    void Update()
    {
        // Code in this class will add extra upward force
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.up * upwardForce * Time.deltaTime, ForceMode.Force);
    }
}
