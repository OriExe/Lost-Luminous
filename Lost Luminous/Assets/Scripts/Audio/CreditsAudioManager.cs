using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAudioManager : MonoBehaviour
{
    public AudioSource creditSource;
    public AudioClip CreditBGM;

    public void AudioManager()
    {
        creditSource.clip = CreditBGM;
        creditSource.Play();
    }

    
}
