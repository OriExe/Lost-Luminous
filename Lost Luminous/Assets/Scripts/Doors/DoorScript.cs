using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public AudioSource DoorOpen;

    [Header("Radius door can open fields")]
    [SerializeField] private float doorOpenRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearDoor;

    [SerializeField] private Transform newPosition;
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
            GameObject.FindGameObjectWithTag("Player").transform.position = newPosition.position;
            DoorOpen.Play();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, doorOpenRadius);

    }
}
