using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAudioManager : MonoBehaviour
{
    public AudioSource WindSource;
    public AudioClip wind;

    public WindAudioManager()
    {
        WindSource.clip = wind;
        WindSource.Play();
    }

}
