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
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool playerIsGrounded;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!GameStatus.instance.GamePause){
            playerIsGrounded = characterController.isGrounded;
        
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            var inputDirection = new Vector3(horizontal, 0, vertical).normalized;
            
            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);

            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

            bool isWalking = hasHorizontalInput || hasVerticalInput;
            
            animator.SetBool("IsMoving", isWalking);

            
            if (inputDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                characterController.Move(moveDir.normalized * (moveSpeed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.Space) && playerIsGrounded)
            {
                moveDirection.y = jumpForce;
                animator.SetBool("IsJumping", true);
            }
            else if (characterController.isGrounded)
            {
                moveDirection.y = 0f;
                animator.SetBool("IsJumping", false);
            }
                
            
            else
                moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection);
     
        }
           
    }
    
}
