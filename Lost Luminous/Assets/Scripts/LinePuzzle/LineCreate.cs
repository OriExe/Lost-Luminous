using System.Collections.Generic;
using UnityEngine;

namespace LinePuzzle
{ 

//https://youtu.be/SmAwege_im8 Video I used to help me understand the line renderer 
public class LineCreate : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField]private Camera cam;
    private const float RESOLUTION = 0.1f;
    [SerializeField]private EdgeCollider2D Collider;
    private List<Vector2> collisionPoints = new List<Vector2>();
    [SerializeField] private Transform start;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("LineCam").GetComponent<Camera>();
        Collider.transform.position += transform.position; //Only useful if I move the line object
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && distanceCheck(ref position)) //Draws line if player is in sutiable area
        {
            collisionPoints.Add(position);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
            Collider.points = collisionPoints.ToArray();
        }
        
        if (Input.GetMouseButtonUp(0)) //Removes line when player lets go of the mouse button
        {
                removeList();
        }
        
        
    }

    bool distanceCheck(ref Vector2 position)
    {
        if (lineRenderer.positionCount == 0 && Vector2.Distance(start.position,cam.ScreenToWorldPoint(Input.mousePosition)) < 0.5f) return true; //Detects the distance the player starts to draw the line from the start position when in the first stage

        if (lineRenderer.positionCount == 0) return false;
        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount-1),position) > RESOLUTION;

    }

    /// <summary>
    /// Removes the line and it's collisions
    /// </summary>
    public void removeList()
    {
            lineRenderer.positionCount = 0;
            collisionPoints = new List<Vector2>();
    }

}
}
