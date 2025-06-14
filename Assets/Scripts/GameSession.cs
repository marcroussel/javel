using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    // ---------- Attributes ---------- //
    [SerializeField]
    TextMeshProUGUI livesText;

    [SerializeField]
    TextMeshProUGUI coinsText;

    [SerializeField]
    private int playerCoins = 0; // At the beginning, the player has 0 coins

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
        // Displaying lives
        DisplayLives();

        // Displaying coins
        DisplayCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to add a life to the player, and displaying it
    public void AddToLife()
    {
        playerLives++;

        // Displaying lives
        DisplayLives();
    }

    // Function to add a coin to the player, and displaying it
    public void AddToCoins()
    {
        playerCoins++;

        // Displaying coins
        DisplayCoins();
    }

    // Function to remove a life and reload the scene when the player loses
    public void TakeLife()
    {
        // Removing a player's life
        playerLives--;

        // Displaying lives
        DisplayLives();

        // Fetching current Scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Loading current Scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Function to display the player's lives
    public void DisplayLives()
    {
        livesText.text = "Lives: " + playerLives.ToString();
    }

    // Function to display the player's coins
    public void DisplayCoins()
    {
        coinsText.text = "Coins: " + playerCoins.ToString();
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
