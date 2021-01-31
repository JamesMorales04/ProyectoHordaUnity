using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animator;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 1.0f;
    public float sprintAcceleration = 0.5f;
    public float sprintDecceleration = 0.5f;
    
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        // Set reference of animator
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        // Get user Input
        bool forwardPress = Input.GetKey("w");
        bool runPress = Input.GetKey("left shift");

        if (forwardPress && velocity < 0.5f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if (forwardPress && runPress && velocity < 1.0f)
        {
            velocity += Time.deltaTime * sprintAcceleration;
        }
        if (forwardPress && !runPress && velocity > 0.5f)
        {
            velocity -= Time.deltaTime * sprintDecceleration;
        }
        if (!forwardPress && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }
        if (!forwardPress && velocity < 0)
        {
            velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, velocity);
    }
}
