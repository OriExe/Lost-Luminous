using UnityEngine;

namespace LinePuzzle
{
    public class DetectCollision : MonoBehaviour
    {
        [SerializeField] private Transform lineCollider;
        private static Transform lineColliderS;
        [SerializeField] private LineRenderer lineRenderer;
        private static LineRenderer lineRendererS;
        
        private void Awake()
        {
            if (lineCollider != null) 
            {
                lineColliderS = lineCollider;
            }
            
            if (lineRenderer != null)
            {
                lineRendererS = lineRenderer;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.transform == lineColliderS) 
            {
                lineRendererS.positionCount = 0;
            }
        }
    }
}

