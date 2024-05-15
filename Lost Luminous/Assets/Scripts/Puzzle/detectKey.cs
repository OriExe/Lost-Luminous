using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class detectKey : MonoBehaviour
{
    private bool playerNear;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;
    [SerializeField] private GameObject keyDoor;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (playerNear && Input.GetButtonDown("Interact"))
        {
            keyItem key = player.GetComponentInChildren<keyItem>();
            if (key.getKey() > 0)
            {
                key.setKey(-1);
                Destroy(keyDoor);

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
