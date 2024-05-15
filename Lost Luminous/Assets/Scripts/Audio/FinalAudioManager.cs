using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAudioManager : MonoBehaviour
{
    public AudioSource FinalSource;
    public AudioClip FinalClip;

    public void BossiestAudioManager()
    {
        FinalSource.clip = FinalClip;
        FinalSource.Play();
    }
}
