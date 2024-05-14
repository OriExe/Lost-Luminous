using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpLadder : MonoBehaviour
{
    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearItem;
    [SerializeField] private GameObject popup;
    public static bool playerHasLadder = false; //Use this to detect if the player is near the enterance with the ladder
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNearItem = Physics2D.OverlapCircle(transform.position, pickUpRadius,playerMask);

        if (playerNearItem ) 
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }

        if (playerNearItem && Input.GetButtonDown("Interact"))
        {
            popup.SetActive(false);
            playerHasLadder = true;
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);

    }
}
