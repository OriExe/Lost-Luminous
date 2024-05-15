using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchItem : MonoBehaviour
{
    public AudioSource toggleOnandOff;
    [SerializeField]private float power;
    private bool torchEnabled = false;
    [SerializeField] private GameObject torchLight;
    //
    [SerializeField] private Color torchColour;
    private Color normalColour;
    [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    private void Start()
    {
        normalColour = sprite.color;
    }
    // Update is called once per frame
    void Update()
    {
        if (PuzzleStart.puzzleActive) return;
        if ((Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") < -0.5f) && power > 0)
        {
            torchEnabled = !torchEnabled;
            torchLight.SetActive(torchEnabled);
            toggleOnandOff.Play();

            if (torchEnabled) 
            {
                sprite.color = torchColour;
            }
            else
            {
                sprite.color = normalColour;
            }
        }

        if (torchEnabled)
        {
            power -= Time.deltaTime;
        }
        if (power <= 0 && torchEnabled)
        {
            torchLight.SetActive(false);
            power = 0;
            torchEnabled = false;
            sprite.color = normalColour;
            //Disable Torch
        }
    }

    private void OnDisable()
    {
        torchLight.SetActive(false);
        torchEnabled = false;
        sprite.color = normalColour;
        //Disable Torch
    }
    public void chargeTorch(int amount)
    {
        power += amount;
    }
}
