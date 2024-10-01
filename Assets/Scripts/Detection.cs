using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private RaycastHit raycastHit;
    private float checkRate = 0.5f;
    private float nextCheck;
    public LayerMask detectionLayerMask;
    public float raycastRange = 20;
    public TMP_Text textMeshProAimText;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        SetInitalReferences();
    }

    // Update is called once per frame
    void Update()
    {
        DetectItems();
        //DetectEnemies();
    }

    void SetInitalReferences()
    {
        myTransform = transform;
    }

    void DetectItems()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            if (Physics.Raycast(myTransform.position, myTransform.forward, out raycastHit, raycastRange, detectionLayerMask))
            {
                // What item am I looking at that have a colider
                //Debug.DrawRay(transform.TransformPoint(0, 0, 1), transform.forward, Color.green, 3);
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    textMeshProAimText.text = "Enemy: " + raycastHit.transform.name;
                }
                else
                    textMeshProAimText.text = "Not an enemy: " + raycastHit.transform.name;

            }
            else
            {
                textMeshProAimText.text = null;
            }
        }

    }

    //void DetectEnemies()
    //{

    //}
}
