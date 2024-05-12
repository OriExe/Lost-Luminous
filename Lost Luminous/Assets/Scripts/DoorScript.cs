using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer doorSprite;
    [SerializeField] private BoxCollider2D colider;
    private bool doorOpen;

    [Header("Door Sprites")]
    [SerializeField]private Sprite doorOpened;
    [SerializeField]private Sprite doorClosed;
    [Header("Radius door can open fields")]
    [SerializeField] private float doorOpenRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNearDoor = Physics2D.OverlapCircle(transform.position, doorOpenRadius, playerMask);
        if (Input.GetButtonDown("Interact") && playerNearDoor)
        {
            if (doorOpen) 
            {
                doorSprite.sprite = doorClosed;
                colider.enabled = true;
                doorOpen = false;
            }
            else if (doorClosed) 
            {
                doorOpen = true;
                doorSprite.sprite = doorOpened;
                colider.enabled = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, doorOpenRadius);

    }
}
