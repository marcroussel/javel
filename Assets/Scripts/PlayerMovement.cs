using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Attributes
    Vector2 moveInput;
    Rigidbody2D playerRigidbody2D;

    [SerializeField]
    private float runSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Fetching player's Rigidbody
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    // OnMove is called when a movement command is pressed
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Run function
    void Run()
    {
        // Defining player's velocity
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;
    }
}
