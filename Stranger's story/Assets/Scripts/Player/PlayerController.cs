using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10;
    [SerializeField] private float gravity = 0.7f;
    [SerializeField] private float jumpForce = 2f;

    [SerializeField] private Transform camera;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool groundedPlayer;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        groundedPlayer = characterController.isGrounded;

        if (groundedPlayer && moveDirection.y < 0)
        {
            moveDirection.y = 0f;
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir * (moveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            moveDirection.y = Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }

        moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

    }
    
}
