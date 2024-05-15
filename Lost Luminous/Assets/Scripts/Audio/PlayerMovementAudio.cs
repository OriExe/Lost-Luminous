using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAudio : MonoBehaviour
{
    public AudioSource PlayerMove;
    public AudioClip steps;

    public void PlayerMovement ()
    {
        PlayerMove.clip = steps;
        PlayerMove.Play ();
    }
}
