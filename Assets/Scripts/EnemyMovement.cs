using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // ----- Attributes ----- //
    Rigidbody2D enemyRigidbody2D;

    [SerializeField]
    private float moveSpeed = 5f;
    // ---------------------- //

    // Start is called before the first frame update
    void Start()
    {
        // Fetching enemy's components
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody2D.velocity = new Vector2(moveSpeed, enemyRigidbody2D.velocity.y);
        FlipEnemyFacing();
    }

    // OnTriggerExit2D is called when the enemy's Box Collider is out of collision
    void OnTriggerExit2D(Collider2D collision)
    {
        // Reversing Enemy's movement 
        moveSpeed = -moveSpeed;
    }

    // Function to defin when the sprite flips, depending on its direction
    void FlipEnemyFacing()
    {
        Debug.Log(transform.localScale);
        // Debug.Log(enemyRigidbody2D.velocity.x);
        transform.localScale = new Vector3(Mathf.Sign(enemyRigidbody2D.velocity.x), 1f, 1f);
    }
}
