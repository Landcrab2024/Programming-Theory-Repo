using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //xRotation = orientation.rotation.x;
        //yRotation = orientation.rotation.y;
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseInputX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseInputY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityX;
        yRotation = yRotation + mouseInputX;
        xRotation = xRotation - mouseInputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
