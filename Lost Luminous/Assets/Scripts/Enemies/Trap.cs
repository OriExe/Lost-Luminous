
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.healthInstance.healthChange(-PlayerHealth.healthInstance.getHealth());
            //Play trap Animation
        }
    }
}
