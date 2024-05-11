using UnityEngine;


//https://youtu.be/149teLQMmOQ //Video that helped me make a working look at mouse controller
public class GunControl : MonoBehaviour
{
    private Camera main;
    [Tooltip("Place the object where the bullet comes out from")]
    [SerializeField] private Transform child;
    [Tooltip("Place the reticle ui object here")]
    [SerializeField] private Transform targetIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        targetIcon.transform.position = Input.mousePosition;
        Vector2 direction = main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg; //What is this???
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        gameObject.transform.rotation = rotation;
  

    }

    
}
