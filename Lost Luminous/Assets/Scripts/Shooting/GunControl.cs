using UnityEngine;


//https://youtu.be/149teLQMmOQ //Video that helped me make a working look at mouse controller
//https://discussions.unity.com/t/xbox-one-controller-mapping-solved/187077 Includes information on controller binds
public class GunControl : MonoBehaviour
{
    private Camera main;
    [Tooltip("Place the object where the bullet comes out from")]
    [SerializeField] private Transform child;
    [Tooltip("Place the reticle ui object here")]
    [SerializeField] private Transform targetIcon;
    [SerializeField] private float AimingControllerBounds;
    private bool isController = true;
    private Vector2 oldMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        AimingControllerBounds *= 90;
        Cursor.visible = false;
    }

    void checkKeyboardInput()
    {
        if (Vector2.Distance(Input.mousePosition, oldMousePosition) > 0.1f)
        {
            isController = false;
        }
    }

    void checkControllerInput() 
    {
        if (Input.GetAxis("R Stick Vertical") != 0 || Input.GetAxis("R Stick Horizontal") != 0)
        {
            isController = true;
            oldMousePosition = Input.mousePosition;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0,0);
        if (isController)
        {
            checkKeyboardInput();
        }
        else 
        {
            checkControllerInput();
        }

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
        Gizmos.DrawWireSphere(transform.position, AimingControllerBounds / 90);
        
    }

}
