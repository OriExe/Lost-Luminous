using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchItem : MonoBehaviour
{
    [SerializeField]private float power;
    private bool torchEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && power > 0)
        { 
            //Enable torch light
            torchEnabled = true;
        }

        if (torchEnabled)
        {
            power -= Time.deltaTime;
        }
        if (power <= 0 && torchEnabled)
        {
            power = 0;
            torchEnabled = false;
            //Disable Torch
        }
    }

    private void OnDisable()
    {
        torchEnabled = false;
        //DisableTorch

    }
    public void chargeTorch(int amount)
    {
        power += amount;
    }
}
