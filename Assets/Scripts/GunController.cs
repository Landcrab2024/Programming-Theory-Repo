using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Gun stats
    public Transform bulletSpawnTransform;
    private float fireRate = 0.3f;
    private float nextFire;
    private ProjectileHandler myProjectilehandler;
    //private int projectileNumber = 0;
    private float defaultProjSpeed = 5f;
    public GameObject defaultProjectile;

    // Start is called before the first frame update
    void Start()
    {
        myProjectilehandler = GetComponent<ProjectileHandler>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // ABSTRACTION use of the handled inputs to the MyInput function
        MyInput();
    }

    void MyInput()
    {
        // ABSTRACTION function, called in LateUpdate()
        if (Input.GetKeyDown(KeyCode.P))
        {
            nextFire = Time.time + fireRate;
            ShootProjectile();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            nextFire = Time.time + fireRate;
            ShootProjectile(2);
        }
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootProjectile(0);
        }
        if (Input.GetMouseButton(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootProjectile(1, 5f);
        }
    }


    // POLYMORPHISM Same method can be called with different inputs
    public virtual void ShootProjectile()
    {
        GameObject projectile = Instantiate(defaultProjectile, bulletSpawnTransform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * defaultProjSpeed;
    }
    public virtual void ShootProjectile(int projNr)
    {
        GameObject projectile = Instantiate(myProjectilehandler.projectiles[projNr], bulletSpawnTransform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * myProjectilehandler.GetProjectileSpeed(projNr);
    }
    public virtual void ShootProjectile(int projNr, float projSpd)
    {
        GameObject projectile = Instantiate(myProjectilehandler.projectiles[projNr], bulletSpawnTransform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * projSpd;
    }
}
