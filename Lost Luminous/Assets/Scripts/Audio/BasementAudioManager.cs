using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementAudioManager : MonoBehaviour
{
    public AudioSource Basementsource;
    public AudioClip Ambience;

    public void BasementAudionManager()
    {
        Basementsource.clip = Ambience;
        Basementsource.Play();
    }
}
