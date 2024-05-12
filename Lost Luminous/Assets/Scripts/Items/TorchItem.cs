using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchItem : MonoBehaviour
{
    [SerializeField]private float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chargeTorch(int amount)
    {
        power += amount;
    }
}
