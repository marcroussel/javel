using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // ----- Attributes ----- //
    Rigidbody2D enemyRigidbody2D;
    BoxCollider2D enemyBodyCollider2D;

    [SerializeField]
    private float moveSpeed = 5f;
    // ---------------------- //

    // Start is called before the first frame update
    void Start()
    {
        // Fetching enemy's components
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        enemyBodyCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody2D.velocity = new Vector2(moveSpeed, enemyRigidbody2D.velocity.y);
        FlipEnemyFacing();

        // Switching enemy's speed when the enemy hits a spike
        if (enemyBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            SwitchSpeedSide();
        }
    }

    // OnTriggerExit2D is called when the enemy's Box Collider is out of collision
    void OnTriggerExit2D(Collider2D collision)
    {
        SwitchSpeedSide();
    }

    // Function to make the enemy switch its side
    void SwitchSpeedSide()
    {
        moveSpeed = -moveSpeed;
    }

    // Function to define when the enemy facing flips, depending on its direction
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector3(Mathf.Sign(enemyRigidbody2D.velocity.x), 1f, 1f);
    }
}
