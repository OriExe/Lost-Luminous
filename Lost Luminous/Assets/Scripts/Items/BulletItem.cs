using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    [SerializeField] private int noOfBullets;
    [SerializeField] private ShootingScript gunScript;
    private void OnEnable()
    {
        gunScript.addBullets(noOfBullets);
        enabled = false;
    }
}
