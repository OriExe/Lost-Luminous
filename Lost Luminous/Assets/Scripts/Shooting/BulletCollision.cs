using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHit>().getHit(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
