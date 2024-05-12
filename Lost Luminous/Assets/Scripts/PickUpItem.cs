using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public enum items {gun, torch, battery, sword, bullets};
    [SerializeField]private items itemHeld;
    [Header("Player Detection Values")]
    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearItem;
    [Header("Collection Popup")]
    [SerializeField] private Transform popup;

    
    
    private static bool itemAlreadyShown = false;
    private static GameObject player;

    /// <summary>
    /// Item scripts that are decided to a certain item
    /// </summary>
    private ShootingScript gunScript;
    private Sword swordScript;
    private BulletItem bulletScript;
    private TorchItem torchScript;
    private BatteryItem batteryScript;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //Could put all the items in the player object or in an empty object connected to the player
    }

    // Update is called once per frame
    void Update()
    {
        playerNearItem = Physics2D.OverlapCircle(transform.position,pickUpRadius,playerMask);
        if (playerNearItem && !itemAlreadyShown) 
        {
            //Show popup
            itemAlreadyShown = true;
        }
        else
        {
            //Hide popup
            itemAlreadyShown = false;
        }

        if (popup.gameObject.activeInHierarchy)
        {
            if (Input.GetButtonDown("Interact"))
            {
                switch (itemHeld)
                {
                    case items.gun:
                        gunScript.enabled=true;
                        break;
                    case items.torch:
                        torchScript.enabled = true;
                        break;
                    case items.battery:
                        batteryScript.enabled = true;
                        break;
                    case items.sword:
                        swordScript.enabled = true;
                        break;
                    case items.bullets:
                        bulletScript.enabled = true;
                        break;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);

    }
}


