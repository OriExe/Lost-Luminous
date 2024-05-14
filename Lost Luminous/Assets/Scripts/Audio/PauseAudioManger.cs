using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudioManger : MonoBehaviour
{
    public AudioSource pauseSource;
    public AudioClip flipPages;

    public void PauseAudioManager()
    {
        pauseSource.clip = flipPages;
        pauseSource.Play();
    }
}
