using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDarkFrame : MonoBehaviour {

    private ParticleSystem pSystem;

    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (DarkMode.darkModeIs == true)
        {
            pSystem.Play();
        }
        else
        {
            pSystem.Stop();
        }
    }
}
