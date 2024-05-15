using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform Gun;
    [SerializeField] private float bulletforce;
    [Tooltip("Determines how slow each bullet will come, If the value is one 1 bullet will come out a second")]
    [SerializeField] private float shootingSpeed;
    private float timeLeft = 0;
    [SerializeField]private int ammo;
    private bool buttonHeld;
    void Update()
    {
        //Controls shooting speed by lowering the time, If timeleft is 0 the player can shoot
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        
        if (ammo > 0)
        {
            if ((Input.GetAxisRaw("Fire1") < -0.5f || Input.GetButtonDown("Fire1")) && timeLeft <= 0 && !buttonHeld)
            {
                Rigidbody2D Bullet = Instantiate(bullet, Gun.position, Gun.parent.rotation).GetComponent<Rigidbody2D>();
                Bullet.velocity = Gun.up * bulletforce;
                Destroy(Bullet.gameObject, 4f);
                timeLeft = shootingSpeed;
                buttonHeld = true;
                ammo--;
            }
        }
        //Shoots gun for xbox and keyboard and mouse controls
        
        
        //Makes gun singleFire rather than automatic
        if (Input.GetAxisRaw("Fire1") >= -0.1f && buttonHeld == true && ammo > 0)
        {
            buttonHeld = false;
        }
    }
    public void addBullets(int bullets)
    {
        ammo += bullets;
    }
}
