using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    //public float playerVelocity;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        SetInitalReferences();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void SetInitalReferences()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
    }

    private void MyInput()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // When to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            //Debug.Log("Input.GetKeyDown(jumpKey) && readyToJump && grounded)");
            
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);

        }
        // Handle drag
        if (grounded)
        {
            playerRb.drag = groundDrag;
        }
        else
            playerRb.drag = 0;
    }

    public void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On ground
        if (grounded)
        {
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        // Limit velocity if needed
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            playerRb.velocity = new Vector3(limitedVelocity.x, playerRb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        // Reset y velocity
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

}
