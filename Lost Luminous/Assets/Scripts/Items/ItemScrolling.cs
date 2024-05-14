using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScrolling : MonoBehaviour
{
    public static PickUpItem.items[] unlockedItems;
    private int index;

    [Header("Items Player Can hold and use")]
    [SerializeField] private ShootingScript gunItem;
    [SerializeField] private Sword swordItem;
    [SerializeField] private TorchItem torchItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetButtonDown("RB"))
        {
            print("Going Up");
            index++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetButtonDown("LB")) 
        {
            print("Going Down");
            index--;
        }

        if (index < 0)
        {
            index = unlockedItems.Length-1;
        }
        if (index >= unlockedItems.Length)
        {
            index = 0;
        }

        switch (unlockedItems[index])
        {
            case PickUpItem.items.gun:
                gunItem.enabled = true;
                swordItem.enabled = false;
                torchItem.enabled = false; 
                break;
            case PickUpItem.items.torch:
                gunItem.enabled = false;
                swordItem.enabled = false;
                torchItem.enabled = true;
                break;
            case PickUpItem.items.sword:
                gunItem.enabled = false;
                swordItem.enabled = true;
                torchItem.enabled = false;
                break;
        }
    }
}
