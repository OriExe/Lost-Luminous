using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [Tooltip("Place the items you want to add here")]
    [SerializeField] private PickUpItem[] checkItems;
    [SerializeField] private Transform[] spawnLocations;
    private bool playerNear;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField]private float radius;
    private bool popUpShowingForItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius,playerLayer);
        if (playerNear && !PickUpItem.itemAlreadyShown)
        {
            PopUp.instance.onCall(gameObject.transform, PickUpItem.items.chest);
            PickUpItem.itemAlreadyShown = true;
            popUpShowingForItem = true;
        }
        else if (!playerNear && popUpShowingForItem) 
        {
            PopUp.instance.onHide();
            PickUpItem.itemAlreadyShown = false;
            popUpShowingForItem = false;
        }
        if (Input.GetButtonDown("Interact") && playerNear && popUpShowingForItem)
        {
            foreach (PickUpItem item in checkItems) 
            {
                Instantiate(item.gameObject, spawnLocations[Random.Range(0, spawnLocations.Length)].position,Quaternion.identity);
            }
            //Or could change chest texture 
            PopUp.instance.onHide();
            PickUpItem.itemAlreadyShown = false;
            popUpShowingForItem = false;
            Destroy(gameObject);
        }

        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
