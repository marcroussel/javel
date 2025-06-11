using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    // ---------- Attributes ---------- //
    [SerializeField]
    private int playerLives = 3; // At the beginning, the player has 3 lives
    // -------------------------------- //


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

    // Function to remove a life and reload the scene when the player loses
    public void TakeLife()
    {
        // Removing a player's life
        playerLives--;

        // Fetching current Scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Loading current Scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Function to reset the Game sessions and reload the initial scene
    public void ResetGameSessions()
    {
        // Destroying the current game object
        Destroy(gameObject);

        // Loading initial scene
        SceneManager.LoadScene(0);
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
