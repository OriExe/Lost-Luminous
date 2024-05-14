using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordAudioManager : MonoBehaviour
{
    public AudioSource passwordSource;
    public AudioClip passwordBGM;

    public void AudioManager()
    {
        passwordSource.clip = passwordBGM;
        passwordSource.Play();
    }

}
