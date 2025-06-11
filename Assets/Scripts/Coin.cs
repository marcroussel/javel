using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // ---------- Attributes ---------- //
    Animator coinAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Fetching coin's animator
        coinAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter2D is called when the Box Collider is triggered
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enabling Shine animation
        coinAnimator.SetTrigger("CoinShine");

    }

    // To-do Self destruct function
}
