using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("Hit");
            collision.gameObject.GetComponent<EnemyHit>().getHit(damage);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
