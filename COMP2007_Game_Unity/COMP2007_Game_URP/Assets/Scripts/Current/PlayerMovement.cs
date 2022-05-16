using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;
    
    [SerializeField] Transform orientation;

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;
    [SerializeField] float airMultiplier = 0.4f;
    
    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Drag")]
    public float groundDrag = 6f;
    public float airDrag = 2f;

    //Store the movement values
    float horizontalMovement;
    float verticalMovement;

    //Variables for checking if the player is grounded
    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.04f;
    
    //Audio (couldnt get this to work properly)
    [Header("Audio")]
    [SerializeField] AudioSource footsteps;
    bool playAudio;
    
    //Store the player direction
    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    //For checking if the player is walking up a hill
    RaycastHit slopeHit;

    //Checking if the player is on a slope by shooting a raycast at the floor and checking if the floors normal is up, if not then it must be sloped
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    //Getting rigidbody and freezing rotation
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //Uses sphere to check if the object beneth the player has the ground tag
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, groundMask);

        MyInput();
        ControlDrag();

        //if the player is trying to jump and is ground then jump
        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        /*if(isGrounded && footsteps.isPlaying == false && rb.velocity.x > 0 || rb.velocity.y > 0)
        {
            footsteps.Play();
        }
        else if(footsteps.isPlaying == true && rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            footsteps.Stop();
        }*/
       
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void MyInput()
    {
        //Setting movement value based on input
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        //Move in the direction thats forward to the player
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void Jump()
    {
        // Adds a sudden force that happens once every time its called
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControlDrag()
    {
        //Drag depending on if the player is on ground or in air, so they dont slide/fly about
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //This code stops the player sliding down slopes by checking if the are not trying to move, are on a slope, but still have movement
        if(rb.velocity.magnitude < 1f && hideFlags == 0 && verticalMovement == 0 && isGrounded && OnSlope())
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
        //Adding different force depending on if the player is on a slope, as slops require more power to move on
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            
        }
        else if(isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);

            
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
}
