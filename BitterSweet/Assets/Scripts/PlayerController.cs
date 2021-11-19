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

    void Awake() => characterController = GetComponent<CharacterController>();
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);
        Vector3 flatMovement = moveSpeed * Time.deltaTime * transformDirection;

        moveDirection = new Vector3(flatMovement.x, moveDirection.y, flatMovement.z);

        if (PlayerJumped)
        {
            moveDirection.y = jumpSpeed;
        }
        else if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        characterController.Move(moveDirection);
    }

    private bool PlayerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);
}
