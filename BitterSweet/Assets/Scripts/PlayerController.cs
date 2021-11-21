using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 0.5f;
    [SerializeField] private float gravity = 2f;

    CharacterController characterController;
    private Vector3 moveDirection;

    public Animator animator;
    int isWalkingHash;
    int isJumpingHash;

    public AudioSource walkingSFX;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        isWalkingHash = Animator.StringToHash("isWalk");
        isJumpingHash = Animator.StringToHash("isJump");
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);
        Vector3 flatMovement = moveSpeed * Time.deltaTime * transformDirection;

        moveDirection = new Vector3(flatMovement.x, moveDirection.y, flatMovement.z);

        bool isWalking = animator.GetBool("isWalk");
        bool playerWalking = Input.GetKey("w") | Input.GetKey("a") | Input.GetKey("s") | Input.GetKey("d") |  Input.GetKey("up") | Input.GetKey("left") | Input.GetKey("right") | Input.GetKey("down");
        bool isJumping = animator.GetBool("isJump");
        bool playerJumping = Input.GetKey("space");

        //if booleon playerJumped is true...
        if (playerJumped)
        {
            //set move direction of y axis to float jump speed
            moveDirection.y = jumpSpeed;
        }
        //otherwise if the player character is touching the ground...
        else if (characterController.isGrounded)
        {
            //set move direction of y axis to 0
            moveDirection.y = 0f;
        }
        else
        {
            //y axis move direction is decreasing by time multiplied by gravity
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //move player character
        characterController.Move(moveDirection);
        
        //if playing is moving the character...
        if (!isWalking && playerWalking)
        {
            //animator bool isWalk is set to true
            animator.SetBool(isWalkingHash, true);
            walkingSFX.Play();
        }
        //if player is not pressing moving the character...
        if (isWalking && !playerWalking)
        {
            //animator bool isWalk is set to false
            animator.SetBool(isWalkingHash, false);
            walkingSFX.Stop();
        }
        //if playing is pressing space...
        if (!isJumping && playerJumping)
        {
            //animator bool isJump is set to true
            animator.SetBool(isJumpingHash, true);
        }
        //if player is not pressing space...
        if (isJumping && !playerJumping)
        {
            //animator bool isJump is set to false
            animator.SetBool(isJumpingHash, false);
        }
        //if Jumping and Walking is set to false
        if (!isJumping && !isWalking)
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            
            animator.SetBool("isIdle", false);
        }
    }

    private bool playerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);
}
