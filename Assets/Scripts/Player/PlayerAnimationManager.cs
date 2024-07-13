using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        EventChannels.playerEvents.OnPlayerMove += SetPlayerWalk;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayerWalk(bool isWalking)
    {
        // isWalking is a parameter, I mainly only use booleans to toggle different animations, but any data type can be an animation parameter
        animator.SetBool("isWalking", isWalking);
    }
}
