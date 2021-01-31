using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Core : MonoBehaviour
{

    [SerializeField] private HealthCommon healthZombie;

   
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                break;

            case "Bullet":

                BulletCommon bullet = collision.gameObject.GetComponent<BulletCommon>();

                if(bullet != null)
                {
                    healthZombie.takeDamage(bullet.damage);

                    bullet.destroyBullet(0);
                }
                break;
        }

    }
   
}
