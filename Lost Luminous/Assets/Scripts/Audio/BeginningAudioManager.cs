using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningAudioManager : MonoBehaviour
{
    public AudioSource TutorialSource;
    public AudioClip beginningBGM;
    public AudioClip wind;

    public void TutorialAudioManager()
    {
        TutorialSource.clip = beginningBGM;
        TutorialSource.Play();
        TutorialSource.clip = wind;
        TutorialSource.Play();
    }
}
