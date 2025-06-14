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

            // Enabling Shine animation, for coins
            if (coinAnimator != null)
            {
                coinAnimator.SetTrigger("CoinCaught");

                // Destructing the coin after 250 ms
                Invoke("SelfDestruct", 0.25f);
            }
            else
            {
                SelfDestruct();
            }
        }
    }

    // Function to self destruct and to add a value to the Game Session
    void SelfDestruct()
    {
        // If the object to be picked up is a coin
        if (gameObject.tag == "Coin")
        {
            FindObjectOfType<GameSession>().AddToCoins();
        }
        // If the object to be picked up is a live
        if (gameObject.tag == "Mushroom")
        {
            FindObjectOfType<GameSession>().AddToLife();
        }
        
        Destroy(gameObject);
    }
}
