using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    // Function called before Start, to handle Game Sessions creations
    void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length; // Unity 6 syntax: FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // We're not destroying the GameObject, to save the data
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to handle Player's death on Game Sessions
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSessions();
        }
    }
}
