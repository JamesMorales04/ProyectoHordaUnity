using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCharacter1 : MonoBehaviour
{

    public GameObject bullet;
    public Transform generationPoint;

    public float shootForce;
    public float fireRate;
    public float shootDestroyTime;


    private float fireRateTimer;

    // Update is called once per frame
    void Update()
    {

        basicShooting();

    }

    void basicShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= fireRateTimer)
        {
            fireRateTimer = Time.time + fireRate;
            GameObject GeneratedBullet;

            GeneratedBullet = Instantiate(bullet, generationPoint.position, generationPoint.rotation);
            GeneratedBullet.GetComponent<Rigidbody>().AddForce(generationPoint.forward * shootForce);

            Destroy(GeneratedBullet, shootDestroyTime);

        }
    }
}
