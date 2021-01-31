using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody characterRigidbody;

    void Update()
    {
        moveCharacter();
    }

    void moveCharacter()
    {
        float MovementX = Input.GetAxis("Horizontal");

        float MovementZ = Input.GetAxis("Vertical");

        Vector3 direction = (transform.right * MovementX + transform.forward * MovementZ)*speed;

        direction.y = characterRigidbody.velocity.y;

        characterRigidbody.velocity = direction;

    }

}
