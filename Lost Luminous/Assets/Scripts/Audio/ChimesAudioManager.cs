using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimesAudioManager : MonoBehaviour
{
    public AudioSource ChimesSource;
    public AudioClip bells;

    public void BellsAudioManager()
    {
        ChimesSource.clip = bells;
        ChimesSource.Play();
    }
}
