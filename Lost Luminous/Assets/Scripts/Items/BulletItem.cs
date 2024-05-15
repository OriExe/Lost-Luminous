using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    [SerializeField] private ShootingScript gunScript;
    private void Start()
    {
        
    }
    public void addBullets(int noOfBullets)
    {
        gunScript.addBullets(noOfBullets);
    }

        


}
