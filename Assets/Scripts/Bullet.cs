using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE Bullet ingerit all the atributes from Projectile class
public class Bullet : Projectile
{
    public override void RotateProjectile()
    {
        transform.Rotate(90, 0, 0);
    }
}
