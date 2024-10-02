using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    private GunController myGunController;
    public GameObject[] projectiles;

    //private float defaultProjectileSpeed = 5f;
    //private float defaultProjectileMaxLifeTime = 5f;



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("projectiles:" + projectiles.Length);
        myGunController = GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetProjectileSpeed()
    {
        //projectiles[0] = defaultProjectileSpeed;
    }

    public float GetProjectileSpeed(int projNr)
    {
        Debug.Log("GetProjectileSpeed(int projNr)");
        return projectiles[projNr].GetComponent<Projectile>().GetProjectileSpeed();
    }
}
