using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float secondsToDestroy = 5f;
void Awake()
    {
        Destroy(this.gameObject, secondsToDestroy);
    }



}
