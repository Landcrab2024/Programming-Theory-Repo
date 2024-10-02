using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string projectileName;
    //public float projectileSpeed;

    // ENCAPSULATION of the ProjectileSpeed
    [SerializeField] private float m_ProjectileSpeed;  // private m_backingfield for ProjectileSpeed
    [SerializeField]
    public float ProjectileSpeed             // public property ProjectileSpeed
    {
        get { return m_ProjectileSpeed; }    // getter returns backingfield
        set                                 // setter uses backingfield with a validation
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative projectile speed!");
            }
            else
            {
                m_ProjectileSpeed = value;
            }

        }
    }

    // ENCAPSULATION of the ProjectileLifeTime
    [SerializeField] private float m_ProjectileLifeTime;  // private m_backingfield for ProjectileLifeTime
    [SerializeField]
    public float ProjectileLifeTime             // public property ProjectileLifeTime
    {
        get { return m_ProjectileLifeTime; }    // getter returns backingfield
        set                                 // setter uses backingfield with a validation
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative projectile lifetime!");
            }
            else
            {
                m_ProjectileLifeTime = value;
            }

        }
    }
    void Awake()
    {
        
    }
    
    private void Start()
    {
        DestroyAfterTime();
        RotateProjectile();
    }

    void DestroyAfterTime()
    {
        Destroy(this.gameObject, m_ProjectileLifeTime);
    }

    public virtual void RotateProjectile()
    {
        //transform.Rotate(0, 0, 0);
    }

    public float GetProjectileSpeed()
    {
        return m_ProjectileSpeed;
    }
}
