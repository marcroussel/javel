using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // ---------- Attributes ---------- //
    [SerializeField]
    AudioClip pickupSFX;

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
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Player")
        {
            // Playing the sound
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);

            // Enabling Shine animation
            coinAnimator.SetTrigger("CoinCaught");

            // Destructing the coin after 250 ms
            Invoke("SelfDestruct", 0.25f);
        }
    }

    // Function to self destruct
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
