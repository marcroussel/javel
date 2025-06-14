using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Function called before Start, to handle Game Sessions creations
    void Awake()
    {
        int numberOfBackgroundMusics = FindObjectsOfType<BackgroundMusic>().Length;
        if (numberOfBackgroundMusics > 1)
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
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to stop the music
    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
