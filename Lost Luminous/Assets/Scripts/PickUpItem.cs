using System.Collections;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public enum items {gun, torch, battery, sword, bullets, key, chest};
    [Tooltip("Please don't use chest as itemHeld")]
    [SerializeField]private items itemHeld;
    [Header("Player Detection Values")]
    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearItem;

    private bool popUpShowingForItem;

    public static bool itemAlreadyShown = false;
    private static GameObject player;

    /// <summary>
    /// Item scripts that are decided to a certain item
    /// </summary>
    private static BulletItem bulletScript;
    private static BatteryItem batteryScript;
    private static keyItem keyItem;
    private static ItemScrolling weaponSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
            bulletScript = player.gameObject.GetComponentInChildren<BulletItem>();
            batteryScript = player.gameObject.GetComponentInChildren<BatteryItem>();
            keyItem = player.gameObject.GetComponentInChildren<keyItem>();
            weaponSwitcher = player.gameObject.GetComponent<ItemScrolling>();
        }

        if (itemHeld == items.chest) 
        {
            Debug.LogError("Chest cannot equal itemHeld, please change this to something else!");
        }
        //Could put all the items in the player object or in an empty object connected to the player
    }

    // Update is called once per frame
    void Update()
    {
        playerNearItem = Physics2D.OverlapCircle(transform.position,pickUpRadius,playerMask); //Detects Player
        if (playerNearItem && !itemAlreadyShown) 
        {
            PopUp.instance.onCall(gameObject.transform, itemHeld);
            itemAlreadyShown = true;
            popUpShowingForItem = true;
        }
        else if (!playerNearItem && popUpShowingForItem)
        {
            PopUp.instance.onHide();
            itemAlreadyShown = false;
            popUpShowingForItem = false;
        }
       

        if (popUpShowingForItem)
        {
            if (Input.GetButtonDown("Interact"))
            {
                
               //Chest item not needed, it gets interacted elsewhere
                switch (itemHeld)
                {
                    case items.gun:
                        weaponSwitcher.addItem(itemHeld);
                        break;
                    case items.torch:
                        weaponSwitcher.addItem(itemHeld);
                        break;
                    case items.battery:
                        batteryScript.setAmount(2);
                        break;
                    case items.sword:
                        weaponSwitcher.addItem(itemHeld);
                        break;
                    case items.bullets:
                        bulletScript.addBullets(20);
                        break;
                    case items.key:
                        keyItem.setKey(1);
                        break;
                
                }
                
                StartCoroutine(timeDelay());
            }
        }
    }
    
    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(0.1f);
        PopUp.instance.onHide();
        itemAlreadyShown = false;
        popUpShowingForItem = false;
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);

    }
}


