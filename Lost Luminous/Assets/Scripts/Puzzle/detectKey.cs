using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class detectKey : MonoBehaviour
{
    private bool playerNear;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;
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
            if (key.enabled == true)
            {
                key.enabled = false;
                Destroy(gameObject);

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
