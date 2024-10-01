using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Bullet
    public GameObject myBulletPrefab;
    
    // Bullet force
    public float myBulletSpeed;

    // Gun stats
    public Transform bulletSpawnTransform;
    private float fireRate = 0.3f;
    private float nextFire;
    //bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        //readyToShoot = true;
        //canShoot = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            //Debug.Log("Input.GetMouseButton(0)" + Time.time + "'>'" + "> nextFire");
            nextFire = Time.time + fireRate;
            ShootBullet();
            //StartCoroutine("ShootDelay");
        }
    }

    void ShootBullet()
    {
        //GameObject projectile = Instantiate(myBulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        GameObject projectile = Instantiate(myBulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * myBulletSpeed;
    }

    //IEnumerator ShootDelay()
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(.3f);
    //    canShoot = true;
    //}
}
