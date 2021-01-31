using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        // Get instance of animator
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        // Yes, this is the player's movement and should not be what triggers the animation change for the zombies, but I'm learning, James
        bool forwardPress = Input.GetKey("w");
        bool runPress = Input.GetKey("left shift");

        if (!isWalking && forwardPress)
        {
            //Set isWalking to true
            animator.SetBool(isWalkingHash, true);
        } else {
            //Set isWalking to false
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPress && runPress))
        {
            //Set isRunning to true
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPress || !runPress))
        {
            //Set isRunning to false
            animator.SetBool(isRunningHash, false);
        }
    }
}
