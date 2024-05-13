using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [Tooltip("Place the items you want to add here")]
    [SerializeField] private PickUpItem[] checkItems;
    [SerializeField] private Transform[] spawnLocations;
    private bool playerNear;
    private LayerMask playerLayer;
    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius,playerLayer);
        if (Input.GetButtonDown("Interact") && playerNear)
        {
            foreach (PickUpItem item in checkItems) 
            {
                Instantiate(item, spawnLocations[Random.Range(0, spawnLocations.Length)]);
            }
            //Or could change chest texture 
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
