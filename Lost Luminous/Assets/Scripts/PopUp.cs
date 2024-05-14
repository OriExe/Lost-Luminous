using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Camera cam;
    public static PopUp instance;

    private void Awake()
    {
        instance = this; 
    }
    
    public void onCall(Transform itemObj,PickUpItem.items item)
    {
        gameObject.SetActive(true);
        transform.position = cam.WorldToScreenPoint(itemObj.position + offset);
        itemText.text = item.ToString();
    }

    public void onHide()
    {
        gameObject.SetActive(false);
    }

}
