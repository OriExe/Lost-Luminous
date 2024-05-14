using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAudioManager : MonoBehaviour
{
    public AudioSource GroundSource;
    public AudioClip GroundBGM;

    public void FirstAudioManager()
    {
        GroundSource.clip = GroundBGM;
        GroundSource.Play();
    }
}
