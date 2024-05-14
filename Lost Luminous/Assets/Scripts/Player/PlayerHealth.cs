using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
     
    [SerializeField]private float health;
    public static PlayerHealth healthInstance;
    
    private void Awake()
    {
        healthInstance = this;
    }
    
    /// <summary>
    /// Make it positive to reduce health and negative to increase health
    /// </summary>
    public void healthChange(float amount)
    {
        health += amount;
    }

    private void healthChanged()
    {
        if (health <=0)
        {
            health = 0;
            //Level Ends
        }
    }
}
