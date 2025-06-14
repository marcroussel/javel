using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    // ---------- Attributes ---------- //
    // --- SerializeField Vars --- //
    // Values are defined in the editor
    [SerializeField]
    private AudioClip jumpSFX;

    [SerializeField]
    private AudioClip loseLifeSFX;

    [SerializeField]
    private AudioClip fallSFX;

    [SerializeField]
    private AudioClip punchSFX;

    [SerializeField]
    private CinemachineStateDrivenCamera stateDrivenCamera; 

    [SerializeField]
    private float runSpeed = 10f;

    [SerializeField]
    private float jumpSpeed = 25f;

    [SerializeField]
    private float climpSpeed = 8f;

    [SerializeField]
    private float deathKick = 8f;
    // --------------------------- //

    Animator playerAnimator;
    BoxCollider2D playerFeetCollider;
    CapsuleCollider2D playerBodyCollider;
    Rigidbody2D playerRigidbody2D;

    Vector2 moveInput;
    
    private bool isAlive = true;
    private float gravityScaleAtStart;
    // -------------------------------- //


    // Start is called before the first frame update
    void Start()
    {
        // Fetching player's components
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        // Getting start gravity scale
        gravityScaleAtStart = playerRigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            ClimbLadder(); 
            Run();
            FlipSprite();
            Die();
        }
    }

    // OnMove is called when a movement command is pressed
    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    // OnJump is called when the jump command is pressed
    void OnJump(InputValue value)
    {
        if (isAlive && isTouchingTheGround() && value.isPressed)
        {
            // Playing jump sound
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
            playerRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }
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

    // Function to define the climbing velocity when the player climbs a ladder
    void ClimbLadder()
    {
        if (isTouchingALadder())
        {
            // Defining player's velocity
            Vector2 playerVelocity = new Vector2(playerRigidbody2D.velocity.x, moveInput.y * climpSpeed);
            playerRigidbody2D.velocity = playerVelocity;

            // Removing gravity when climbing
            playerRigidbody2D.gravityScale = 0f;

            // Switching isClimping animation, depending on isTouchingALadder
            playerAnimator.SetBool("isClimbing", !isTouchingTheGround());
        }
        else
        {
            // Restablishing gravity when not climbing
            playerRigidbody2D.gravityScale = gravityScaleAtStart;

            // Switching isClimping animation, depending on isTouchingALadder
            playerAnimator.SetBool("isClimbing", false);
        }
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

    // Function to make the Player dying 
    void Die()
    {
        // Verifying if the Player has touched an Enemy
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Water")) || playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;

            // Restablishing gravity 
            playerRigidbody2D.gravityScale = gravityScaleAtStart;

            // Pending the Background Music to be stopped
            FindObjectOfType<BackgroundMusic>().StopMusic();

            // Enabling Dying animation
            playerAnimator.SetTrigger("Dying");

            // When an enemy or spikes have touched the player
            if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) || playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
            {
                // Playing punch sound
                AudioSource.PlayClipAtPoint(punchSFX, Camera.main.transform.position);

                // Giving a vertical kick to the player
                playerRigidbody2D.velocity = new Vector2(0f, deathKick);
            }
            else
            {
                // Considering that this part is only executed when the player falls in the water
                AudioSource.PlayClipAtPoint(fallSFX, Camera.main.transform.position);
            }

            // Disabling Player's colliders
            playerBodyCollider.enabled = false;
            playerFeetCollider.enabled = false;

            // Blocking the state-driven camera
            stateDrivenCamera.enabled = false;

            // Playing the lose life
            Invoke("playLoseLifeSound", 0.5f);

            // Processing to death in Game Session after 3 seconds
            Invoke("DieInGameSession", 2.5f);
        }
    }

    // Function to make the Game Session process to player's death
    void DieInGameSession()
    {
        // Calling the player's death function in the current GameSession
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    // Function to play the losing life sound
    void playLoseLifeSound()
    {
        AudioSource.PlayClipAtPoint(loseLifeSFX, Camera.main.transform.position);
    }

    // Function to determine if the player touches, with its feet,
    // the layer "Platforms", so the ground
    bool isTouchingTheGround()
    {
        return playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Platforms"));
    }

    // Function to determine if the player touches, with its body,
    // the layer "Climbing", so a ladder
    bool isTouchingALadder()
    {
        return playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
    }
}
