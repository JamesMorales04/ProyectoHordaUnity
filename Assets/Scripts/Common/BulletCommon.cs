using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommon : MonoBehaviour
{

    [SerializeField] public float damage;



    public void destroyBullet(float destroyTimer)
    {
        Destroy(this.gameObject, destroyTimer);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy" || collision.gameObject.tag =="Terrain")
        {
            GetComponent<Rigidbody>().useGravity = true;

        }

        if (collision.gameObject.tag == "Player")
        {
            print("holka");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());
        }
        
    }
}