using UnityEngine;


//https://youtu.be/149teLQMmOQ //Video that helped me make a working look at mouse controller
public class GunControl : MonoBehaviour
{
    private Camera main;
    [Tooltip("Place the object where the bullet comes out from")]
    [SerializeField] private Transform child;
    [Tooltip("Place the reticle ui object here")]
    [SerializeField] private Transform targetIcon;
    [SerializeField] private float AimingControllerBounds;
    private bool isController = true;
    
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        AimingControllerBounds *= 90;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0,0);
        //Mouse Gun Control
        if (!isController)
        {
            targetIcon.transform.position = Input.mousePosition;
            direction = main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
 
        }
        //Controller Gun Control
        else if (isController) 
        {
            targetIcon.transform.position = new Vector3(AimingControllerBounds * Input.GetAxis("R Stick Vertical"), Input.GetAxis("R Stick Horizontal") * AimingControllerBounds,0) + main.WorldToScreenPoint(transform.position);
            direction = main.ScreenToWorldPoint(targetIcon.position);
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //What is this???
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        gameObject.transform.rotation = rotation;
      

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AimingControllerBounds);
        
    }

}
