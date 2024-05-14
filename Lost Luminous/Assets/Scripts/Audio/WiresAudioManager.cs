using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresAudioManager : MonoBehaviour
{
    public AudioSource wiresSource;
    public AudioClip wiresBGM;

    public void AudioManager()
    {
        wiresSource.clip = wiresBGM;
        wiresSource.Play();
    }
}
