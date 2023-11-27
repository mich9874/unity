using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckGrounded();

        Vector3 move = GetPlayerInput();
        MovePlayer(move);

        RotatePlayer(move);

        HandleJump();

        ApplyGravity();

        MovePlayerWithGravity();
    }

    void CheckGrounded()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    Vector3 GetPlayerInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void MovePlayer(Vector3 move)
    {
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void RotatePlayer(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    void ApplyGravity()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    void MovePlayerWithGravity()
    {
        controller.Move(playerVelocity * Time.deltaTime);
    }
}