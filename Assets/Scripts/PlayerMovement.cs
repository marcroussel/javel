using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // ----- Attributes ----- //
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;

    Vector2 moveInput;

    [SerializeField]
    private float runSpeed = 10f;
    // ---------------------- //


    // Start is called before the first frame update
    void Start()
    {
        // Fetching player's components
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    // OnMove is called when a movement command is pressed
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Function to define the run velocity when the player runs or stays stopped
    void Run()
    {
        // Defining player's velocity
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;

        // Switching isRunning animation, depending on playerHasHorizontalSpeed
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    // Function to define when the sprite flips, depending on its direction
    void FlipSprite()
    {
        // Defining if the sprites goes horizontally
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        { 
            transform.localScale = new Vector3(Mathf.Sign(playerRigidbody2D.velocity.x), 1f, 1f);
        }
    }
}
