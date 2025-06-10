using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // ---------- Attributes ---------- //
    [SerializeField]
    private int sceneLoadDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter2D is called when the Box Collider is triggered
    void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("LoadNextScene", sceneLoadDelay);
    }

    // Function to load the next Scene
    void LoadNextScene()
    {
        // Fetching current Scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Loading next Scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
