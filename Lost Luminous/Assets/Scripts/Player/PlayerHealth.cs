using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource Death;

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
            Death.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public float getHealth()
    {
        return health;
    }
}
