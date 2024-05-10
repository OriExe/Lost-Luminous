using System.Collections.Generic;
using UnityEngine;

//https://youtu.be/SmAwege_im8
public class LineCreate : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    private Camera cam;
    private const float RESOLUTION = 0.1f;
    [SerializeField]private EdgeCollider2D Collider;
    private List<Vector2> collisionPoints = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //Collider.transform.position -= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && distanceCheck(ref position)) 
        {
            collisionPoints.Add(position);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
            Collider.points = collisionPoints.ToArray();
        }
        
        
    }

    bool distanceCheck(ref Vector2 position)
    {
        if (lineRenderer.positionCount == 0) return true;

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount-1),position) > RESOLUTION;


    }
}
