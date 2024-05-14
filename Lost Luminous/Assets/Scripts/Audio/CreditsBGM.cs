using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBGM : MonoBehaviour
{
    public AudioSource source;
    public AudioClip creditsBGmusic;
   

    public void Credits()
    {
        source.clip = creditsBGmusic;
        source.Play();
    }
}
