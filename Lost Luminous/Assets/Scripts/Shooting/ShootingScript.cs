using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform Gun;
    [SerializeField] private float bulletforce;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D Bullet = Instantiate(bullet,Gun.position,Gun.parent.rotation).GetComponent<Rigidbody2D>();
            Bullet.velocity = transform.up * bulletforce;
            Destroy(Bullet.gameObject,4f);
        }
    }
}
