using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
   [SerializeField] private float health;
    public bool isDead = false;
   public void getHit(float amount)
    {
        health -= amount;

        if (health <0 ) 
        {
            gameOver();
        }
    }

    public float getHealth() { return health; }
    void gameOver ()
    {
        isDead = true;
        Destroy(gameObject);
        //Play Death Animation
    }
}
