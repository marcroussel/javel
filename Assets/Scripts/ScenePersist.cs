using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    // Function called on the creation of the Scene, to handle ScenePersist creations
    void Awake()
    {
        int numberOfScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numberOfScenePersists > 1)
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

    // Function to destroy the data saved on the scene
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
