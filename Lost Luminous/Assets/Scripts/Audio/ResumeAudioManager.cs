using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAudioManager : MonoBehaviour
{
    public AudioSource ResumeSource;
    public AudioClip Resumed;
    public void resume()
    {
        ResumeSource.clip = Resumed;
        ResumeSource.Play();
      
    }
}
