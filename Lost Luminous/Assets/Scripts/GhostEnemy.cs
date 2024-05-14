using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    /// <summary>
    /// Tracking Radius
    /// </summary>
    private bool playerNear;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;
    private Transform player;
    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (playerNear)
        {
            print("Player");
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
