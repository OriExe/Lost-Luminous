using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip BGmusic;
    public AudioClip Buttonclick;

    public void Resume()
    {
        source.clip = Buttonclick;
        source.Play();
    }
}
