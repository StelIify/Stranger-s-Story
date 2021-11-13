using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10;
    [SerializeField] private float gravity = 2;
    [SerializeField] private float jumpForce = 2f;

    private CharacterController characterController;
    private Vector3 moveDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        var transformDirection = transform.TransformDirection(inputDirection);

        var flatMovement = moveSpeed * Time.deltaTime * transformDirection;

        moveDirection = new Vector3(flatMovement.x, moveDirection.y, flatMovement.z);

        if (PlayerJumped)
            moveDirection.y = jumpForce;
        else if (characterController.isGrounded)
            moveDirection.y = 0f;
        else
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection);
    }

    private bool PlayerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);
   
}
