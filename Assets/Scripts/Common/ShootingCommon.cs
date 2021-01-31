using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCommon : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform generationPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private float fireRate;
    [SerializeField] private float shootDestroyTime;
    private float fireRateTimer;
    private GameObject GeneratedBullet;



    public void ShootingMode(int mode)
    {
        switch (mode)
        {
            case 0:
                basicShooting();
                break;
            default:
                basicShooting();
                break;
        }
    }


    void basicShooting()
    {

        shootForce = 3500;
        if (Input.GetButton("Fire1") && Time.time >= fireRateTimer)
        {
            fireRateTimer = Time.time + fireRate;
            

            GeneratedBullet = Instantiate(bullet, generationPoint.position, generationPoint.rotation);

            GeneratedBullet.GetComponent<Rigidbody>().AddForce(generationPoint.forward * shootForce);

            if (GeneratedBullet.GetComponent<BulletCommon>() != null)
            {
                GeneratedBullet.GetComponent<BulletCommon>().destroyBullet(shootDestroyTime);
            }
            
        }
    }

    
}
