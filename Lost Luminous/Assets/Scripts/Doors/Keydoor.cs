using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Keydoor : MonoBehaviour
{
    //Layers 
    private bool playerNear;
    [SerializeField]private LayerMask playerLayer;
    [SerializeField]private float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (playerNear) 
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (GameObject.FindGameObjectWithTag("Player"))
                {
                    keyItem key = GetComponentInChildren<keyItem>();
                    if (key.enabled == true)
                    {
                        key.enabled = false;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
