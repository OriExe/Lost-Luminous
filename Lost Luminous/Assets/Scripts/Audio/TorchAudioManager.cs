using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAudioManager : MonoBehaviour
{
    public AudioSource TorchSource;
    public AudioClip ToggleFlashlight;

    public void TorchaudioManager()
    {
        TorchSource.clip = ToggleFlashlight;
        TorchSource.Play();
    }


}
