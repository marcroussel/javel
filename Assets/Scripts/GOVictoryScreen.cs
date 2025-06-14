using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOVictoryScreen : MonoBehaviour
{
    void Start()
    {
        // Resetting Game Session
        FindObjectOfType<GameSession>().ResetGameSessions("Victory");

        // Stopping the music
        FindObjectOfType<BackgroundMusic>().StopMusic();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
