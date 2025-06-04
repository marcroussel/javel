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
    }
}
