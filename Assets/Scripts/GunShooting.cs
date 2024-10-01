using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    // Bullet
    public GameObject myBulletPrefab;
    
    // Bullet force
    public float myBulletSpeed;

    // Gun stats
    public Transform bulletSpawnTransform;

    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        //readyToShoot = true;
        canShoot = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(0) && (canShoot))
        {
            ShootBullet();
            StartCoroutine("ShootDelay");
        }
    }

    void ShootBullet()
    {
        //GameObject projectile = Instantiate(myBulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        GameObject projectile = Instantiate(myBulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * myBulletSpeed;
    }

    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(.3f);
        canShoot = true;
    }
}
